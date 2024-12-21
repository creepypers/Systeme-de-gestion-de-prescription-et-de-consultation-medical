using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Session : BaseEntity, IAggregateRoot
    {
        [NotMapped]
       public int SessionId { get; set; }
        public DateTime? DateConnexion { get;  set; }
        public DateTime? DateDeconnexion { get;  set; }
        public  Medecin Medecin { get; set; }
        public int MedecinId { get; set; }
        
        public virtual List<Consultation> Consultations { get; set; } = new List<Consultation>();
        public virtual List<DossierMedical> DossierMedicals { get; set; } = new List<DossierMedical>();

        public Session()
        {
           
        }

        
       public Session(DateTime dateConnexion ,DateTime dateDeconnexion, Medecin medecin)
            {
                    DateConnexion = dateConnexion;
                    DateDeconnexion = dateDeconnexion;
                    Medecin = medecin;

       }

        public void AjouterConsultation(Consultation consultation)
        {
            Consultations.Add(consultation);
        }


        public void AjouterDossierMedical(DossierMedical dossierMedical)
        {
            DossierMedicals.Add(dossierMedical);
        }

        public void RetirerDossierMedical(DossierMedical dossierMedical)
        {
            DossierMedicals.Remove(dossierMedical);
        }

        public void AfficherFormulaireAuthentification()
        {
            // Cette méthode sera implémentée dans la couche UI
        }

        public bool ValiderAuthentification(string nomUtilisateur, string motDePasse)
        {
            if (Medecin != null)
            {
                return Medecin.Valider(nomUtilisateur, motDePasse);
            }
            return false;
        }

        public void AfficherMessageErreur(string message)
        {
            // Cette méthode sera implémentée dans la couche UI
        }

        public void AfficherFormulaireAjoutFichePatient()
        {
            // Cette méthode sera implémentée dans la couche UI
        }

        public void ConfirmerAjoutPatient()
        {
            // Cette méthode sera implémentée dans la couche UI
        }

    }
} 