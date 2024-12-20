using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IConsultationService
    {
        // Async operations
        Task AddConsultationAsync(Consultation consultation);
        Task UpdateConsultationAsync(Consultation consultation);
        Task<Consultation> GetConsultationByIdAsync(int idConsultation);
        Task DeleteConsultationAsync(Consultation consultation);
        Task AddPrescriptionAsync(int idConsultation, Prescription prescription);
        Task UpdatePrescriptionAsync(int idConsultation, Prescription prescription);
        Task<Consultation> GetByIdWithPrescriptionsAsync(int id);
        Consultation GetByIdWithPrescriptions(int id);

        Task<Consultation> GetByIdWithDossierMedicalAsync(DossierMedical dossierMedical);
        Consultation GetByIdWithDossierMedical(DossierMedical dossierMedical);

        Task<Consultation> GetByIdWithSessionAsync(Session session);
        Consultation GetByIdWithSession(Session session);
        
        

        Consultation AddConsultation(Consultation consultation);
        int UpdateConsultation(Consultation consultation);
        Consultation GetConsultationById(int idConsultation);
        int DeleteConsultation(Consultation consultation);
        
        
        List<Consultation> GetConsultations(bool includePrescriptions);
    }
}
