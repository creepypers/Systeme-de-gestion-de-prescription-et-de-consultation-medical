using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class PatientRepository : EfRepository<Patient>, IPatientRepository
    {
        public PatientRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext)
        {
        }

        public async Task<Patient> GetByIdWithDossiersMedicauxAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Include(p => p.DossierMedical)
                .FirstOrDefaultAsync(p => p.Id == id)!;
        }

        public Patient GetByIdWithDossiersMedicaux(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Include(p => p.DossierMedical)
                .FirstOrDefault(p => p.Id == id)!;
        }

       
    }
} 