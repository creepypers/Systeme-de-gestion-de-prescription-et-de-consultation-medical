using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SystèmeGestionConsultationPrescriptions.Core.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;
        private readonly IDossierMedicalRepository _dossierMedicalRepository;
        private readonly ISessionRepository _sessionRepository;
        public ConsultationService(
            IConsultationRepository consultationRepository,
            IDossierMedicalRepository dossierMedicalRepository,
            ISessionRepository sessionRepository)
        {
            _consultationRepository = consultationRepository ?? throw new ArgumentNullException(nameof(consultationRepository));
            _dossierMedicalRepository = dossierMedicalRepository ?? throw new ArgumentNullException(nameof(dossierMedicalRepository));
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }

        // Opérations asynchrones
        public async Task AddConsultationAsync(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));

            var dossierMedical = await _dossierMedicalRepository.GetByIdAsync(consultation.DossierMedicalId);
            if (dossierMedical == null)
                throw new InvalidOperationException($"Le dossier médical avec l'ID {consultation.DossierMedicalId} n'existe pas.");

            await _consultationRepository.AddAsync(consultation);
        }

        public async Task<Consultation> GetConsultationByIdAsync(int idConsultation)
        {
            return await _consultationRepository.GetByIdAsync(idConsultation);
        }

        public async Task UpdateConsultationAsync(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));

            await _consultationRepository.UpdateAsync(consultation);
        }

        public async Task DeleteConsultationAsync(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));
                
            await _consultationRepository.DeleteAsync(consultation);
        }


 

        // Opérations synchrones
        public Consultation AddConsultation(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));

            var dossierMedical = _dossierMedicalRepository.GetById(consultation.DossierMedicalId);
            if (dossierMedical == null)
                throw new InvalidOperationException($"Le dossier médical avec l'ID {consultation.DossierMedicalId} n'existe pas.");

            return _consultationRepository.Add(consultation);
        }

        public Consultation GetConsultationById(int idConsultation)
        {
            return _consultationRepository.GetById(idConsultation);
        }

        public int UpdateConsultation(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));

            _consultationRepository.Update(consultation);
            return consultation.Id;
        }

        public int DeleteConsultation(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));
                
            _consultationRepository.Delete(consultation);
            return consultation.Id;
        }

 

 

        public async Task AddPrescriptionAsync(int consultationId, Prescription prescription)
        {
            var consultation = await _consultationRepository.GetByIdAsync(consultationId);
            if (consultation == null)
                throw new InvalidOperationException($"La consultation avec l'ID {consultationId} n'existe pas.");
                
            consultation.Prescriptions.Add(prescription);
            await _consultationRepository.UpdateAsync(consultation);
        }

        public async Task UpdatePrescriptionAsync(int consultationId, Prescription prescription)
        {
            var consultation = await _consultationRepository.GetByIdAsync(consultationId);
            if (consultation == null)
                throw new InvalidOperationException($"La consultation avec l'ID {consultationId} n'existe pas.");
                
            // Mettre à jour la prescription existante
            await _consultationRepository.UpdateAsync(consultation);
        }

        public List<Consultation> GetConsultations(bool includeInactive = false)
        {
            return _consultationRepository.ListAll().ToList();
        }

        public async Task<Consultation> GetByIdWithPrescriptionsAsync(int id)
        {
            return await _consultationRepository.GetByIdWithPrescriptionsAsync(id);
        }

        public Consultation GetByIdWithPrescriptions(int id)
        {
            return _consultationRepository.GetByIdWithPrescriptions(id);
        }

        public async Task<Consultation> GetByIdWithDossierMedicalAsync(DossierMedical dossierMedical)
        {
            return await _consultationRepository.GetByIdWithDossierMedicalAsync(dossierMedical);
        }

        public Consultation GetByIdWithDossierMedical(DossierMedical dossierMedical)
        {
            return _consultationRepository.GetByIdWithDossierMedical(dossierMedical);
        }

        public async Task<Consultation> GetByIdWithSessionAsync(Session session)
        {
            return await _consultationRepository.GetByIdWithSessionAsync(session);
        }

        public Consultation GetByIdWithSession(Session session)
        {
            return _consultationRepository.GetByIdWithSession(session);
        }

        public async Task ChangerEtatPrescriptionAsync(int idConsultation, int idPrescription)
        {
            var consultation = await _consultationRepository.GetByIdWithPrescriptionsAsync(idConsultation);
            if (consultation != null)
            {
                var prescription = consultation.Prescriptions.FirstOrDefault(p => p.Id == idPrescription);
                if (prescription != null)
                {
                    prescription.changerEtatPrescription();
                    await _consultationRepository.UpdateAsync(consultation);
                }
            }
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync(int consultationId)
        {
            return await _consultationRepository.GetAllPrescriptionsAsync(consultationId);
        }

        public IEnumerable<Prescription> GetAllPrescriptions(int consultationId)
        {
            return _consultationRepository.GetAllPrescriptions(consultationId);
        }
    }
}
