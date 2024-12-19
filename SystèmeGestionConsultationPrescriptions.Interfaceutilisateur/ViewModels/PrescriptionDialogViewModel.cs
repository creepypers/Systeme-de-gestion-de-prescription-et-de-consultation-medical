using System;
using System.Windows;
using System.Windows.Input;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;
using System.Linq;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class PrescriptionDialogViewModel : ViewModelBase
    {
        private string _windowTitle;
        private PatientViewModel _patient;
        private ConsultationViewModel _selectedConsultation;
        private string _medicament;
        private string _posologie;
        private string _duree;
        private string _notes;

        public event EventHandler RequestClose;

        public string WindowTitle
        {
            get => _windowTitle;
            set => SetProperty(ref _windowTitle, value);
        }

        public PatientViewModel Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        public ConsultationViewModel SelectedConsultation
        {
            get => _selectedConsultation;
            set => SetProperty(ref _selectedConsultation, value);
        }

        public string Medicament
        {
            get => _medicament;
            set
            {
                if (SetProperty(ref _medicament, value))
                {
                    (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public string Posologie
        {
            get => _posologie;
            set
            {
                if (SetProperty(ref _posologie, value))
                {
                    (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public string Duree
        {
            get => _duree;
            set
            {
                if (SetProperty(ref _duree, value))
                {
                    (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public PrescriptionDialogViewModel(PatientViewModel patient)
        {
            Patient = patient;
            WindowTitle = "Nouvelle Prescription";
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
            CancelCommand = new RelayCommand(ExecuteCancel);

            if (SelectedConsultation == null && Patient.Consultations.Any())
            {
                SelectedConsultation = Patient.Consultations.OrderByDescending(c => c.Date).First();
            }
        }

        private bool CanExecuteSave()
        {
            return SelectedConsultation != null &&
                   !string.IsNullOrWhiteSpace(Medicament) &&
                   !string.IsNullOrWhiteSpace(Posologie) &&
                   !string.IsNullOrWhiteSpace(Duree);
        }

        private void ExecuteSave()
        {
            if (SelectedConsultation == null)
            {
                MessageBox.Show("Veuillez sélectionner une consultation.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Medicament))
            {
                MessageBox.Show("Le médicament est obligatoire.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Posologie))
            {
                MessageBox.Show("La posologie est obligatoire.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Duree))
            {
                MessageBox.Show("La durée est obligatoire.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var prescription = new PrescriptionViewModel
            {
                DatePrescription = DateTime.Now,
                Medicament = this.Medicament,
                Posologie = this.Posologie,
                Duree = this.Duree,
                Etat = "En cours",
                Consultation = this.SelectedConsultation
            };

            Patient.Prescriptions.Add(prescription);
            MessageBox.Show("Prescription enregistrée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void ExecuteCancel()
        {
            var result = MessageBox.Show(
                "Voulez-vous vraiment annuler ? Les modifications non enregistrées seront perdues.",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
        }
    }
} 