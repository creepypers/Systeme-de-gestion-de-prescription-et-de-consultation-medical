using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IMedecinService
    {
        // Async operations
        Task AddMedecinAsync(Medecin medecin);
        Task UpdateMedecinAsync(Medecin medecin);
        Task<Medecin> GetMedecinByIdAsync(int idMedecin);
        Task DeleteMedecinAsync(Medecin medecin);
        Task AjouterPatientAsync(int idMedecin, Patient patient);
        
        // Sync operations
        Medecin AddMedecin(Medecin medecin);
        int UpdateMedecin(Medecin medecin);
        Medecin GetMedecinById(int idMedecin);
        int DeleteMedecin(Medecin medecin);
        void AjouterPatient(int idMedecin, Patient patient);
                Task<Medecin> GetByIdWithPatientsAsync(int id);
        Medecin GetByIdWithPatients(int id);

        Task<Medecin> GetByIdWithSessionsAsync(int id);
        Medecin GetByIdWithSessions(int id);

        
       
        
        // Authentication operations
        Task<bool> ValiderCredentialsAsync(string nomUtilisateur, string motDePasse);
        bool ValiderCredentials(string nomUtilisateur, string motDePasse);
    }
}
