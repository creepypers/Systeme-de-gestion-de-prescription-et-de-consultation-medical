using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Interfaces
{
    public interface IPatientService
    {
        Task AddPAtient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task<Patient> GetPatient(int idPatient);
        Task DeletePatient(Patient patient);

    }
}
