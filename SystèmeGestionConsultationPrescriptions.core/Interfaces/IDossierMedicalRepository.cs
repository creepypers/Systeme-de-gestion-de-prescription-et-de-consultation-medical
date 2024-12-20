using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IDossierMedicalRepository : IAsyncRepository<DossierMedical>, IRepository<DossierMedical>
    {
      
        
        Task<DossierMedical> GetByPatientIdAsync(int patientId);
        DossierMedical GetByPatientId(int patientId);

        Task<DossierMedical> GetByIdWithConsultationsAsync(int id);
        DossierMedical GetByIdWithConsultations(int id);

        Task<DossierMedical> GetByIdWithPrescriptionsAsync(int id);
        DossierMedical GetByIdWithPrescriptions(int id);


       



        

        

        

        
    }
}