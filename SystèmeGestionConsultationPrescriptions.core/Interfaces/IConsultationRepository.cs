using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IConsultationRepository : IAsyncRepository<Consultation>, IRepository<Consultation>
    {
        Task<Consultation> GetByIdWithPrescriptionsAsync(int id);
        Consultation GetByIdWithPrescriptions(int id);

        Task<Consultation> GetByIdWithDossierMedicalAsync(DossierMedical dossierMedical);
        Consultation GetByIdWithDossierMedical(DossierMedical dossierMedical);

        Task<Consultation> GetByIdWithSessionAsync(Session session);
        Consultation GetByIdWithSession(Session session);



    }
}
