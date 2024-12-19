using System;
using System.Windows;
using System.Windows.Input;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class ConsultationDialogViewModel : ViewModelBase
    {
        private DateTime _date = DateTime.Now;
        private string _motif;
        private string _observations;
        private string _diagnostic;
        private PatientViewModel _patient;

        public event EventHandler RequestClose;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public string Motif
        {
            get => _motif;
            set
            {
                if (SetProperty(ref _motif, value))
                {
                    (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public string Observations
        {
            get => _observations;
            set => SetProperty(ref _observations, value);
        }

        public string Diagnostic
        {
            get => _diagnostic;
            set => SetProperty(ref _diagnostic, value);
        }

        public PatientViewModel Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public ConsultationDialogViewModel(PatientViewModel patient)
        {
            Patient = patient;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        private bool CanExecuteSave()
        {
            return !string.IsNullOrWhiteSpace(Motif);
        }

        private void ExecuteSave()
        {
            if (string.IsNullOrWhiteSpace(Motif))
            {
                MessageBox.Show("Le motif de la consultation est obligatoire.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var consultation = new ConsultationViewModel
            {
                Date = this.Date,
                Motif = this.Motif,
                Observations = this.Observations,
                Diagnostic = this.Diagnostic
            };

            Patient.Consultations.Add(consultation);
            MessageBox.Show("Consultation enregistrée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

            // Demander si l'utilisateur veut ajouter une prescription
            var result = MessageBox.Show(
                "Voulez-vous ajouter une prescription pour cette consultation ?",
                "Ajouter une prescription",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var prescriptionViewModel = new PrescriptionDialogViewModel(Patient)
                {
                    // Pré-remplir la consultation associée
                    SelectedConsultation = consultation
                };

                var prescriptionDialog = new PrescriptionDialogView(prescriptionViewModel)
                {
                    Owner = Application.Current.MainWindow
                };

                RequestClose?.Invoke(this, EventArgs.Empty); // Fermer la fenêtre de consultation
                prescriptionDialog.ShowDialog();
            }
            else
            {
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
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