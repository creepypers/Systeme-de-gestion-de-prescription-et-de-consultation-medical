using System;
using System.Linq.Expressions;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class SessionsActivesSpec : BaseSpecification<Session>
    {
        public SessionsActivesSpec()
            : base(session => !session.DateDeconnexion.HasValue)
        {
            ApplyOrderByDescending(s => s.DateConnexion);
        }
    }

    public class SessionsByUtilisateurSpec : BaseSpecification<Session>
    {
        public SessionsByUtilisateurSpec(int utilisateurId)
            : base(session => session.IdentifiantUtilisateur == utilisateurId)
        {
            ApplyOrderByDescending(s => s.DateConnexion);
        }
    }
} 