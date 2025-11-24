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

        public async Task<Session> GetByIdWithConsultationsAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Include(p => p.Consultations)
                .FirstOrDefaultAsync(p => p.Id == id)!;
        }

        public Session GetByIdWithConsultations(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Include(p => p.Consultations)
                .FirstOrDefault(p => p.Id == id)!;
        }

        public async Task<Session> GetByIdWithMedecinAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Include(p => p.Medecin)
                .FirstOrDefaultAsync(p => p.Id == id)!;
        }

        public Session GetByIdWithMedecin(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Include(p => p.Medecin)
                .FirstOrDefault(p => p.Id == id)!;
        }

        public Session GetByIdWithDossierMedical(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Include(p => p.DossierMedicals)
                .FirstOrDefault(p => p.Id == id)!;
        }

        public async Task<Session> GetByIdWithDossierMedicalAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Sessions
                .Include(p => p.DossierMedicals)
                .FirstOrDefaultAsync(p => p.Id == id)!;
        }

        public async Task<Session> CreateAsync(Session session)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Sessions.Add(session);
            await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
            return session;
        }

        

       
    }
} 