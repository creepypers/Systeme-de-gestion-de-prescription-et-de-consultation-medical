using System;
using System.Linq.Expressions;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class DossierMedicalWithPrescriptionsSpec : BaseSpecification<DossierMedical>
    {
        public DossierMedicalWithPrescriptionsSpec(int dossierMedicalId)
            : base(dossier => dossier.Id == dossierMedicalId)
        {
            AddInclude(d => d.GetPrescriptionsActives());
            AddInclude(d => d.GetPrescriptionsTerminees());
        }
    }

    public class DossierMedicalByPatientSpec : BaseSpecification<DossierMedical>
    {
        public DossierMedicalByPatientSpec(int patientId)
            : base(dossier => dossier.IdentifiantPatient == patientId)
        {
            ApplyOrderByDescending(d => d.Id);
        }
    }
} 