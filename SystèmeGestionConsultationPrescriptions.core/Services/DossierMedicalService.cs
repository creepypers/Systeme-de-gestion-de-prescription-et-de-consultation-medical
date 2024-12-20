using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class DossierMedicalService : IDossierMedicalService
    {
        private readonly IDossierMedicalRepository _dossierMedicalRepository;
        
        public DossierMedicalService(IDossierMedicalRepository dossierMedicalRepository) 
        {
            _dossierMedicalRepository = dossierMedicalRepository;
        }

        // Async operations
        public async Task AddDossierMedicalAsync(DossierMedical dossier)
        {
            await _dossierMedicalRepository.AddAsync(dossier);
        }

        public async Task UpdateDossierMedicalAsync(DossierMedical dossier)
        {
            await _dossierMedicalRepository.UpdateAsync(dossier);
        }

        public async Task<DossierMedical> GetDossierMedicalByIdAsync(int idDossier)
        {
            return await _dossierMedicalRepository.GetByIdAsync(idDossier);
        }

        public async Task DeleteDossierMedicalAsync(DossierMedical dossier)
        {
            await _dossierMedicalRepository.DeleteAsync(dossier);
        }

        public async Task AjouterTraitementAsync(int idDossier, Prescription prescription)
        {
            var dossier = await _dossierMedicalRepository.GetByIdAsync(idDossier);
            dossier.Prescriptions.Add(prescription);
            await _dossierMedicalRepository.UpdateAsync(dossier);
        }

        public async Task<DossierMedical> GetByPatientIdAsync(int patientId)
        {
            return await _dossierMedicalRepository.GetByPatientIdAsync(patientId);
        }

        public DossierMedical GetByPatientId(int patientId)
        {
            return _dossierMedicalRepository.GetByPatientId(patientId);
        }

        public async Task<DossierMedical> GetByIdWithConsultationsAsync(int id)
        {
            return await _dossierMedicalRepository.GetByIdWithConsultationsAsync(id);
        }

        public DossierMedical GetByIdWithConsultations(int id)
        {
            return _dossierMedicalRepository.GetByIdWithConsultations(id);
        }

        public async Task<DossierMedical> GetByIdWithPrescriptionsAsync(int id)
        {
            return await _dossierMedicalRepository.GetByIdWithPrescriptionsAsync(id);
        }

        public DossierMedical GetByIdWithPrescriptions(int id)
        {
            return _dossierMedicalRepository.GetByIdWithPrescriptions(id);
        }

        // Sync operations
        public DossierMedical AddDossierMedical(DossierMedical dossier)
        {
            return _dossierMedicalRepository.Add(dossier);
        }

        public int UpdateDossierMedical(DossierMedical dossier)
        {
            _dossierMedicalRepository.Update(dossier);
            return dossier.Id;
        }

        public DossierMedical GetDossierMedicalById(int idDossier)
        {
            return _dossierMedicalRepository.GetById(idDossier);
        }

        public int DeleteDossierMedical(DossierMedical dossier)
        {
            _dossierMedicalRepository.Delete(dossier);
            return dossier.Id;
        }
    }
}
