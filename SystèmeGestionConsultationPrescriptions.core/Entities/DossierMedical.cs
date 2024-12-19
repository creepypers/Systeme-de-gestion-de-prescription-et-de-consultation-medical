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

        [NotMapped]
            public List<string> TraitementsPasses { get; private set; } = new List<string>();

        // Propriété pour stocker les traitements passés dans la base de données
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
        public virtual List<Consultation> consultations { get; set; } = new List<Consultation>();
        public virtual List<Prescription> traitementActifs { get; set; } = new List<Prescription>();

        public void AjouterConsultation(Consultation consultation)
        {
            consultations.Add(consultation);
        }

        public void AjouterTraitement(Prescription prescription)
        {
            if (prescription.EstActive())
            {
                traitementActifs.Add(prescription);
            }
            else
            {
                AjouterTraitementPasse(prescription);
            }
        }

        private void AjouterTraitementPasse(Prescription prescription)
        {
            string etatStr = prescription.Etat == EtatPrescription.Terminee ? "Terminé" : "Annulé";
            string resumeTraitement = $"• Traitement du {prescription.DateDebut:dd/MM/yyyy} au {prescription.DateFin:dd/MM/yyyy} ({etatStr})\n" +
                                    $"  - Médicament: {prescription.Medicament}\n" +
                                    $"  - Posologie: {prescription.Dosage}\n" +
                                    $"  - Instructions: {prescription.Instructions}";

            TraitementsPasses.Add(resumeTraitement);
        }

        public void VerifierEtMettreAJourTraitements()
        {
            var maintenant = DateTime.Now;
            var traitementsADeplacer = traitementActifs
                .Where(t => t.DateFin < maintenant)
                .ToList();

            foreach (var traitement in traitementsADeplacer)
            {
                traitementActifs.Remove(traitement);
                traitement.ChangerEtat(EtatPrescription.Terminee);
                AjouterTraitementPasse(traitement);
            }
        }

        public void Update(object subject)
        {
            if (subject is Patient patient && patient.Id == IdentifiantPatient)
            {
                // Mise à jour des informations liées au patient
            }
            else if (subject is Prescription prescription)
            {
                switch (prescription.Etat)
                {
                    case EtatPrescription.Terminee:
                    case EtatPrescription.Annulee:
                        if (traitementActifs.Contains(prescription))
                        {
                            traitementActifs.Remove(prescription);
                            AjouterTraitementPasse(prescription);
                        }
                        break;
                }
            }
        }

        public DossierMedical()
        {
        }

        public DossierMedical(int identifiantPatient)
        {
            IdentifiantPatient = identifiantPatient;

        }
    }
} 