using System;
using System.Windows.Input;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class PatientDialogViewModel : ViewModelBase
    {
        private PatientViewModel _patient;
        private string _windowTitle;

        public PatientViewModel Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        public string WindowTitle
        {
            get => _windowTitle;
            set => SetProperty(ref _windowTitle, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler? RequestClose;

        public PatientDialogViewModel(PatientViewModel? patient = null)
        {
            if (patient != null)
            {
                // Mode modification : on crée une copie pour ne pas modifier l'original directement
                Patient = new PatientViewModel
                {
                    Identifiant = patient.Identifiant,
                    Nom = patient.Nom,
                    DateNaissance = patient.DateNaissance,
                    Adresse = patient.Adresse,
                    Telephone = patient.Telephone,
                    Email = patient.Email,
                    DossierMedical = patient.DossierMedical, // Attention : référence partagée
                    Consultations = patient.Consultations,
                    Prescriptions = patient.Prescriptions
                };
                WindowTitle = "Modifier un patient";
            }
            else
            {
                // Mode création
                Patient = new PatientViewModel
                {
                    Identifiant = GenerateTempId(), // Sera remplacé par la DB ou logique métier
                    DateNaissance = DateTime.Now
                };
                WindowTitle = "Nouveau patient";
            }

            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        private string GenerateTempId()
        {
            return "P" + DateTime.Now.Ticks.ToString().Substring(10);
        }

        private bool CanExecuteSave()
        {
            return !string.IsNullOrWhiteSpace(Patient.Nom);
        }

        private void ExecuteSave()
        {
            // Ici, la logique de validation ou de sauvegarde finale est déléguée à l'appelant
            // via la récupération de l'objet Patient modifié.
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void ExecuteCancel()
        {
            Patient = null; // Indique l'annulation
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
