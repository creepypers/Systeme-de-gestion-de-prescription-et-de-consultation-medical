using System;
using System.Linq.Expressions;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class PrescriptionsActivesSpec : BaseSpecification<Prescription>
    {
        public PrescriptionsActivesSpec()
            : base(prescription => prescription.Etat == true)
        {
            ApplyOrderByDescending(p => p.Duree);
        }
    }

    public class PrescriptionsByConsultationSpec : BaseSpecification<Prescription>
    {
        public PrescriptionsByConsultationSpec(int consultationId)
            : base(prescription => prescription.Consultation != null && prescription.Consultation.Id == consultationId)
        {
            ApplyOrderByDescending(p => p.Duree);
        }
    }
} 