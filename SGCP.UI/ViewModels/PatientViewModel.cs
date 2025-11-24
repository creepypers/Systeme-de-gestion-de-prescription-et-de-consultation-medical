using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        private string _identifiant;
        private string _nom;
        private DateTime? _dateNaissance;
        private string _adresse;
        private string _telephone;
        private string _email;
        private DossierMedicalViewModel _dossierMedical;
        private ObservableCollection<ConsultationViewModel> _consultations;
        private ObservableCollection<PrescriptionViewModel> _prescriptions;

        public string Identifiant
        {
            get => _identifiant;
            set
            {
                if (_identifiant != value)
                {
                    _identifiant = value;
                    OnPropertyChanged(nameof(Identifiant));
                }
            }
        }

        public string Nom
        {
            get => _nom;
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }

        public DateTime? DateNaissance
        {
            get => _dateNaissance;
            set
            {
                if (_dateNaissance != value)
                {
                    _dateNaissance = value;
                    OnPropertyChanged(nameof(DateNaissance));
                }
            }
        }

        public string Adresse
        {
            get => _adresse;
            set
            {
                if (_adresse != value)
                {
                    _adresse = value;
                    OnPropertyChanged(nameof(Adresse));
                }
            }
        }

        public string Telephone
        {
            get => _telephone;
            set
            {
                if (_telephone != value)
                {
                    _telephone = value;
                    OnPropertyChanged(nameof(Telephone));
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public DossierMedicalViewModel DossierMedical
        {
            get => _dossierMedical;
            set
            {
                if (_dossierMedical != value)
                {
                    _dossierMedical = value;
                    OnPropertyChanged(nameof(DossierMedical));
                }
            }
        }

        public ObservableCollection<ConsultationViewModel> Consultations
        {
            get => _consultations;
            set
            {
                if (_consultations != value)
                {
                    _consultations = value;
                    OnPropertyChanged(nameof(Consultations));
                }
            }
        }

        public ObservableCollection<PrescriptionViewModel> Prescriptions
        {
            get => _prescriptions;
            set
            {
                if (_prescriptions != value)
                {
                    _prescriptions = value;
                    OnPropertyChanged(nameof(Prescriptions));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PatientViewModel()
        {
            Consultations = new ObservableCollection<ConsultationViewModel>();
            Prescriptions = new ObservableCollection<PrescriptionViewModel>();
        }
    }
} 