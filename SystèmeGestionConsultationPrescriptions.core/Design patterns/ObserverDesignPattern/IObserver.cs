using System;
namespace SystèmeGestionConsultationPrescriptions.Core.DesignPatterns
{
    public interface IObserver
    {
        void Update(object subject);
    }
}