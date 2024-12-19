using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPatientRepository : IAsyncRepository<Patient>, IRepository<Patient>
    {
        Task<Patient> GetByIdWithDossierMedicalAsync(int id);
        Patient GetByIdWithDossierMedical(int id);
        
        Task<IEnumerable<Patient>> GetByMedecinIdAsync(int medecinId);
        IEnumerable<Patient> GetByMedecinId(int medecinId);
    }
} 