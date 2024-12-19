using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;
        private readonly IAsyncRepository<Prescription> _prescriptionRepository;

        public ConsultationService(IConsultationRepository consultationRepository, IPrescriptionRepository prescriptionRepository)
        {
            _consultationRepository = consultationRepository;
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task AddConsultation(Consultation consultation)
        {
            await _consultationRepository.AddAsync(consultation);
        }

        public async Task AddPrescription(int idConsultation, Prescription prescription)
        {
            Consultation consultation = await _consultationRepository.GetByIdWithPrescriptionsAsync(idConsultation);
            if (consultation != null)
            {
                consultation.AjouterPrescription(prescription);
                await _consultationRepository.UpdateAsync(consultation);

            }
        }

        public async Task DeleteConsultation(Consultation consultation)
        {
            await _consultationRepository.DeleteAsync(consultation);
        }

        public async Task<Consultation> GetConsultation(int idConsultation)
        { 
            return await _consultationRepository.GetByIdWithPrescriptionsAsync(idConsultation);
        }

        public async Task GetPrescription(int idConsultation, Prescription prescription)
        {
            await _prescriptionRepository.GetByIdAsync(prescription.Id);
        }

        public async Task UpdateConsultation(Consultation consultation)
        {
            await _consultationRepository.UpdateAsync(consultation);
        }

        public async Task UpdatePrescription(int idConsultation, Prescription prescription)
        {
            Consultation consultation = await _consultationRepository.GetByIdAsync(idConsultation);
            if (consultation == null) return;
            Prescription? p = consultation._prescriptions?.FirstOrDefault(x => x.Id == prescription.Id);
            if (p != null)
            {
                consultation.SupprimerPrescription(p);
            }
            consultation._prescriptions?.Add(prescription);
            await _consultationRepository.UpdateAsync(consultation);  
        }
    }
}
