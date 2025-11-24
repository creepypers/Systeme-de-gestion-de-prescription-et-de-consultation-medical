using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure
{
    public class SystèmeGestionConsultationPrescriptionsDBContext : DbContext
    {
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<DossierMedical> DossiersMedical { get; set; }
        
        public DbSet<Prescription> TraitementsPassees { get; set; }

        public DbSet<Session> Sessions { get; set; }


        

        public SystèmeGestionConsultationPrescriptionsDBContext(DbContextOptions<SystèmeGestionConsultationPrescriptionsDBContext> options) : base(options) { }

        public SystèmeGestionConsultationPrescriptionsDBContext() : base(new DbContextOptionsBuilder<SystèmeGestionConsultationPrescriptionsDBContext>()
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SystèmeGestionConsultationPrescriptionsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                    .Options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SystèmeGestionConsultationPrescriptionsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Consultation)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(p => p.ConsultationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.DossierMedical)
                .WithMany(d => d.Consultations)
                .HasForeignKey(c => c.DossierMedicalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DossierMedical>()
                .HasOne(d => d.Patient)
                .WithOne(p => p.DossierMedical)
                .HasForeignKey<DossierMedical>(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Session)
                .WithMany(s => s.Consultations)
                .HasForeignKey(c => c.SessionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.DossierMedical)
                .WithOne(d => d.Patient)
                .HasForeignKey<DossierMedical>(d => d.PatientId);

                 modelBuilder.Entity<Prescription>()
                    .Property(p => p.Duree)
                    .HasConversion(
                     v => v.ToString(),
                     v => TimeSpan.Parse(v))
                    .HasColumnType("nvarchar(48)");
                
        }

    }
}