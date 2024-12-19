using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Session : BaseEntity
    {
       
        public DateTime? DateConnexion { get; private set; }
        public DateTime? DateDeconnexion { get; private set; }

        // Relation avec les consultations
        [NotMapped]
        public virtual List<Consultation> _consultations { get; set; } = new List<Consultation>();

        public Session()
        {
           
        }

        
       public Session(DateTime dateConnexion ,DateTime dateDeconnexion)
       {
            DateConnexion = dateConnexion;
            DateDeconnexion = dateDeconnexion;

       }

        public void AjouterConsultation(Consultation consultation)
        {
            _consultations.Add(consultation);
        }

        public void RetirerConsultation(Consultation consultation)
        {
            _consultations.Remove(consultation);
        }

    }
} 