using SystèmeGestionConsultationPrescriptions.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Consultation : BaseEntity, IAggregateRoot
    {
        [NotMapped]
        public int Identifiant { get; private set; }
        public DateTime Date { get; private set; }
        public string? Motif { get; private set; }
        public string? Observations { get; private set; }
        public string? Diagnostic { get; private set; }
        public List<Prescription> Prescriptions { get; private set; } = new();
        

        public Consultation(DateTime date, string motif, 
            string observations, string diagnostic)
        {
            Date = date;
            Motif = motif;
            Observations = observations;
            Diagnostic = diagnostic;
        }
        public Consultation()
        {

        }

        public void AjouterPrescription(Prescription prescription)
        {
            Prescriptions.Add(prescription);
        }
    }
} 