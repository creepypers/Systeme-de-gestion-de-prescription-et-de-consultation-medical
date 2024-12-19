using SystèmeGestionConsultationPrescriptions.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Consultation : BaseEntity, IAggregateRoot
    {
        [NotMapped]
        public int Identifiant { get; private set; }
        public DateTime Date { get; private set; }
        public string Motif { get; private set; }
        public string Observations { get; private set; }
        public string Diagnostic { get; private set; }

        // Relation many-to-one avec DossierMedical
        public int DossierMedicalId { get; private set; }
        public DossierMedical DossierMedical { get; private set; }

        // Relation many-to-one avec Medecin
        public int MedecinId { get; private set; }
        public Medecin Medecin { get; private set; }

        // Relation one-to-many avec Prescription
        public virtual List<Prescription> _prescriptions { get; set; } = new List<Prescription>();

        public Consultation(DateTime date, string motif, 
            string observations, string diagnostic)
        {
            Date = date;
            Motif = motif;
            Observations = observations;
            Diagnostic = diagnostic;
        }
        public Consultation()
        {

        }

        public void AjouterPrescription(Prescription _prescription)
        {
            _prescriptions.Add(_prescription);
        }

        public void SupprimerPrescription(Prescription _prescription)
        {
            _prescriptions.Remove(_prescription);
        }
    }
} 