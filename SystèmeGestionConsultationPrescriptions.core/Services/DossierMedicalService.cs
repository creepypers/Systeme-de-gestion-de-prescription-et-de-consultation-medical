using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class DossierMedicalService : IDossierMedicalService
    {
        private readonly IDossierMedicalRepository _dossierMedicalRepository;
        public DossierMedicalService(IDossierMedicalRepository dossierMedicalRepository) 
        {
            _dossierMedicalRepository = dossierMedicalRepository;
        }
        public async Task AddDossierMedical(DossierMedical dossier)
        {
            await _dossierMedicalRepository.AddAsync(dossier);
        }

        public async Task<DossierMedical> GetDossierMedical(int idDossier)
        {
            return await _dossierMedicalRepository.GetByIdAsync(idDossier);
        }

        public async Task UpdateDossierMedical(DossierMedical dossier)
        {
            await _dossierMedicalRepository.UpdateAsync(dossier);
        }
    }
}
