using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface ISessionRepository : IAsyncRepository<Session>, IRepository<Session>
    {
        Task<Session> GetByIdWithConsultationsAsync(int id);
        Session GetByIdWithConsultations(int id);


        Task<Session> GetByIdWithMedecinAsync(int id);
        Session GetByIdWithMedecin(int id);

        Task<Session> GetByIdWithDossierMedicalAsync(int id);
        Session GetByIdWithDossierMedical(int id);
       
    }
}
