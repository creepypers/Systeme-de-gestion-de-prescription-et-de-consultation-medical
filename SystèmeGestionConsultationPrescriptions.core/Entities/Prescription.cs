using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Prescription : BaseEntity, ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
[NotMapped]
        public int Identifiant { get; private set; }
        public string? Medicament { get; private set; }
        public int Dosage { get; private set; }
        public string? Instructions { get; private set; }
        public DateTime Duree { get; private set; }
        public bool Etat { get; private set; }
        public Consultation? Consultation { get; private set; }

        public Prescription()
        {

        }

        public Prescription(string medicament, int dosage, 
            string instructions, DateTime duree)
        {
            Medicament = medicament;
            Dosage = dosage;
            Instructions = instructions;
            Duree = duree;
            Etat = true;
        }

        public void ChangerEtat(bool nouvelEtat)
        {
            Etat = nouvelEtat;
            Notify();
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
    }

} 