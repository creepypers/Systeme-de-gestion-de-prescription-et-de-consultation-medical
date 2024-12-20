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

        public async Task<DossierMedical> GetByIdWithConsultationsAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Include(d => d.Consultations)
                .FirstOrDefaultAsync(d => d.Id == id)!;
        }

        public DossierMedical GetByIdWithConsultations(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Include(d => d.Consultations)
                .FirstOrDefault(d => d.Id == id)!;
        }

        public async Task<DossierMedical> GetByIdWithPrescriptionsAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Include(d => d.Consultations       )
                .ThenInclude(c => c.Prescriptions)
                .FirstOrDefaultAsync(d => d.Id == id)!;
        }

        public DossierMedical GetByIdWithPrescriptions(int id)
        {
                return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Include(d => d.Consultations)
                .ThenInclude(c => c.Prescriptions)
                .FirstOrDefault(d => d.Id == id)!;
        }
    }
}
