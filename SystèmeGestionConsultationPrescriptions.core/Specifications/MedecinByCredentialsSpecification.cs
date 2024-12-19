using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class MedecinByCredentialsSpecification : BaseSpecification<Medecin>
    {
        public MedecinByCredentialsSpecification(string nomUtilisateur, string motDePasse) 
            : base(m => m.NomUtilisateur == nomUtilisateur && m.MotDePasse == motDePasse)
        {            AddInclude(m => m.Patients);
        }
    }
} 