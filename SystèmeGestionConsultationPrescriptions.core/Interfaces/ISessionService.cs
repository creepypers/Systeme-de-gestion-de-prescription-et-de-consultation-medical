using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface ISessionService
    {
        // Async operations
        Task AddSessionAsync(Session session);
        Task UpdateSessionAsync(Session session);
        Task<Session> GetSessionByIdAsync(int idSession);
        Task DeleteSessionAsync(Session session);
        Task AjouterConsultationAsync(int idSession, Consultation consultation);
        Task<bool> ValiderAuthentificationAsync(string nomUtilisateur, string motDePasse);
        
        // Sync operations
        Session AddSession(Session session);
        int UpdateSession(Session session);
        Session GetSessionById(int idSession);
        int DeleteSession(Session session);
        bool ValiderAuthentification(string nomUtilisateur, string motDePasse);
        
        // Query operations
       Task<Session> GetByIdWithConsultationsAsync(int id);
        Session GetByIdWithConsultations(int id);


        Task<Session> GetByIdWithMedecinAsync(int id);
        Session GetByIdWithMedecin(int id);

        Task<Session> GetByIdWithDossierMedicalAsync(int id);
        Session GetByIdWithDossierMedical(int id);
    }
}
