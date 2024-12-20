using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class MedecinService : IMedecinService
    {
        private readonly IMedecinRepository _medecinRepository;
        
        public MedecinService(IMedecinRepository medecinRepository) 
        {
            _medecinRepository = medecinRepository;
        }

        // Async operations
        public async Task AddMedecinAsync(Medecin medecin)
        {
            await _medecinRepository.AddAsync(medecin);
        }

        public async Task UpdateMedecinAsync(Medecin medecin)
        {
            await _medecinRepository.UpdateAsync(medecin);
        }

        public async Task<Medecin> GetMedecinByIdAsync(int idMedecin)
        {
            return await _medecinRepository.GetByIdAsync(idMedecin);
        }

        public async Task DeleteMedecinAsync(Medecin medecin)
        {
            await _medecinRepository.DeleteAsync(medecin);
        }

        public async Task AjouterPatientAsync(int idMedecin, Patient patient)
        {
            var medecin = await _medecinRepository.GetByIdAsync(idMedecin);
            if (medecin != null)
            {
                medecin.Patients.Add(patient);
                await _medecinRepository.UpdateAsync(medecin);
            }
        }

        public void AjouterPatient(int idMedecin, Patient patient)
        {
            var medecin = _medecinRepository.GetById(idMedecin);
            if (medecin != null)
            {
                medecin.Patients.Add(patient);
                _medecinRepository.Update(medecin);
            }
        }

        public async Task<Medecin> GetByIdWithPatientsAsync(int id)
        {
            return await _medecinRepository.GetByIdWithPatientsAsync(id);
        }

        public Medecin GetByIdWithPatients(int id)
        {
            return _medecinRepository.GetByIdWithPatients(id);
        }

        public async Task<Medecin> GetByIdWithSessionsAsync(int id)
        {
            return await _medecinRepository.GetByIdWithSessionsAsync(id);
        }

        public Medecin GetByIdWithSessions(int id)
        {
            return _medecinRepository.GetByIdWithSessions(id);
        }

        public async Task<bool> ValiderCredentialsAsync(string nomUtilisateur, string motDePasse)
        {
            var medecins = await _medecinRepository.ListAllAsync();
            return medecins.Any(m => m.Valider(nomUtilisateur, motDePasse));
        }

        public bool ValiderCredentials(string nomUtilisateur, string motDePasse)
        {
            var medecins = _medecinRepository.ListAll();
            return medecins.Any(m => m.Valider(nomUtilisateur, motDePasse));
        }

        // Sync operations
        public Medecin AddMedecin(Medecin medecin)
        {
            return _medecinRepository.Add(medecin);
        }

        public int UpdateMedecin(Medecin medecin)
        {
            _medecinRepository.Update(medecin);
            return medecin.Id;
        }

        public Medecin GetMedecinById(int idMedecin)
        {
            return _medecinRepository.GetById(idMedecin);
        }

        public int DeleteMedecin(Medecin medecin)
        {
            _medecinRepository.Delete(medecin);
            return medecin.Id;
        }
    }
}
