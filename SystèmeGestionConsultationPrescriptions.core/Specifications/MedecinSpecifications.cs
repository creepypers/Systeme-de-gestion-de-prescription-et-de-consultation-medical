using System;
using System.Linq.Expressions;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class MedecinWithPatientsSpec : BaseSpecification<Medecin>
    {
        public MedecinWithPatientsSpec(int medecinId)
            : base(medecin => medecin.Id == medecinId)
        {
            AddInclude(m => m.Patients);
        }
    }

    public class MedecinByNumeroLicenceSpec : BaseSpecification<Medecin>
    {
        public MedecinByNumeroLicenceSpec(string numeroLicence)
            : base(medecin => medecin.NumeroLicence == numeroLicence)
        {
        }
    }
} 