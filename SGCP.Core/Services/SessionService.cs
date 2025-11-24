using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private int _currentSessionId;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
            _currentSessionId = 0; // Valeur par défaut
        }

        public void SetCurrentSession(int sessionId)
        {
            _currentSessionId = sessionId;
        }

        // Async operations
        public async Task AddSessionAsync(Session session)
        {
            await _sessionRepository.AddAsync(session);
        }

        public async Task UpdateSessionAsync(Session session)
        {
            await _sessionRepository.UpdateAsync(session);
        }

        public async Task<Session> GetSessionByIdAsync(int idSession)
        {
            return await _sessionRepository.GetByIdAsync(idSession);
        }

        public async Task DeleteSessionAsync(Session session)
        {
            await _sessionRepository.DeleteAsync(session);
        }

        public async Task AjouterConsultationAsync(int idSession, Consultation consultation)
        {
            var session = await _sessionRepository.GetByIdAsync(idSession);
            if (session != null)
            {
                session.Consultations.Add(consultation);
                await _sessionRepository.UpdateAsync(session);
            }
        }

        public async Task<bool> ValiderAuthentificationAsync(string nomUtilisateur, string motDePasse)
        {
            var session = await _sessionRepository.GetByIdWithMedecinAsync(_currentSessionId);
            return session?.ValiderAuthentification(nomUtilisateur, motDePasse) ?? false;
        }

        public bool ValiderAuthentification(string nomUtilisateur, string motDePasse)
        {
            var session = _sessionRepository.GetByIdWithMedecin(_currentSessionId);
            return session?.ValiderAuthentification(nomUtilisateur, motDePasse) ?? false;
        }

        public async Task<Session> GetByIdWithConsultationsAsync(int id)
        {
            return await _sessionRepository.GetByIdWithConsultationsAsync(id);
        }

        public Session GetByIdWithConsultations(int id)
        {
            return _sessionRepository.GetByIdWithConsultations(id);
        }

        public async Task<Session> GetByIdWithMedecinAsync(int id)
        {
            return await _sessionRepository.GetByIdWithMedecinAsync(id);
        }

        public Session GetByIdWithMedecin(int id)
        {
            return _sessionRepository.GetByIdWithMedecin(id);
        }

        public async Task<Session> GetByIdWithDossierMedicalAsync(int id)
        {
            return await _sessionRepository.GetByIdWithDossierMedicalAsync(id);
        }

        public Session GetByIdWithDossierMedical(int id)
        {
            return _sessionRepository.GetByIdWithDossierMedical(id);
        }

        // Sync operations
        public Session AddSession(Session session)
        {
            return _sessionRepository.Add(session);
        }

        public int UpdateSession(Session session)
        {
            _sessionRepository.Update(session);
            return session.Id;
        }

        public Session GetSessionById(int idSession)
        {
            return _sessionRepository.GetById(idSession);
        }

        public int DeleteSession(Session session)
        {
            _sessionRepository.Delete(session);
            return session.Id;
        }

        // Query operations
       

       
    }
}
