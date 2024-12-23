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

        Task<Medecin> GetByIdWithSessionsAsync(int id);
        Medecin GetByIdWithSessions(int id);

        Task<IEnumerable<Patient>> GetAllPatientsAsync(int medecinId);
        IEnumerable<Patient> GetAllPatients(int medecinId);

        Task<Medecin> GetByUsernameAsync(string nomUtilisateur);
    }
}
