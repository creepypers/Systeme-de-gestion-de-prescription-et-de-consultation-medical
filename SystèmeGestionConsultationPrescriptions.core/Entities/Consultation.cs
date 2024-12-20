using SystèmeGestionConsultationPrescriptions.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Enums;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Consultation : BaseEntity, IAggregateRoot    {
        [NotMapped]
        public int Identifiant { get; set; }
        public DateTime Date { get; set; }
        public string Motif { get; set; }
        public string Observations { get; set; }
        public string Diagnostic { get; set; }

        // Relation many-to-one avec DossierMedical
        public int DossierMedicalId { get; set; }
        public virtual DossierMedical DossierMedical { get; set; }

        // Relation many-to-one avec Session
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }

        // Relation one-to-many avec Prescription
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

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

        public void AjouterPrescription(Prescription prescription)
        {
            Prescriptions.Add(prescription);
        }


        
    }
} 