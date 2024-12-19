using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IConsultationService
    {
        Task AddConsultation(Consultation consultation);
        Task UpdateConsultation(Consultation consultation);
        Task DeleteConsultation(Consultation consultation);
        Task <Consultation> GetConsultation(int idConsultation);
        Task AddPrescription(int idConsultation, Prescription prescription);
        Task UpdatePrescription(int idConsultation, Prescription prescription);
        Task GetPrescription(int idConsultation, Prescription prescription);
    }
}
