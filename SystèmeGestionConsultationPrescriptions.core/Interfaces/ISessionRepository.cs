using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface ISessionRepository : IAsyncRepository<Session>, IRepository<Session>
    {
        Task<Session> GetActiveSessionByUtilisateurIdAsync(int utilisateurId);
        Session GetActiveSessionByUtilisateurId(int utilisateurId);
        Task<IEnumerable<Session>> GetSessionHistoryByUtilisateurIdAsync(int utilisateurId);
        IEnumerable<Session> GetSessionHistoryByUtilisateurId(int utilisateurId);
    }
}