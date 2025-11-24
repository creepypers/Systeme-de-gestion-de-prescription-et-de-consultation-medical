using SystèmeGestionConsultationPrescriptions.core.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMedecinRepository _medecinRepository;

        public AuthenticationService(ISessionRepository sessionRepository, IMedecinRepository medecinRepository)
        {
            _sessionRepository = sessionRepository;
            _medecinRepository = medecinRepository;
        }

        public async Task<Medecin> AuthenticateAsync(string nomUtilisateur, string motDePasse)
        {
            var medecin = await _medecinRepository.GetByUsernameAsync(nomUtilisateur);
            if (medecin != null && medecin.MotDePasse == motDePasse)
                return medecin;
            return null;
        }

        public async Task<bool> ValidateSessionAsync(int sessionId)
        {
            var session = await _sessionRepository.GetByIdAsync(sessionId);
            return session != null && session.DateDeconnexion == null;
        }

        public async Task<Session> CreateSessionAsync(int medecinId)
        {
            var session = new Session { MedecinId = medecinId, DateConnexion = DateTime.Now };
            return await _sessionRepository.CreateAsync(session);
        }

        public async Task EndSessionAsync(int sessionId)
        {
            var session = await _sessionRepository.GetByIdAsync(sessionId);
            if (session != null)
                session.DateDeconnexion = DateTime.Now;
            await _sessionRepository.UpdateAsync(session);
        }

    }
}   
