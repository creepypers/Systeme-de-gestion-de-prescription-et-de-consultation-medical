using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Medecin : Utilisateur, IAggregateRoot
    {
        [NotMapped]
        public int? IdMedecin   { get; set; }
        public string? NumeroLicence { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? NumeroTelephone { get; set; }
        public string? AdresseCourriel { get; set; }
        
        public  ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public  ICollection<Session> Sessions { get; set; } = new List<Session>();

        public void AjouterPatient(Patient patient)
        {
            Patients.Add(patient);
        }

        public void RetirerPatient(Patient patient)
        {
            Patients.Remove(patient);
        }

        public void AjouterSession(Session session)
        {
            Sessions.Add(session);
        }

        public void RetirerSession(Session session)
        {
            Sessions.Remove(session);
        }

        

        public Medecin(
            string nomUtilisateur, 
            string motDePasse,
            string numeroLicence, 
            string nom, 
            string prenom, 
            string adresse, 
            string numeroTelephone, 
            string adresseCourriel) : base(nomUtilisateur, motDePasse)
        {
            NumeroLicence = numeroLicence;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            NumeroTelephone = numeroTelephone;
            AdresseCourriel = adresseCourriel;
        }

        public Medecin() : base(string.Empty, string.Empty)
        {
        }

        public override bool Valider(string nomUtilisateur, string motDePasse)
        {
            return !string.IsNullOrEmpty(NomUtilisateur) && !string.IsNullOrEmpty(MotDePasse);
            
        }

       
       
    }
} 