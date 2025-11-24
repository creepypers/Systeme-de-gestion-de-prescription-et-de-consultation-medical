using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class PrescriptionsByConsultation : BaseSpecification<Prescription>
    {
        public PrescriptionsByConsultation(int consultationId): base(x => x.Consultation.Id == consultationId){ }
    }
}

