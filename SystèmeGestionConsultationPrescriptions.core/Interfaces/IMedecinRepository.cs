using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IMedecinRepository : IAsyncRepository<Medecin>, IRepository<Medecin>
    {
        Task<Medecin> GetByNumeroLicenceAsync(string numeroLicence);
        Medecin GetByNumeroLicence(string numeroLicence);
        
        Task<IEnumerable<Patient>> GetPatientsAsync(int medecinId);
        IEnumerable<Patient> GetPatients(int medecinId);
    }
}