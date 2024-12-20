using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPrescriptionService
    {
        // Async operations
        Task AddPrescriptionAsync(Prescription prescription);
        Task UpdatePrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(Prescription prescription);
        Task ChangerEtatPrescriptionAsync(int idPrescription);
        
        // Sync operations
        Prescription AddPrescription(Prescription prescription);
        int UpdatePrescription(Prescription prescription);
        Prescription GetPrescriptionById(int idPrescription);
        int DeletePrescription(Prescription prescription);
        
        
        // Query operations

    }
}
