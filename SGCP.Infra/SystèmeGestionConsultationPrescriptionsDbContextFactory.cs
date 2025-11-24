using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SystèmeGestionConsultationPrescriptions.Infrastructure;

namespace SystèmeGestionStationService.Infrastructure
{
    public class SystèmeGestionConsultationPrescriptionsDBContextFactory : IDesignTimeDbContextFactory<SystèmeGestionConsultationPrescriptionsDBContext>
    {
        public SystèmeGestionConsultationPrescriptionsDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SystèmeGestionConsultationPrescriptionsDBContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SystèmeGestionConsultationPrescriptionsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new SystèmeGestionConsultationPrescriptionsDBContext(optionsBuilder.Options);
        }
    }
}
