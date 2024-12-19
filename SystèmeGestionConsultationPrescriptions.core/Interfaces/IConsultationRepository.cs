using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IConsultationRepository : IAsyncRepository<Consultation>, IRepository<Consultation>
    {
        Task<Consultation> GetByIdWithPrescriptionsAsync(int id);
        Consultation GetByIdWithPrescriptions(int id);
        
        Task<IEnumerable<Consultation>> GetByDossierMedicalIdAsync(int dossierMedicalId);
        IEnumerable<Consultation> GetByDossierMedicalId(int dossierMedicalId);
        Task<IEnumerable<Prescription>> GetPrescriptionsByConsultationIdAsync(int consultationId);
        IEnumerable<Prescription> GetPrescriptionsByConsultationId(int consultationId);
        Task<IEnumerable<Prescription>> GetActivePrescriptionsAsync(int consultationId);
        IEnumerable<Prescription> GetActivePrescriptions(int consultationId);
    }
}