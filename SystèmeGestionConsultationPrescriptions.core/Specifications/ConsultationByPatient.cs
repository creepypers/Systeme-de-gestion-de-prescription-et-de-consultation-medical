using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class ConsultationByPatient : BaseSpecification<Consultation>
    {
        public ConsultationByPatient(int patientId) : base(x => x.DossierMedical.IdentifiantPatient == patientId){ }
    }
}
