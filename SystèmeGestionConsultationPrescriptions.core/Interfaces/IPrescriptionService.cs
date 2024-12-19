using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPrescriptionService
    {
        Task AddPrescription(Prescription prescription);
        Task UpdatePrescription(Prescription prescription);
        Task<Prescription> GetPrescription(int idPrescription);
        Task DeletePrescription(Prescription prescription);
        Task CloturePrescription(Prescription prescription);
    }
}
