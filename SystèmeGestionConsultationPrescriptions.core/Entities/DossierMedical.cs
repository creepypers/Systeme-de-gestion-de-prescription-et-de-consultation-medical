using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class DossierMedical : BaseEntity, IAggregateRoot, IObserver
    {
        [NotMapped]
        public int Identifiant { get; private set; }
        public int IdentifiantPatient { get; private set; }

        private List<Prescription> _prescriptionsActives = new List<Prescription>();
        private List<Prescription> _prescriptionsTerminees = new List<Prescription>();

        public List<Consultation> Consultations { get; private set; } = new();

        public void AjouterConsultation() {}
        public void SupprimerConsultation() {}

        public DossierMedical()
        {
            
        }
        public DossierMedical(int identifiantPatient)
        {
            IdentifiantPatient = identifiantPatient;
        }
        public void Update(object subject)
        {
            if (subject is Patient patient && patient.Id == IdentifiantPatient)
            {
                // Mise à jour des informations liées au patient
            }
            else if (subject is Prescription prescription)
            {
                if (prescription.Etat==false)
                {
                    _prescriptionsActives.Remove(prescription);
                    _prescriptionsTerminees.Add(prescription);
                }
                else
                {
                    if (!_prescriptionsActives.Contains(prescription))
                    {
                        _prescriptionsActives.Add(prescription);
                    }
                }
            }
        }

        public IReadOnlyList<Prescription> GetPrescriptionsActives() => _prescriptionsActives.AsReadOnly();
        public IReadOnlyList<Prescription> GetPrescriptionsTerminees() => _prescriptionsTerminees.AsReadOnly();
    }
} 