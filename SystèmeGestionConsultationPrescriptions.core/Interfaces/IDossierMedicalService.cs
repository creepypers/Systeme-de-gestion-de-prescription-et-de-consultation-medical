using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IDossierMedicalService
    {
        Task<DossierMedical> GetDossierMedicalAsync(int id);
        DossierMedical GetDossierMedical(int id);
        Task<IEnumerable<Prescription>> GetPrescriptionsActivesAsync(int dossierMedicalId);
        IEnumerable<Prescription> GetPrescriptionsActives(int dossierMedicalId);
        Task<IEnumerable<Prescription>> GetHistoriquePrescriptionsAsync(int dossierMedicalId);
        IEnumerable<Prescription> GetHistoriquePrescriptions(int dossierMedicalId);
        Task<IEnumerable<Consultation>> GetConsultationsAsync(int dossierMedicalId);
        IEnumerable<Consultation> GetConsultations(int dossierMedicalId);
        Task AjouterConsultationAsync(int dossierMedicalId, Consultation consultation);
        void AjouterConsultation(int dossierMedicalId, Consultation consultation);
        Task SupprimerConsultationAsync(int dossierMedicalId, int consultationId);
        void SupprimerConsultation(int dossierMedicalId, int consultationId);
    }
} 