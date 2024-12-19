using System;
using System.Linq.Expressions;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class ConsultationsByDateSpec : BaseSpecification<Consultation>
    {
        public ConsultationsByDateSpec(DateTime date) 
            : base(consultation => consultation.Date.Date == date.Date)
        {
            AddInclude(c => c.Prescriptions);
            ApplyOrderBy(consultation => consultation.Date);
        }
    }

    public class ConsultationsWithPrescriptionsSpec : BaseSpecification<Consultation>
    {
        public ConsultationsWithPrescriptionsSpec() 
            : base(_ => true)
        {
            AddInclude(c => c.Prescriptions);
            ApplyOrderByDescending(c => c.Date);
        }
    }
} 