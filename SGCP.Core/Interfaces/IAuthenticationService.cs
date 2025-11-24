using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Medecin> AuthenticateAsync(string nomUtilisateur, string motDePasse);
        Task<bool> ValidateSessionAsync(int sessionId);
        Task<Session> CreateSessionAsync(int medecinId);
        Task EndSessionAsync(int sessionId);
    }
} 