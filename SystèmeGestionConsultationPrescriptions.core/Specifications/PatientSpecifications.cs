using System;
using System.Linq.Expressions;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class PatientsByMedecinSpec : BaseSpecification<Patient>
    {
        public PatientsByMedecinSpec(int medecinId)
            : base(patient => patient.IdMedecin == medecinId)
        {
            ApplyOrderBy(patient => patient.Nom ?? string.Empty);
        }
    }

    public class PatientsByNomSpec : BaseSpecification<Patient>
    {
        public PatientsByNomSpec(string searchTerm)
            : base(patient => patient.Nom != null && patient.Nom.Contains(searchTerm))
        {
            ApplyOrderBy(patient => patient.Nom ?? string.Empty);
        }
    }
} 