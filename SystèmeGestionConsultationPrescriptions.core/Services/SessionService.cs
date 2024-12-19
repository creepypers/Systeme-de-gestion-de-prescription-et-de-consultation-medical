using System;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<Session> CreerSessionAsync(int utilisateurId)
        {
            var session = new Session(utilisateurId);
            return await _sessionRepository.AddAsync(session);
        }

        public Session CreerSession(int utilisateurId)
        {
            var session = new Session(utilisateurId);
            return _sessionRepository.Add(session);
        }

        public async Task TerminerSessionAsync(int sessionId)
        {
            var session = await _sessionRepository.GetByIdAsync(sessionId);
            session.DateDeconnexion = DateTime.Now;
            await _sessionRepository.UpdateAsync(session);
        }

        public void TerminerSession(int sessionId)
        {
            var session = _sessionRepository.GetById(sessionId);
            session.DateDeconnexion = DateTime.Now;
            _sessionRepository.Update(session);
        }

        public async Task<Session> GetSessionActiveAsync(int utilisateurId)
        {
            return await _sessionRepository.GetActiveSessionByUtilisateurIdAsync(utilisateurId);
        }

        public Session GetSessionActive(int utilisateurId)
        {
            return _sessionRepository.GetActiveSessionByUtilisateurId(utilisateurId);
        }

        public async Task<bool> ValiderSessionAsync(int sessionId)
        {
            var session = await _sessionRepository.GetByIdAsync(sessionId);
            return session != null && !session.DateDeconnexion.HasValue;
        }

        public bool ValiderSession(int sessionId)
        {
            var session = _sessionRepository.GetById(sessionId);
            return session != null && !session.DateDeconnexion.HasValue;
        }
    }
} 