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
    public class ConsultationRepository : EfRepository<Consultation>, IConsultationRepository
    {
        public ConsultationRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext){ }

        public Task<Consultation> GetByIdWithPrescriptionsAsync(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                  .Include(c => c._prescriptions)
                  .FirstOrDefaultAsync(c => c.Id == id)!;
        }

        public Consultation GetByIdWithPrescriptions(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                   .Include(c => c._prescriptions)
                   .FirstOrDefault(c => c.Id == id)!;
        }
    }
}
