using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class PrescriptionByPatient : BaseSpecification<Prescription>
    {
        public PrescriptionByPatient(int patientId) : base(x => x.Patient.Id == patientId) { }
    }
}
