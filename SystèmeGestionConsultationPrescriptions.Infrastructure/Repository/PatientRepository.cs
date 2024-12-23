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

        public async Task<Patient> GetByIdWithMedecinAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Include(p => p.Medecin)
                .FirstOrDefaultAsync(p => p.Id == id)!;
        }

        public Patient GetByIdWithMedecin(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Include(p => p.Medecin)
                .FirstOrDefault(p => p.Id == id)!;
        }

        public async Task<IEnumerable<Patient>> GetPatientsByMedecinIdAsync(int medecinId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Where(p => p.MedecinId == medecinId)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _SystèmeGestionConsultationPrescriptionsContext.Patients.FindAsync(id);
            if (patient != null)
            {
                _SystèmeGestionConsultationPrescriptionsContext.Patients.Remove(patient);
                await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
            }
        }

        

       
    }
} 