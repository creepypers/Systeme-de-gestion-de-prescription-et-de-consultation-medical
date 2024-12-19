using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPatientRepository: IAsyncRepository<Patient>, IRepository<Patient>
    {
        Task<Patient> GetByIdWithDossiersMedicauxAsync(int id);
        Patient GetByIdWithDossiersMedicaux(int id);
    }
}
