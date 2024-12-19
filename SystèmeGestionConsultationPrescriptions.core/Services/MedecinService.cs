using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class MedecinService : IMedecinService
    {
        private readonly IMedecinRepository _medecinRepository;
        private readonly IConsultationRepository _consultationRepository;
        private readonly IPatientRepository _patientRepository;

        public MedecinService(IMedecinRepository medecinRepository, 
            IConsultationRepository consultationRepository,
            IPatientRepository patientRepository)
        {
            _medecinRepository = medecinRepository;
            _consultationRepository = consultationRepository;
            _patientRepository = patientRepository;
        }

        public async Task<Medecin> GetMedecinAsync(int id)
        {
            return await _medecinRepository.GetByIdAsync(id);
        }

        public Medecin GetMedecin(int id)
        {
            return _medecinRepository.GetById(id);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(int medecinId)
        {
            return await _medecinRepository.GetPatientsAsync(medecinId);
        }

        public IEnumerable<Patient> GetPatients(int medecinId)
        {
            return _medecinRepository.GetPatients(medecinId);
        }

        public async Task<bool> ValiderAuthentificationAsync(string nomUtilisateur, string motDePasse)
        {
            var medecin = await _medecinRepository.GetByNumeroLicenceAsync(nomUtilisateur);
            return medecin?.Valider(nomUtilisateur, motDePasse) ?? false;
        }

        public bool ValiderAuthentification(string nomUtilisateur, string motDePasse)
        {
            var medecin = _medecinRepository.GetByNumeroLicence(nomUtilisateur);
            return medecin?.Valider(nomUtilisateur, motDePasse) ?? false;
        }

        public async Task AjouterPatientAsync(int medecinId, Patient patient)
        {
            var medecin = await _medecinRepository.GetByIdAsync(medecinId);
            if (medecin == null)
                throw new ArgumentException("Médecin non trouvé", nameof(medecinId));

            patient.IdMedecin = medecinId;
            await _patientRepository.AddAsync(patient);
            patient.Notify(); // Notifie les observateurs (DossierMedical) du nouveau patient
        }

        public async Task<IEnumerable<Consultation>> GetConsultationsJourAsync(int medecinId, DateTime date)
        {
            return await _consultationRepository.GetByDossierMedicalIdAsync(medecinId);
        }

        public IEnumerable<Consultation> GetConsultationsJour(int medecinId, DateTime date)
        {
            return _consultationRepository.GetByDossierMedicalId(medecinId);
        }
    }
}