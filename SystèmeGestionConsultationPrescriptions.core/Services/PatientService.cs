using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMedecinRepository _medecinRepository;
        private readonly IDossierMedicalRepository _dossierMedicalRepository;

        public PatientService(
            IPatientRepository patientRepository,
            IMedecinRepository medecinRepository,
            IDossierMedicalRepository dossierMedicalRepository)
        {
            _patientRepository = patientRepository;
            _medecinRepository = medecinRepository;
            _dossierMedicalRepository = dossierMedicalRepository;
        }

        // Async operations
        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task<Patient> GetPatientByIdAsync(int idPatient)
        {
            return await _patientRepository.GetByIdAsync(idPatient);
        }

        public async Task DeletePatientAsync(Patient patient)
        {
            await _patientRepository.DeleteAsync(patient);
        }

        public async Task AssignerMedecinAsync(int idPatient, int idMedecin)
        {
            var patient = await _patientRepository.GetByIdAsync(idPatient);
            var medecin = await _medecinRepository.GetByIdAsync(idMedecin);
            if (patient != null && medecin != null)
            {
                patient.Medecin = medecin;
                await _patientRepository.UpdateAsync(patient);
            }
        }

        public async Task CreerDossierMedicalAsync(int idPatient)
        {
            var patient = await _patientRepository.GetByIdAsync(idPatient);
            if (patient != null)
            {
                var dossierMedical = new DossierMedical(idPatient, DateTime.Now);
                await _dossierMedicalRepository.AddAsync(dossierMedical);
                patient.DossierMedical = dossierMedical;
                await _patientRepository.UpdateAsync(patient);
            }
        }

        // Sync operations
        public Patient AddPatient(Patient patient)
        {
            return _patientRepository.Add(patient);
        }

        public int UpdatePatient(Patient patient)
        {
            _patientRepository.Update(patient);
            return patient.Id;
        }

        public Patient GetPatientById(int idPatient)
        {
            return _patientRepository.GetById(idPatient);
        }

        public int DeletePatient(Patient patient)
        {
            _patientRepository.Delete(patient);
            return patient.Id;
        }

        public void AssignerMedecin(int idPatient, int idMedecin)
        {
            var patient = _patientRepository.GetById(idPatient);
            var medecin = _medecinRepository.GetById(idMedecin);
            if (patient != null && medecin != null)
            {
                patient.Medecin = medecin;
                _patientRepository.Update(patient);
            }
        }

        public void CreerDossierMedical(int idPatient)
        {
            var patient = _patientRepository.GetById(idPatient);
            if (patient != null)
            {
                var dossierMedical = new DossierMedical(idPatient, DateTime.Now);
                _dossierMedicalRepository.Add(dossierMedical);
                patient.DossierMedical = dossierMedical;
                _patientRepository.Update(patient);
            }
        }

        // Query operations
        public async Task<Patient> GetByIdWithDossiersMedicauxAsync(int id)
        {
            return await _patientRepository.GetByIdWithDossiersMedicauxAsync(id);
        }

        public Patient GetByIdWithDossiersMedicaux(int id)
        {
            return _patientRepository.GetByIdWithDossiersMedicaux(id);
        }

        public async Task<Patient> GetByIdWithMedecinAsync(int id)
        {
            return await _patientRepository.GetByIdWithMedecinAsync(id);
        }

        public Patient GetByIdWithMedecin(int id)
        {
            return _patientRepository.GetByIdWithMedecin(id);
        }
    }
}
