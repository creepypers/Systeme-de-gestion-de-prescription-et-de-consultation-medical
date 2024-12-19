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


        

        public SystèmeGestionConsultationPrescriptionsDBContext(DbContextOptions options) : base(options) { }

        public SystèmeGestionConsultationPrescriptionsDBContext() : base(new DbContextOptionsBuilder<SystèmeGestionConsultationPrescriptionsDBContext>()
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SystèmeGestionConsultationPrescriptionsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                    .Options)
        { }
    }
}
