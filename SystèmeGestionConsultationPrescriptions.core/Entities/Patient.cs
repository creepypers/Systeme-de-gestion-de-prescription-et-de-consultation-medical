using SystèmeGestionConsultationPrescriptions.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Patient : BaseEntity, IAggregateRoot
    {
        public List<IObserver> _observers = new List<IObserver>();

        [NotMapped]
        public int Identifiant { get; set; }
        public string? Nom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? Adresse { get; set; }
        public string? NumeroTelephone { get; set; }
        public string? AdresseCourriel { get; set; }
        
        public int?  MedecinId { get; set; }
        public  Medecin? Medecin { get; set; }

        public  DossierMedical?   DossierMedical { get; set; }

        public Patient(string nom, DateTime dateNaissance, 
            string adresse, string numeroTelephone, string adresseCourriel, Medecin medecin, DossierMedical dossierMedical)
        {
            Nom = nom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            NumeroTelephone = numeroTelephone;
            AdresseCourriel = adresseCourriel;
            Medecin = medecin;
            DossierMedical = dossierMedical;
        }
        public Patient() {
    
        }

        
    }
} 