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

      
    }
}
