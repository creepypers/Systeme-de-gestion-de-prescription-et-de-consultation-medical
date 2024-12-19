using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class DossierMedicalRepository : EfRepository<DossierMedical>, IDossierMedicalRepository
    {
        public DossierMedicalRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext)
        {
        }

        public async Task<DossierMedical> GetByIdWithPrescriptionsAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Include(d => d.GetPrescriptionsActives())
                .Include(d => d.GetPrescriptionsTerminees())
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public DossierMedical GetByIdWithPrescriptions(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Include(d => d.GetPrescriptionsActives())
                .Include(d => d.GetPrescriptionsTerminees())
                .FirstOrDefault(d => d.Id == id);
        }

        public async Task<DossierMedical> GetByPatientIdAsync(int patientId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .FirstOrDefaultAsync(d => d.IdentifiantPatient == patientId);
        }

        public DossierMedical GetByPatientId(int patientId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .FirstOrDefault(d => d.IdentifiantPatient == patientId);
        }
    }
} 