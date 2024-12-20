using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPatientService
    {
        // Async operations
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(int idPatient);
        Task DeletePatientAsync(Patient patient);
        Task AssignerMedecinAsync(int idPatient, int idMedecin);
        Task CreerDossierMedicalAsync(int idPatient);
        
        // Sync operations
        Patient AddPatient(Patient patient);
        int UpdatePatient(Patient patient);
        Patient GetPatientById(int idPatient);
        int DeletePatient(Patient patient);
        void AssignerMedecin(int idPatient, int idMedecin);
        void CreerDossierMedical(int idPatient);
        
        // Query operations
         Task<Patient> GetByIdWithDossiersMedicauxAsync(int id);
        Patient GetByIdWithDossiersMedicaux(int id);

        Task<Patient> GetByIdWithMedecinAsync(int id);
        Patient GetByIdWithMedecin(int id);
    }
}
