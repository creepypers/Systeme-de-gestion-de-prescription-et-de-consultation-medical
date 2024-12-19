using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDossierMedicalRepository _dossierMedicalRepository;
        private readonly IConsultationRepository _consultationRepository;

        public PatientService(
            IPatientRepository patientRepository,
            IDossierMedicalRepository dossierMedicalRepository,
            IConsultationRepository consultationRepository)
        {
            _patientRepository = patientRepository;
            _dossierMedicalRepository = dossierMedicalRepository;
            _consultationRepository = consultationRepository;
        }

        public async Task<Patient> GetPatientAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public Patient GetPatient(int id)
        {
            return _patientRepository.GetById(id);
        }

        public async Task<DossierMedical> GetDossierMedicalAsync(int patientId)
        {
            return await _dossierMedicalRepository.GetByPatientIdAsync(patientId);
        }

        public DossierMedical GetDossierMedical(int patientId)
        {
            return _dossierMedicalRepository.GetByPatientId(patientId);
        }

        public async Task ModifierInformationsAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            patient.Notify(); // Notifie les observateurs des changements
        }

        public void ModifierInformations(Patient patient)
        {
            _patientRepository.Update(patient);
            patient.Notify();
        }

        public async Task<IEnumerable<Consultation>> GetHistoriqueConsultationsAsync(int patientId)
        {
            var dossier = await _dossierMedicalRepository.GetByPatientIdAsync(patientId);
            return await _consultationRepository.GetByDossierMedicalIdAsync(dossier.Id);
        }

        public IEnumerable<Consultation> GetHistoriqueConsultations(int patientId)
        {
            var dossier = _dossierMedicalRepository.GetByPatientId(patientId);
            return _consultationRepository.GetByDossierMedicalId(dossier.Id);
        }
    }
}