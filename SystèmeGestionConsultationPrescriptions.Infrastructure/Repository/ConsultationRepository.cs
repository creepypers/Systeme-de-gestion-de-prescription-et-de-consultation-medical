using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class ConsultationRepository : EfRepository<Consultation>, IConsultationRepository
    {
        public ConsultationRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext){ }

        public Task<Consultation> GetByIdWithPrescriptionsAsync(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                  .Include(c => c.Prescriptions)
                  .FirstOrDefaultAsync(c => c.Id == id)!;
        }

        public Consultation GetByIdWithPrescriptions(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                   .Include(c => c.Prescriptions)
                   .FirstOrDefault(c => c.Id == id)!;
        }

        public async Task<Consultation> GetByIdWithDossierMedicalAsync(DossierMedical dossierMedical)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.DossierMedical)
                .FirstOrDefaultAsync(c => c.DossierMedicalId == dossierMedical.Id)!;
        }

        public Consultation GetByIdWithDossierMedical(DossierMedical dossierMedical)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.DossierMedical)
                .FirstOrDefault(c => c.DossierMedicalId == dossierMedical.Id)!;
        }

        public async Task<Consultation> GetByIdWithSessionAsync(Session session)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Session)
                .FirstOrDefaultAsync(c => c.SessionId == session.Id)!;
        }

        public Consultation GetByIdWithSession(Session session)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Consultations
                .Include(c => c.Session)
                .FirstOrDefault(c => c.SessionId == session.Id)!;
        }
    }
}
