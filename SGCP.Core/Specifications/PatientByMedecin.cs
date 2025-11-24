using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class PatientByMedecin : BaseSpecification<Patient>
    {
        public PatientByMedecin(int medecinId) : base(x => x.Medecin.Id == medecinId) { }
    }
}
