using System;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class PrescriptionViewModel : ViewModelBase
    {
        private DateTime _datePrescription;
        private string _medicament;
        private string _posologie;
        private string _duree;
        private string _etat;
        private DateTime? _dateCloture;
        private ConsultationViewModel _consultation;

        public DateTime DatePrescription
        {
            get => _datePrescription;
            set => SetProperty(ref _datePrescription, value);
        }

        public string Medicament
        {
            get => _medicament;
            set => SetProperty(ref _medicament, value);
        }

        public string Posologie
        {
            get => _posologie;
            set => SetProperty(ref _posologie, value);
        }

        public string Duree
        {
            get => _duree;
            set => SetProperty(ref _duree, value);
        }

        public string Etat
        {
            get => _etat;
            set => SetProperty(ref _etat, value);
        }

        public DateTime? DateCloture
        {
            get => _dateCloture;
            set => SetProperty(ref _dateCloture, value);
        }

        public ConsultationViewModel Consultation
        {
            get => _consultation;
            set => SetProperty(ref _consultation, value);
        }
    }
} 