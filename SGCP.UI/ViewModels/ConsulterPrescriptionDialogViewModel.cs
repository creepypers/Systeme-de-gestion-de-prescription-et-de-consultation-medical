using System;
using System.Windows.Input;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class ConsulterPrescriptionDialogViewModel : ViewModelBase
    {
        private readonly PrescriptionViewModel _prescription;
        public event EventHandler RequestClose;

        public DateTime DatePrescription => _prescription.DatePrescription;
        public string Medicament => _prescription.Medicament;
        public string Posologie => _prescription.Posologie;
        public string Duree => _prescription.Duree;
        public string Etat => _prescription.Etat;
        public ConsultationViewModel Consultation => _prescription.Consultation;

        public ICommand CloseCommand { get; }

        public ConsulterPrescriptionDialogViewModel(PrescriptionViewModel prescription)
        {
            _prescription = prescription ?? throw new ArgumentNullException(nameof(prescription));
            CloseCommand = new RelayCommand(_ => RequestClose?.Invoke(this, EventArgs.Empty));
        }
    }
} 