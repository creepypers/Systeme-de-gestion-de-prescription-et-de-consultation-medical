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

        public async Task<Patient> GetByIdWithDossierMedicalAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Include(p => p.DossierMedical)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Patient GetByIdWithDossierMedical(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Include(p => p.DossierMedical)
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetByMedecinIdAsync(int medecinId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Where(p => p.IdMedecin == medecinId)
                .ToListAsync();
        }

        public IEnumerable<Patient> GetByMedecinId(int medecinId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Where(p => p.IdMedecin == medecinId)
                .ToList();
        }
    }
} 