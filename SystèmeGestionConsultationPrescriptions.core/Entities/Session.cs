using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Core.DesignPatterns;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
    public class Session : BaseEntity, IAggregateRoot
    {
        [NotMapped]
        public int IdSession { get; private set; }
        public DateTime DateConnexion { get; private set; }
        public DateTime? DateDeconnexion { get; set; }
        public int IdentifiantUtilisateur { get; private set; }
        private readonly IAuthenticationService? _authService;

        public Session()
        {

        }

        public Session(int identifiantUtilisateur)
        {
            IdentifiantUtilisateur = identifiantUtilisateur;
            DateConnexion = DateTime.Now;
            
        }

        public Session(IAuthenticationService authService)
        {
            _authService = authService;
            DateConnexion = DateTime.Now;
        }
    }
} 