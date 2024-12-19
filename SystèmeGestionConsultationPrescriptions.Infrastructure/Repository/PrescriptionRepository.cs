using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class PrescriptionRepository : EfRepository<Prescription>, IPrescriptionRepository 
    {
        public PrescriptionRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext) { }

        public Task<Prescription> GetByIdWithConsultationsAsync(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Prescriptions
                  .Include(p => p.Consultation)
                  .FirstOrDefaultAsync(p => p.Id == id)!;
        }

        public Prescription GetByIdWithConsultations(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Prescriptions
                   .Include(p => p.Consultation)
                   .FirstOrDefault(p => p.Id == id)!;
        }
    }
}
