using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class SessionRepository : EfRepository<Session>, ISessionRepository
    {
        public SessionRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext)
        {
        }

        public async Task<Session> GetActiveSessionByUtilisateurIdAsync(int utilisateurId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .FirstOrDefaultAsync(s => s.IdentifiantUtilisateur == utilisateurId && !s.DateDeconnexion.HasValue);
        }

        public Session GetActiveSessionByUtilisateurId(int utilisateurId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .FirstOrDefault(s => s.IdentifiantUtilisateur == utilisateurId && !s.DateDeconnexion.HasValue);
        }

        public async Task<IEnumerable<Session>> GetSessionHistoryByUtilisateurIdAsync(int utilisateurId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Where(s => s.IdentifiantUtilisateur == utilisateurId)
                .OrderByDescending(s => s.DateConnexion)
                .ToListAsync();
        }

        public IEnumerable<Session> GetSessionHistoryByUtilisateurId(int utilisateurId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Where(s => s.IdentifiantUtilisateur == utilisateurId)
                .OrderByDescending(s => s.DateConnexion)
                .ToList();
        }
    }
} 