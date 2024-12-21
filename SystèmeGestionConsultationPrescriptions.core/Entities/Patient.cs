using SystèmeGestionConsultationPrescriptions.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Patient : BaseEntity, IAggregateRoot
    {

        [NotMapped]
        public int PatientId { get; set; }
        public string? Nom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? Adresse { get; set; }
        public string? NumeroTelephone { get; set; }
        public string? AdresseCourriel { get; set; }
        
        public int?  MedecinId { get; set; }
        public  Medecin? Medecin { get; set; }

        public  DossierMedical?   DossierMedical { get; set; }

        public Patient(string nom, DateTime dateNaissance, 
            string adresse, string numeroTelephone, string adresseCourriel, Medecin medecin)
        {
            Nom = nom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            NumeroTelephone = numeroTelephone;
            AdresseCourriel = adresseCourriel;
            Medecin = medecin;
            
        }
        public Patient() {
    
        }

        
    }
} 