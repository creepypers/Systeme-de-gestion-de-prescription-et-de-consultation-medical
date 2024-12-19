using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class MedecinRepository : EfRepository<Medecin>, IMedecinRepository
    {
        public MedecinRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext)
        {
        }

        public async Task<Medecin> GetByNumeroLicenceAsync(string numeroLicence)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .FirstOrDefaultAsync(m => m.NumeroLicence == numeroLicence);
        }

        public Medecin GetByNumeroLicence(string numeroLicence)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .FirstOrDefault(m => m.NumeroLicence == numeroLicence);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(int medecinId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Where(p => p.IdMedecin == medecinId)
                .ToListAsync();
        }

        public IEnumerable<Patient> GetPatients(int medecinId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Patients
                .Where(p => p.IdMedecin == medecinId)
                .ToList();
        }
    }
} 