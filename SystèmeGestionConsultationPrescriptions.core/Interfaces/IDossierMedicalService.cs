using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IDossierMedicalService
    {
        Task AddDossierMedical(DossierMedical dossier);
        Task UpdateDossierMedical(DossierMedical dossier);
        Task<DossierMedical> GetDossierMedical(int idDossier);
    }
}
