using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public enum EtatPrescription
    {
        Active,
        Terminee,
        Annulee
    }

    public class Prescription : BaseEntity, IAggregateRoot
    {
        private List<IObserver> _observers = new List<IObserver>();
    [NotMapped]
        public int Identifiant { get; private set; }
        public string? Medicament { get; private set; }
        public int Dosage { get; private set; }
        public string? Instructions { get; private set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public TimeSpan Duree { get; private set; }
        public EtatPrescription Etat { get; private set; }
        public Consultation? Consultation { get; private set; }
        public Patient Patient { get; private set; }

        public Prescription()
        {
            Etat = EtatPrescription.Active;
        }   

        public Prescription(string medicament, int dosage, 
            string instructions, TimeSpan duree, EtatPrescription etat, Consultation consultation)
        {
            Medicament = medicament;
            Dosage = dosage;
            Instructions = instructions;
            Duree = duree;
            Etat = etat;
            Consultation = consultation;
        }

        public void ChangerEtat(EtatPrescription nouvelEtat)
        {
            Etat = nouvelEtat;
            Notify();
        }

        public bool EstActive()
        {
            return Etat == EtatPrescription.Active;
        }

        public void AjouterConsultation(Consultation consultation)
        {
            Consultation = consultation;
        }

        public void RetirerConsultation(Consultation consultation)
        {
            Consultation = null;
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

        public void DefinirPeriode(DateTime dateDebut, DateTime dateFin)
        {
            if (dateFin <= dateDebut)
            {
                throw new ArgumentException("La date de fin doit être postérieure à la date de début");
            }

            DateDebut = dateDebut;
            DateFin = dateFin;
            Duree = dateFin - dateDebut;
        }
    }

} 