using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class DossierMedicalService : IDossierMedicalService
    {
        private readonly IDossierMedicalRepository _dossierMedicalRepository;
        private readonly IConsultationRepository _consultationRepository;

        public DossierMedicalService(IDossierMedicalRepository dossierMedicalRepository, 
            IConsultationRepository consultationRepository)
        {
            _dossierMedicalRepository = dossierMedicalRepository;
            _consultationRepository = consultationRepository;
        }

        public async Task<DossierMedical> GetDossierMedicalAsync(int id)
        {
            return await _dossierMedicalRepository.GetByIdWithPrescriptionsAsync(id);
        }

        public DossierMedical GetDossierMedical(int id)
        {
            return _dossierMedicalRepository.GetByIdWithPrescriptions(id);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsActivesAsync(int dossierMedicalId)
        {
            var dossier = await _dossierMedicalRepository.GetByIdAsync(dossierMedicalId);
            return dossier.GetPrescriptionsActives();
        }

        public IEnumerable<Prescription> GetPrescriptionsActives(int dossierMedicalId)
        {
            var dossier = _dossierMedicalRepository.GetById(dossierMedicalId);
            return dossier.GetPrescriptionsActives();
        }

        public async Task<IEnumerable<Prescription>> GetHistoriquePrescriptionsAsync(int dossierMedicalId)
        {
            var dossier = await _dossierMedicalRepository.GetByIdAsync(dossierMedicalId);
            return dossier.GetPrescriptionsTerminees();
        }

        public IEnumerable<Prescription> GetHistoriquePrescriptions(int dossierMedicalId)
        {
            var dossier = _dossierMedicalRepository.GetById(dossierMedicalId);
            return dossier.GetPrescriptionsTerminees();
        }

        public async Task<IEnumerable<Consultation>> GetConsultationsAsync(int dossierMedicalId)
        {
            return await _consultationRepository.GetByDossierMedicalIdAsync(dossierMedicalId);
        }

        public IEnumerable<Consultation> GetConsultations(int dossierMedicalId)
        {
            return _consultationRepository.GetByDossierMedicalId(dossierMedicalId);
        }

        public async Task AjouterConsultationAsync(int dossierMedicalId, Consultation consultation)
        {
            var dossier = await _dossierMedicalRepository.GetByIdAsync(dossierMedicalId);
            dossier.AjouterConsultation();
            await _dossierMedicalRepository.UpdateAsync(dossier);
        }

        public void AjouterConsultation(int dossierMedicalId, Consultation consultation)
        {
            var dossier = _dossierMedicalRepository.GetById(dossierMedicalId);
            dossier.AjouterConsultation();
            _dossierMedicalRepository.Update(dossier);
        }

        public async Task SupprimerConsultationAsync(int dossierMedicalId, int consultationId)
        {
            var dossier = await _dossierMedicalRepository.GetByIdAsync(dossierMedicalId);
            dossier.SupprimerConsultation();
            await _dossierMedicalRepository.UpdateAsync(dossier);
        }

        public void SupprimerConsultation(int dossierMedicalId, int consultationId)
        {
            var dossier = _dossierMedicalRepository.GetById(dossierMedicalId);
            dossier.SupprimerConsultation();
            _dossierMedicalRepository.Update(dossier);
        }
    }
}