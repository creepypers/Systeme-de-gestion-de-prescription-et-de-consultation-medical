using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications
{
    public class PatientSearchSpecification : BaseSpecification<Patient>
    {
        public PatientSearchSpecification(string searchTerm) : base(patient => patient.Nom != null && patient.Nom.Contains(searchTerm)) { }
    }
}

