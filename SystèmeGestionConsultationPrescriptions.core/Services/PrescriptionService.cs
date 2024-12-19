using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConsultationsEtPrescriptions.Core.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task AddPrescription(Prescription prescription)
        {
            await _prescriptionRepository.AddAsync(prescription);
        }

        public Task CloturePrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePrescription(Prescription prescription)
        {
            await _prescriptionRepository.DeleteAsync(prescription);
        }

        public async Task<Prescription> GetPrescription(int idPrescription)
        {
            return await _prescriptionRepository.GetByIdWithConsultationsAsync(idPrescription);
        }

        public async Task UpdatePrescription(Prescription prescription)
        {
            await _prescriptionRepository.UpdateAsync(prescription);
        }
    }
}
