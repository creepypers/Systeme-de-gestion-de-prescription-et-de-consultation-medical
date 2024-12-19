using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Medecin : BaseEntity, IAggregateRoot
    {
        [NotMapped]
        public int IdMedecin { get; private set; }
        public string NumeroLicence { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Adresse { get; private set; }
        public string NumeroTelephone { get; private set; }
        public string AdresseCourriel { get; private set; }
        public List<Patient> Patients { get; private set; } = new();
        public string NomUtilisateur { get; private set; }
        public string MotDePasse { get; private set; }

        public Medecin(string nomUtilisateur, string motDePasse, 
            string numeroLicence, string nom, string prenom, 
            string adresse, string numeroTelephone, string adresseCourriel) 
            
        {
            NumeroLicence = numeroLicence;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            NumeroTelephone = numeroTelephone;
            AdresseCourriel = adresseCourriel;
            Patients = new List<Patient>();
            MotDePasse = motDePasse;
            NomUtilisateur = nomUtilisateur;
        }
        public Medecin() 
        {
        }

        public bool Valider(string numeroLicence, string motDePasse)
        {
            return this.NumeroLicence == numeroLicence && this.MotDePasse == motDePasse;
        }
    }
} 