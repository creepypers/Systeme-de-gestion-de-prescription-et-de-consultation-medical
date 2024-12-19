using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using SystèmeGestionConsultationPrescriptions.Infrastructure;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class ConsultationRepository : EfRepository<Consultation>, IConsultationRepository
    {
        public ConsultationRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext)
        {
        }

        public async Task<Consultation> GetByIdWithPrescriptionsAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Prescriptions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Consultation GetByIdWithPrescriptions(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Prescriptions)
                .FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Consultation>> GetByDossierMedicalIdAsync(int dossierMedicalId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Where(d => d.Id == dossierMedicalId)
                .SelectMany(d => d.Consultations)
                .ToListAsync();
        }

        public IEnumerable<Consultation> GetByDossierMedicalId(int dossierMedicalId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.DossiersMedical
                .Where(d => d.Id == dossierMedicalId)
                .SelectMany(d => d.Consultations)
                .ToList();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByConsultationIdAsync(int consultationId)
        {
            var consultation = await GetByIdWithPrescriptionsAsync(consultationId);
            return consultation?.Prescriptions ?? new List<Prescription>();
        }

        public IEnumerable<Prescription> GetPrescriptionsByConsultationId(int consultationId)
        {
            var consultation = GetByIdWithPrescriptions(consultationId);
            return consultation?.Prescriptions ?? new List<Prescription>();
        }

        public IEnumerable<Prescription> GetActivePrescriptions(int consultationId)
        {
            var consultation = GetByIdWithPrescriptions(consultationId);
            return consultation?.Prescriptions.Where(p => p.Etat) ?? new List<Prescription>();
        }

        public async Task<IEnumerable<Prescription>> GetActivePrescriptionsAsync(int consultationId)
        {
            var consultation = await GetByIdWithPrescriptionsAsync(consultationId);
            return consultation?.Prescriptions.Where(p => p.Etat) ?? new List<Prescription>();
        }
    }
} 