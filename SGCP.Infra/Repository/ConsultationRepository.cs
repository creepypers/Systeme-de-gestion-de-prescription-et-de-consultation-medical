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
                  .Include(c => c.Prescriptions)
                  .FirstOrDefaultAsync(c => c.Id == id)!;
        }

        public Consultation GetByIdWithPrescriptions(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                   .Include(c => c.Prescriptions)
                   .FirstOrDefault(c => c.Id == id)!;
        }

        public async Task<Consultation> GetByIdWithDossierMedicalAsync(DossierMedical dossierMedical)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.DossierMedical)
                .FirstOrDefaultAsync(c => c.DossierMedicalId == dossierMedical.Id)!;
        }

        public Consultation GetByIdWithDossierMedical(DossierMedical dossierMedical)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.DossierMedical)
                .FirstOrDefault(c => c.DossierMedicalId == dossierMedical.Id)!;
        }

        public async Task<Consultation> GetByIdWithSessionAsync(Session session)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Session)
                .FirstOrDefaultAsync(c => c.SessionId == session.Id)!;
        }

        public Consultation GetByIdWithSession(Session session)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Session)
                .FirstOrDefault(c => c.SessionId == session.Id)!;
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync(int consultationId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Where(c => c.Id == consultationId)
                .SelectMany(c => c.Prescriptions)
                .ToListAsync();
        }

        public IEnumerable<Prescription> GetAllPrescriptions(int consultationId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Where(c => c.Id == consultationId)
                .SelectMany(c => c.Prescriptions)
                .ToList();
        }

        public async Task<IEnumerable<Consultation>> GetByMedecinIdAsync(int medecinId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Session)
                .Include(c => c.DossierMedical)
                    .ThenInclude(d => d.Patient)
                .Where(c => c.Session.MedecinId == medecinId)
                .OrderByDescending(c => c.Date)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consultation = await _SystèmeGestionConsultationPrescriptionsContext.Consultations.FindAsync(id);
            if (consultation != null)
            {
                _SystèmeGestionConsultationPrescriptionsContext.Consultations.Remove(consultation);
                await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
            }
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int prescriptionId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Prescriptions
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Prescriptions.Update(prescription);
            await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            await _SystèmeGestionConsultationPrescriptionsContext.Prescriptions.AddAsync(prescription);
            await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
        }

        public async Task ChangerEtatAsync(int consultationId, int prescriptionId)
        {
            var consultation = await _SystèmeGestionConsultationPrescriptionsContext.Consultations.FindAsync(consultationId);
            if (consultation != null)
            {
                consultation.ChangerEtat(prescriptionId);
                await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
            }
        }

        public async Task DeletePrescriptionAsync(int prescriptionId)
        {
            var prescription = await _SystèmeGestionConsultationPrescriptionsContext.Prescriptions.FindAsync(prescriptionId);
            if (prescription != null)
            {
                _SystèmeGestionConsultationPrescriptionsContext.Prescriptions.Remove(prescription);
                await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByMedecinIdAsync(int medecinId)
{
    return await _SystèmeGestionConsultationPrescriptionsContext.Prescriptions
        .Include(p => p.Consultation)
            .ThenInclude(c => c.Session)
        .Include(p => p.Consultation)
            .ThenInclude(c => c.DossierMedical)
                .ThenInclude(d => d.Patient)
        .Where(p => p.Consultation.Session.MedecinId == medecinId)
        .OrderByDescending(p => p.Consultation.Date)
        .ToListAsync();
}
    }
}
