using SystèmeGestionConsultationPrescriptions.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Patient : BaseEntity, IAggregateRoot,ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        [NotMapped]
        public int Identifiant { get; private set; }
        public string? Nom { get; private set; }
        public DateTime? DateNaissance { get; private set; }
        public string? Adresse { get; private set; }
        public string? NumeroTelephone { get; private set; }
        public string? AdresseCourriel { get; private set; }
        
        public Medecin? Medecin { get; private set; }

        public DossierMedical? DossierMedical { get; private set; }

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

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void AssignerDossierMedical(DossierMedical dossierMedical)
        {
            DossierMedical = dossierMedical;
        }
    }
} 