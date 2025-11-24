using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Enums;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class DossierMedical : BaseEntity, IAggregateRoot, IObserver
    {
        [NotMapped]
        public int DossierMedicalId { get; set; }
        public DateTime DateCreation { get; set; }

        [NotMapped]
        public List<string> TraitementsPasses { get; set; } = new List<string>();

        public string TraitementsPassesString
        {
            get { return string.Join("|", TraitementsPasses); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    TraitementsPasses = value.Split('|').ToList();
                }
            }
        }

        // Relations avec Prescription et Consultation
        public  virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
        public  virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();

        // Relation one-to-one avec Patient
        public int PatientId { get; set; }
        public  Patient Patient { get; set; }
        


        // Relation one-to-many avec Consultation
        public int MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }

        public void AjouterConsultation(Consultation consultation)
        {
            Consultations.Add(consultation);
        }

        

        public void AjouterTraitement(Prescription prescription)
        {
            if (prescription.Etat == EtatPrescription.Active)
            {
                Prescriptions.Add(prescription);
                prescription.Attach(this);
            }
            else
            {
                AjouterTraitementPasse(prescription);
            }
        }

        private void AjouterTraitementPasse(Prescription prescription)
        {
            string etatStr = prescription.Etat == EtatPrescription.Terminee ? "Terminé" : "Annulé";
            string resumeTraitement = $"• Traitement de ({etatStr}) - {DateTime.Now}\n" +
                                    $"  - Médicament: {prescription.Medicament}\n" +
                                    $"  - Posologie: {prescription.Dosage}\n" +
                                    $"  - Instructions: {prescription.Instructions}";

            TraitementsPasses.Add(resumeTraitement);
            TraitementsPassesString = string.Join("|", TraitementsPasses);
        }

        

        public void Update(object subject)
        {
            if (subject is Prescription prescription)
            {
                if (prescription.Etat == EtatPrescription.Terminee)
                {
                    Prescriptions.Remove(prescription);
                    AjouterTraitementPasse(prescription);
                }
            }
           
        }

        

        public DossierMedical()
        {
        }

        public DossierMedical(DateTime dateCreation, Patient patient, Medecin medecin)
        {
            
            DateCreation = dateCreation;
            Patient = patient;
            Medecin = medecin;
        }
    }
} 