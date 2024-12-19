using System;
namespace SystèmeGestionConsultationPrescriptions.Core.DesignPatterns
{
    public interface ISubject
    {
        public void Attach(IObserver o);
        public void Detach(IObserver o);
        public void Notify();

    }
}