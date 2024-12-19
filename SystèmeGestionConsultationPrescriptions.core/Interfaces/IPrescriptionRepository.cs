using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPrescriptionRepository : IAsyncRepository<Prescription>, IRepository<Prescription>
    {
        Task<Prescription> GetByIdWithConsultationsAsync(int id);
        Prescription GetByIdWithConsultations(int id);
    }
}
