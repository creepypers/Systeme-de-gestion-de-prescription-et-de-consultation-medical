using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task AddPAtient(Patient patient)
        {
            await _patientRepository.AddAsync(patient);  
        }

        public async Task DeletePatient(Patient patient)
        {
           await _patientRepository.DeleteAsync(patient);
        }

        public async Task<Patient> GetPatient(int idPatient)
        {
            return await _patientRepository.GetByIdWithDossiersMedicauxAsync(idPatient);
        }

        public async Task UpdatePatient(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }
    }
}
