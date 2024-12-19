using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public async Task<Consultation> GetConsultationAsync(int id)
        {
            return await _consultationRepository.GetByIdWithPrescriptionsAsync(id);
        }

        public Consultation GetConsultation(int id)
        {
            return _consultationRepository.GetByIdWithPrescriptions(id);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsAsync(int consultationId)
        {
            return await _consultationRepository.GetPrescriptionsByConsultationIdAsync(consultationId);
        }

        public IEnumerable<Prescription> GetPrescriptions(int consultationId)
        {
            return _consultationRepository.GetPrescriptionsByConsultationId(consultationId);
        }

        public async Task AjouterPrescriptionAsync(int consultationId, Prescription prescription)
        {
            var consultation = await _consultationRepository.GetByIdAsync(consultationId);
            consultation.AjouterPrescription(prescription);
            await _consultationRepository.UpdateAsync(consultation);
        }

        public async Task ModifierConsultationAsync(Consultation consultation)
        {
            await _consultationRepository.UpdateAsync(consultation);
        }

        public void ModifierConsultation(Consultation consultation)
        {
            _consultationRepository.Update(consultation);
        }

        public async Task<IEnumerable<Consultation>> GetConsultationsByMedecinAsync(int medecinId)
        {
            return await _consultationRepository.GetByDossierMedicalIdAsync(medecinId);
        }

        public IEnumerable<Consultation> GetConsultationsByMedecin(int medecinId)
        {
            return _consultationRepository.GetByDossierMedicalId(medecinId);
        }
    }
}