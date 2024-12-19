using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class HistoriquePatientViewModel : INotifyPropertyChanged
    {
        public PatientViewModel Patient { get; }
        private ObservableCollection<ConsultationViewModel> _consultationsFiltrees;
        private ObservableCollection<PrescriptionViewModel> _prescriptionsFiltrees;
        private DateTime? _dateDebut;
        private DateTime? _dateFin;

        public HistoriquePatientViewModel(PatientViewModel patient)
        {
            Patient = patient;
            _consultationsFiltrees = new ObservableCollection<ConsultationViewModel>(patient.Consultations);
            _prescriptionsFiltrees = new ObservableCollection<PrescriptionViewModel>(patient.Prescriptions);
        }

        public DateTime? DateDebut
        {
            get => _dateDebut;
            set
            {
                _dateDebut = value;
                OnPropertyChanged(nameof(DateDebut));
                FiltrerHistorique();
            }
        }

        public DateTime? DateFin
        {
            get => _dateFin;
            set
            {
                _dateFin = value;
                OnPropertyChanged(nameof(DateFin));
                FiltrerHistorique();
            }
        }

        public ObservableCollection<ConsultationViewModel> ConsultationsFiltrees
        {
            get => _consultationsFiltrees;
            set
            {
                _consultationsFiltrees = value;
                OnPropertyChanged(nameof(ConsultationsFiltrees));
            }
        }

        public ObservableCollection<PrescriptionViewModel> PrescriptionsFiltrees
        {
            get => _prescriptionsFiltrees;
            set
            {
                _prescriptionsFiltrees = value;
                OnPropertyChanged(nameof(PrescriptionsFiltrees));
            }
        }

        private void FiltrerHistorique()
        {
            var consultations = Patient.Consultations.AsEnumerable();
            var prescriptions = Patient.Prescriptions.AsEnumerable();

            if (DateDebut.HasValue)
            {
                consultations = consultations.Where(c => c.Date >= DateDebut.Value);
                prescriptions = prescriptions.Where(p => p.DatePrescription >= DateDebut.Value);
            }

            if (DateFin.HasValue)
            {
                consultations = consultations.Where(c => c.Date <= DateFin.Value);
                prescriptions = prescriptions.Where(p => p.DatePrescription <= DateFin.Value);
            }

            ConsultationsFiltrees = new ObservableCollection<ConsultationViewModel>(consultations);
            PrescriptionsFiltrees = new ObservableCollection<PrescriptionViewModel>(prescriptions);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}