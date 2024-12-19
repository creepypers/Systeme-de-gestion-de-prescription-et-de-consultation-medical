using System;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface ISessionService
    {
        Task<Session> CreerSessionAsync(int utilisateurId);
        Session CreerSession(int utilisateurId);
        Task TerminerSessionAsync(int sessionId);
        void TerminerSession(int sessionId);
        Task<Session> GetSessionActiveAsync(int utilisateurId);
        Session GetSessionActive(int utilisateurId);
        Task<bool> ValiderSessionAsync(int sessionId);
        bool ValiderSession(int sessionId);
    }
} 