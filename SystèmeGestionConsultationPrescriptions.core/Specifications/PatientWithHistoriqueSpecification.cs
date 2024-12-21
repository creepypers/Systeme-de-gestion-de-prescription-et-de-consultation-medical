using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.Core.Specifications;

public class PatientWithHistoriqueSpecification : BaseSpecification<Patient>
{
    public PatientWithHistoriqueSpecification(int patientId)
        : base(p => p.Id == patientId)
    {
        AddInclude(p => p.DossierMedical);
        AddInclude("DossierMedical.Consultations");
        AddInclude("DossierMedical.Consultations.Prescriptions");
    }
} 