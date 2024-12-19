using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IMedecinService
    {
        Task<Medecin> GetMedecinAsync(int id);
        Medecin GetMedecin(int id);
        Task<IEnumerable<Patient>> GetPatientsAsync(int medecinId);
        IEnumerable<Patient> GetPatients(int medecinId);
        Task<bool> ValiderAuthentificationAsync(string nomUtilisateur, string motDePasse);
        bool ValiderAuthentification(string nomUtilisateur, string motDePasse);
        Task AjouterPatientAsync(int medecinId, Patient patient);
        Task<IEnumerable<Consultation>> GetConsultationsJourAsync(int medecinId, DateTime date);
        IEnumerable<Consultation> GetConsultationsJour(int medecinId, DateTime date);
    }
}