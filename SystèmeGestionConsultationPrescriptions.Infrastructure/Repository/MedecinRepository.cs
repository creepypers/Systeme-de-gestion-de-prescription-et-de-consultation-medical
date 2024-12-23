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
    public class MedecinRepository : EfRepository<Medecin>, IMedecinRepository
    {
        public MedecinRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsDBContext) : base(systèmeGestionConsultationPrescriptionsDBContext){ }

        public Task<Medecin> GetByIdWithPatientsAsync(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Medecins
                  .Include(m => m.Patients)
                  .FirstOrDefaultAsync(m => m.Id == id)!;
        }

        public Medecin GetByIdWithPatients(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Medecins
                   .Include(m => m.Patients)
                   .FirstOrDefault(m => m.Id == id)!;
        }

        public async Task<Medecin> GetByIdWithSessionsAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .Include(m => m.Sessions)
                .FirstOrDefaultAsync(m => m.Id == id)!;
        }

        public Medecin GetByIdWithSessions(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .Include(m => m.Sessions)
                .FirstOrDefault(m => m.Id == id)!;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(int medecinId)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .Where(m => m.Id == medecinId)
                .SelectMany(m => m.Patients)
                .ToListAsync();
        }

        public IEnumerable<Patient> GetAllPatients(int medecinId)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .Where(m => m.Id == medecinId)
                .SelectMany(m => m.Patients)
                .ToList();
        }

        public async Task<Medecin> GetByUsernameAsync(string nomUtilisateur)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Medecins
                .FirstOrDefaultAsync(m => m.NomUtilisateur == nomUtilisateur);
        }
    }
}
