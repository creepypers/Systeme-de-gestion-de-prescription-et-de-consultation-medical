using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Enums;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Prescription : BaseEntity,ISubject
    {   [NotMapped]
        private readonly List<IObserver> _observers = new List<IObserver>();
        [NotMapped]
        public int PrescriptionId { get; set; }
        public string? Medicament { get; set; }
        public int Dosage { get; set; }
        public string? Instructions { get; set; }
        public TimeSpan Duree { get; set; }
        public EtatPrescription Etat { get; set; }
        public Consultation? Consultation { get; set; }
        public int ConsultationId { get; set; }

        public Prescription()
        {
        }   

        public Prescription(string medicament, int dosage, 
            string instructions, TimeSpan duree, Consultation consultation)
        {
            Medicament = medicament;
            Dosage = dosage;
            Instructions = instructions;
            Duree = duree;
            Etat = EtatPrescription.Active;
            Consultation = consultation;
        }

        public void changerEtatPrescription()
        {
            Etat = EtatPrescription.Terminee;
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