using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IDossierMedicalService
    {
        // Async operations
        Task AddDossierMedicalAsync(DossierMedical dossier);
        Task UpdateDossierMedicalAsync(DossierMedical dossier);
        Task<DossierMedical> GetDossierMedicalByIdAsync(int idDossier);
        Task DeleteDossierMedicalAsync(DossierMedical dossier);
        Task AjouterTraitementAsync(int idDossier, Prescription prescription);
          Task<DossierMedical> GetByPatientIdAsync(int patientId);
        DossierMedical GetByPatientId(int patientId);

        Task<DossierMedical> GetByIdWithConsultationsAsync(int id);
        DossierMedical GetByIdWithConsultations(int id);

        Task<DossierMedical> GetByIdWithPrescriptionsAsync(int id);
        DossierMedical GetByIdWithPrescriptions(int id);
        
        // Sync operations
        DossierMedical AddDossierMedical(DossierMedical dossier);
        int UpdateDossierMedical(DossierMedical dossier);
        DossierMedical GetDossierMedicalById(int idDossier);
        int DeleteDossierMedical(DossierMedical dossier);
        
        
    }
}
