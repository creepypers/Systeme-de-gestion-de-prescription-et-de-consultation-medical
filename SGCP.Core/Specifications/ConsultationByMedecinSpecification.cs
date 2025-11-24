
namespace SystèmeGestionConsultationPrescriptions.Core.Specifications;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

public class ConsultationByMedecinSpecification : BaseSpecification<Consultation>
{
    public ConsultationByMedecinSpecification(int medecinId)
        : base(c => c.Session.Medecin.Id == medecinId)
    {
        AddInclude(c => c.Session);
        AddInclude(c => c.Prescriptions);
        ApplyOrderByDescending(c => c.Date);
    }

    // Surcharge pour ajouter la pagination
    public ConsultationByMedecinSpecification(int medecinId, int skip, int take)
        : this(medecinId)
    {
        ApplyPaging(skip, take);
    }
} 