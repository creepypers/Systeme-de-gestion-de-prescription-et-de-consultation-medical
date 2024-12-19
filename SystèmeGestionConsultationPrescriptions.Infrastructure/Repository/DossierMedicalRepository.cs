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
    public class DossierMedicalRepository : EfRepository<DossierMedical>, IDossierMedicalRepository
    {
        public DossierMedicalRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext) { }

        public Task<DossierMedical> GetByPatientIdAsync(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                  .Include(c => c.IdentifiantPatient)
                  .FirstOrDefaultAsync(c => c.Id == id)!;
        }

        public DossierMedical GetByPatientId(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                   .Include(c => c.IdentifiantPatient)
                   .FirstOrDefault(c => c.Id == id)!;
        }
    }
}
