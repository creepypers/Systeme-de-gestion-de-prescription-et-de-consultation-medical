using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IMedecinRepository : IAsyncRepository<Medecin>, IRepository<Medecin>
    {
        Task<Medecin> GetByIdWithPatientsAsync(int id);
        Medecin GetByIdWithPatients(int id);
    }
}
