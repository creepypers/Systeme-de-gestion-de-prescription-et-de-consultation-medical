using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IConsultationService
    {
        Task<Consultation> GetConsultationAsync(int id);
        Consultation GetConsultation(int id);

        
        Task<IEnumerable<Prescription>> GetPrescriptionsAsync(int consultationId);
        IEnumerable<Prescription> GetPrescriptions(int consultationId);
        Task AjouterPrescriptionAsync(int consultationId, Prescription prescription);

        Task ModifierConsultationAsync(Consultation consultation);
        void ModifierConsultation(Consultation consultation);
        Task<IEnumerable<Consultation>> GetConsultationsByMedecinAsync(int medecinId);
        IEnumerable<Consultation> GetConsultationsByMedecin(int medecinId);
    }
} 