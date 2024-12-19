using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetPatientAsync(int id);
        Patient GetPatient(int id);
        
        Task<DossierMedical> GetDossierMedicalAsync(int patientId);
        DossierMedical GetDossierMedical(int patientId);
        
        Task ModifierInformationsAsync(Patient patient);
        void ModifierInformations(Patient patient);
        
        Task<IEnumerable<Consultation>> GetHistoriqueConsultationsAsync(int patientId);
        IEnumerable<Consultation> GetHistoriqueConsultations(int patientId);
    }
}