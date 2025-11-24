using System.ComponentModel.DataAnnotations.Schema;
using SystèmeGestionConsultationPrescriptions.SharedKernel;

namespace SystèmeGestionConsultationPrescriptions.Core.Entities
{
  
    public abstract class Utilisateur : BaseEntity
    {
        
        
        public int Identifiant { get; private set; }
        public string NomUtilisateur { get; private set; }
        public string MotDePasse { get; private set; }

        public Utilisateur(string nomUtilisateur, string motDePasse)
        {
            NomUtilisateur = nomUtilisateur;
            MotDePasse = motDePasse;
        }

        public abstract bool Valider(string nomUtilisateur, string motDePasse);
        
    }
} 