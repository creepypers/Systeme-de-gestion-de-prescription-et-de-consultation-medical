using System;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class DossierMedicalViewModel : ViewModelBase
    {
        private string _groupeSanguin;
        private string _allergies;
        private string _antecedents;
        private string _notes;

        public string GroupeSanguin
        {
            get => _groupeSanguin;
            set => SetProperty(ref _groupeSanguin, value);
        }

        public string Allergies
        {
            get => _allergies;
            set => SetProperty(ref _allergies, value);
        }

        public string Antecedents
        {
            get => _antecedents;
            set => SetProperty(ref _antecedents, value);
        }

        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }
    }
} 