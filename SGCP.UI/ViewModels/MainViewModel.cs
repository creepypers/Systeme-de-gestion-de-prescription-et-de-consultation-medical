using System.Windows.Input;
using System.Collections.ObjectModel;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;
using System.Windows;
using System;
using System.Linq;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;
using System.ComponentModel;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<PatientViewModel> _patients;
        private PatientViewModel _selectedPatient;
        private string _searchText;
        private int _selectedTabIndex;
        private PrescriptionViewModel _selectedPrescription;
        private ConsultationViewModel _selectedConsultation;
        private bool _isNewPatient;

        public ObservableCollection<PatientViewModel> Patients
        {
            get => _patients;
            set => SetProperty(ref _patients, value);
        }

        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                if (SetProperty(ref _selectedPatient, value))
                {
                    // Mettre à jour les commandes qui dépendent du patient sélectionné
                    (ModifierPatientCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (SupprimerPatientCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (ConsulterHistoriqueCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (AjouterPrescriptionCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (NouvelleConsultationCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    
                    // Si un patient est sélectionné, aller à l'onglet Fiche Patient
                    if (value != null && !IsNewPatient)
                    {
                        SelectedTabIndex = 0;
                    }
                    
                    // Forcer le rafraîchissement de toutes les propriétés liées
                    OnPropertyChanged(nameof(SelectedPatient));
                }
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    FilterPatients();
                }
            }
        }

        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set => SetProperty(ref _selectedTabIndex, value);
        }

        public PrescriptionViewModel SelectedPrescription
        {
            get => _selectedPrescription;
            set
            {
                if (SetProperty(ref _selectedPrescription, value))
                {
                    (ConsulterPrescriptionCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (CloturerPrescriptionCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public ConsultationViewModel SelectedConsultation
        {
            get => _selectedConsultation;
            set
            {
                if (SetProperty(ref _selectedConsultation, value))
                {
                    (SupprimerConsultationCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        // Commands
        public ICommand GererPatientCommand { get; private set; }
        public ICommand GererDossierMedicalCommand { get; private set; }
        public ICommand GererConsultationCommand { get; private set; }
        public ICommand GererPrescriptionCommand { get; private set; }
        public ICommand DeconnexionCommand { get; private set; }
        public ICommand AjouterPatientCommand { get; private set; }
        public ICommand ModifierPatientCommand { get; private set; }
        public ICommand SupprimerPatientCommand { get; private set; }
        public ICommand ConsulterHistoriqueCommand { get; private set; }
        public ICommand NouveauDossierCommand { get; private set; }
        public ICommand NouvelleConsultationCommand { get; private set; }
        public ICommand SupprimerConsultationCommand { get; private set; }
        public ICommand AjouterPrescriptionCommand { get; private set; }
        public ICommand ConsulterPrescriptionCommand { get; private set; }
        public ICommand CloturerPrescriptionCommand { get; private set; }
        public ICommand AjouterDossierCommand { get; private set; }
        public ICommand ModifierDossierCommand { get; private set; }
        public ICommand SupprimerDossierCommand { get; private set; }
        public ICommand SauvegarderPatientCommand { get; private set; }

        public bool IsNewPatient
        {
            get => _isNewPatient;
            set
            {
                _isNewPatient = value;
                OnPropertyChanged(nameof(IsNewPatient));
            }
        }

        private readonly SystèmeGestionConsultationPrescriptionsDBContext _context;

        public MainViewModel()
        {
            _context = new SystèmeGestionConsultationPrescriptionsDBContext();
            InitializeCommands();
            LoadPatientsFromDb();
        }

        private void InitializeCommands()
        {
            GererPatientCommand = new RelayCommand(_ => ExecuteGererPatient());
            GererDossierMedicalCommand = new RelayCommand(_ => SelectedTabIndex = 1);
            GererConsultationCommand = new RelayCommand(_ => SelectedTabIndex = 2);
            GererPrescriptionCommand = new RelayCommand(_ => SelectedTabIndex = 3);
            
            DeconnexionCommand = new RelayCommand(ExecuteDeconnexion);
            
            AjouterPatientCommand = new RelayCommand(_ => ExecuteAjouterPatient());
            ModifierPatientCommand = new RelayCommand(_ => ExecuteModifierPatient(), _ => CanExecuteModifierPatient());
            SupprimerPatientCommand = new RelayCommand(_ => ExecuteSupprimerPatient(), _ => CanExecuteSupprimerPatient());
            ConsulterHistoriqueCommand = new RelayCommand(_ => ExecuteConsulterHistorique(), _ => CanExecuteConsulterHistorique());
            
            // Autres commandes à implémenter...
            ConsulterPrescriptionCommand = new RelayCommand(ExecuteConsulterPrescription, CanExecuteConsulterPrescription);
            AjouterPrescriptionCommand = new RelayCommand(ExecuteAjouterPrescription, CanExecuteAjouterPrescription);
            CloturerPrescriptionCommand = new RelayCommand(ExecuteCloturerPrescription, CanExecuteCloturerPrescription);
            NouvelleConsultationCommand = new RelayCommand(ExecuteNouvelleConsultation, CanExecuteNouvelleConsultation);
            SupprimerConsultationCommand = new RelayCommand(ExecuteSupprimerConsultation, CanExecuteSupprimerConsultation);
            AjouterDossierCommand = new RelayCommand(ExecuteAjouterDossier, CanExecuteAjouterDossier);
            ModifierDossierCommand = new RelayCommand(ExecuteModifierDossier, CanExecuteModifierDossier);
            SupprimerDossierCommand = new RelayCommand(ExecuteSupprimerDossier, CanExecuteModifierDossier);
            SauvegarderPatientCommand = new RelayCommand(ExecuteSauvegarderPatient);
        }

        private bool CanExecuteConsulterPrescription()
        {
            return SelectedPrescription != null;
        }

        private void ExecuteConsulterPrescription()
        {
            if (SelectedPrescription == null)
            {
                MessageBox.Show("Veuillez sélectionner une prescription.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialog = new ConsulterPrescriptionDialogView(SelectedPrescription)
            {
                Owner = Application.Current.MainWindow
            };
            dialog.ShowDialog();
        }

        private bool CanExecuteAjouterPrescription()
        {
            return SelectedPatient != null;
        }

        private void ExecuteAjouterPrescription()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialogViewModel = new PrescriptionDialogViewModel(SelectedPatient);
            var dialog = new PrescriptionDialogView(dialogViewModel)
            {
                Owner = Application.Current.MainWindow
            };
            dialog.ShowDialog();
        }

        private bool CanExecuteCloturerPrescription()
        {
            return SelectedPrescription != null && 
                   SelectedPrescription.Etat == "En cours";
        }

        private void ExecuteCloturerPrescription()
        {
            if (SelectedPrescription == null)
            {
                MessageBox.Show("Veuillez sélectionner une prescription.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (SelectedPrescription.Etat != "En cours")
            {
                MessageBox.Show("Seules les prescriptions en cours peuvent être clôturées.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show(
                "Voulez-vous vraiment clôturer cette prescription ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                SelectedPrescription.Etat = "Terminée";
                SelectedPrescription.DateCloture = DateTime.Now;
                MessageBox.Show("Prescription clôturée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                (CloturerPrescriptionCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private void FilterPatients()
        {
            // TODO: Implémenter le filtrage des patients
        }

        private void ExecuteGererPatient()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            SelectedTabIndex = 0;
        }

        private void ExecuteGererDossierMedical()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            SelectedTabIndex = 1;
        }

        private void ExecuteSupprimerPatient()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Compter les éléments liés
            var nbConsultations = SelectedPatient.Consultations?.Count ?? 0;
            var nbPrescriptions = SelectedPatient.Prescriptions?.Count ?? 0;
            var nbPrescriptionsEnCours = SelectedPatient.Prescriptions?.Count(p => p.Etat == "En cours") ?? 0;

            // Construire le message de confirmation
            string message = $"Êtes-vous sûr de vouloir supprimer le patient {SelectedPatient.Nom} ?\n\n";
            message += "Cette action supprimera également :\n";
            if (nbConsultations > 0)
                message += $"- {nbConsultations} consultation(s)\n";
            if (nbPrescriptions > 0)
                message += $"- {nbPrescriptions} prescription(s)";

            if (nbPrescriptionsEnCours > 0)
            {
                message += $"\n\nATTENTION : {nbPrescriptionsEnCours} prescription(s) sont encore en cours !";
                
                // Afficher un avertissement supplémentaire
                var warningResult = MessageBox.Show(
                    "Ce patient a des prescriptions en cours. Êtes-vous sûr de vouloir continuer ?",
                    "Avertissement",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (warningResult == MessageBoxResult.No)
                    return;
            }

            var result = MessageBox.Show(
                message,
                "Confirmation de suppression",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Supprimer de la base de données
                    if (int.TryParse(SelectedPatient.Identifiant, out int patientId))
                    {
                        var patientEntity = _context.Patients.Find(patientId);
                        if (patientEntity != null)
                        {
                            _context.Patients.Remove(patientEntity);
                            _context.SaveChanges();
                        }
                    }

                    // Supprimer le patient de la liste
                    Patients.Remove(SelectedPatient);
                    
                    // Réinitialiser le patient sélectionné
                    SelectedPatient = null;

                    // Construire le message de succès
                    string successMessage = "Patient supprimé avec succès.";
                    if (nbConsultations > 0 || nbPrescriptions > 0)
                    {
                        successMessage += "\nÉléments supprimés :";
                        if (nbConsultations > 0)
                            successMessage += $"\n- {nbConsultations} consultation(s)";
                        if (nbPrescriptions > 0)
                            successMessage += $"\n- {nbPrescriptions} prescription(s)";
                        if (nbPrescriptionsEnCours > 0)
                            successMessage += $"\n  dont {nbPrescriptionsEnCours} prescription(s) en cours";
                    }

                    MessageBox.Show(successMessage, "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteNouvelleConsultation()
        {
            return SelectedPatient != null;
        }

        private void ExecuteNouvelleConsultation()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialogViewModel = new ConsultationDialogViewModel(SelectedPatient);
            var dialog = new ConsultationDialogView(dialogViewModel)
            {
                Owner = Application.Current.MainWindow
            };
            dialog.ShowDialog();
        }

        private bool CanExecuteSupprimerConsultation()
        {
            return SelectedConsultation != null;
        }

        private void ExecuteSupprimerConsultation()
        {
            if (SelectedConsultation == null)
            {
                MessageBox.Show("Veuillez sélectionner une consultation.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Vérifier s'il y a des prescriptions liées
            var prescriptionsLiees = SelectedPatient.Prescriptions
                .Where(p => p.Consultation == SelectedConsultation)
                .ToList();

            // Vérifier s'il y a des prescriptions en cours
            var prescriptionsEnCours = prescriptionsLiees
                .Where(p => p.Etat == "En cours")
                .ToList();

            string message = $"Êtes-vous sûr de vouloir supprimer cette consultation du {SelectedConsultation.Date:dd/MM/yyyy} ?";
            
            if (prescriptionsLiees.Any())
            {
                message += $"\n\nAttention : {prescriptionsLiees.Count} prescription(s) liée(s) seront également supprimée(s).";
                
                if (prescriptionsEnCours.Any())
                {
                    message += $"\n\nATTENTION : {prescriptionsEnCours.Count} prescription(s) sont encore en cours !";
                    
                    MessageBox.Show(
                        "Cette consultation contient des prescriptions en cours. " +
                        "Il est recommandé de clôturer les prescriptions avant de supprimer la consultation.",
                        "Avertissement",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }

            var result = MessageBox.Show(
                message,
                "Confirmation de suppression",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Supprimer d'abord les prescriptions liées
                foreach (var prescription in prescriptionsLiees)
                {
                    SelectedPatient.Prescriptions.Remove(prescription);
                }

                // Puis supprimer la consultation
                SelectedPatient.Consultations.Remove(SelectedConsultation);

                string successMessage = "Consultation supprimée avec succès.";
                if (prescriptionsLiees.Any())
                {
                    successMessage += $"\n{prescriptionsLiees.Count} prescription(s) liée(s) ont également été supprimée(s).";
                    if (prescriptionsEnCours.Any())
                    {
                        successMessage += $"\nDont {prescriptionsEnCours.Count} prescription(s) qui étaient encore en cours.";
                    }
                }
                
                MessageBox.Show(successMessage, "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CanExecuteAjouterDossier()
        {
            return SelectedPatient != null;
        }

        private void ExecuteAjouterDossier()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("Fonctionnalité d'ajout de dossier médical à implémenter.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanExecuteModifierDossier()
        {
            return SelectedPatient?.DossierMedical != null;
        }

        private void ExecuteModifierDossier()
        {
            if (SelectedPatient?.DossierMedical == null)
            {
                MessageBox.Show("Aucun dossier médical à modifier.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("Fonctionnalité de modification de dossier médical à implémenter.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExecuteSupprimerDossier()
        {
            if (SelectedPatient?.DossierMedical == null)
            {
                MessageBox.Show("Aucun dossier médical à supprimer.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var nbConsultations = SelectedPatient.Consultations?.Count ?? 0;
            var nbPrescriptions = SelectedPatient.Prescriptions?.Count ?? 0;
            var nbPrescriptionsEnCours = SelectedPatient.Prescriptions?.Count(p => p.Etat == "En cours") ?? 0;

            string message = "Êtes-vous sûr de vouloir supprimer le dossier médical de ce patient ?\n\n";
            message += "Cette action supprimera également :\n";
            message += $"- {nbConsultations} consultation(s)\n";
            message += $"- {nbPrescriptions} prescription(s)";

            if (nbPrescriptionsEnCours > 0)
            {
                message += $"\n\nATTENTION : {nbPrescriptionsEnCours} prescription(s) sont encore en cours !";
                
                MessageBox.Show(
                    "Ce dossier contient des prescriptions en cours. " +
                    "Il est recommandé de clôturer les prescriptions avant de supprimer le dossier.",
                    "Avertissement",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

            var result = MessageBox.Show(
                message,
                "Confirmation de suppression",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Supprimer les prescriptions
                SelectedPatient.Prescriptions?.Clear();
                
                // Supprimer les consultations
                SelectedPatient.Consultations?.Clear();
                
                // Supprimer le dossier médical
                SelectedPatient.DossierMedical = null;

                string successMessage = "Dossier médical supprimé avec succès.\n";
                successMessage += $"{nbConsultations} consultation(s) et {nbPrescriptions} prescription(s) ont été supprimées.";
                if (nbPrescriptionsEnCours > 0)
                {
                    successMessage += $"\nDont {nbPrescriptionsEnCours} prescription(s) qui étaient encore en cours.";
                }

                MessageBox.Show(successMessage, "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExecuteDeconnexion()
        {
            var result = MessageBox.Show(
                "Voulez-vous vraiment vous déconnecter ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Sauvegarder les modifications si nécessaire
                // TODO: Implémenter la sauvegarde des données

                // Créer et afficher la fenêtre de login
                var loginWindow = new LoginView
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                loginWindow.Show();

                // Fermer la fenêtre principale
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is MainView)
                    {
                        window.Close();
                    }
                }

                // Définir la fenêtre de login comme fenêtre principale
                Application.Current.MainWindow = loginWindow;
            }
        }

        private void ExecuteSauvegarderPatient()
        {
            if (SelectedPatient != null)
            {
                // Valider les données du patient
                if (ValidatePatient())
                {
                    try
                    {
                        // Ajouter le patient à la liste
                        Patients.Add(SelectedPatient);
                        
                        // Réinitialiser le flag nouveau patient
                        IsNewPatient = false;
                        
                        // Rafraîchir la liste
                        OnPropertyChanged(nameof(Patients));
                        
                        // Sauvegarder dans la base de données
                        SavePatientToDatabase(SelectedPatient);
                        
                        MessageBox.Show("Patient sauvegardé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la sauvegarde du patient : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private string GenerateUniqueId()
        {
            // Format : PAT-YYYYMMDD-XXXX
            string dateComponent = DateTime.Now.ToString("yyyyMMdd");
            string randomComponent = new Random().Next(1000, 9999).ToString();
            return $"PAT-{dateComponent}-{randomComponent}";
        }

        private bool ValidatePatient()
        {
            // Ajouter la validation des champs requis
            if (string.IsNullOrWhiteSpace(SelectedPatient.Nom))
            {
                MessageBox.Show("Le nom du patient est requis.", "Erreur de validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!SelectedPatient.DateNaissance.HasValue)
            {
                MessageBox.Show("La date de naissance est requise.", "Erreur de validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void SavePatientToDatabase(PatientViewModel patient)
        {
            try
            {
                // Implémenter la sauvegarde dans la base de données
                // _patientService.SavePatient(patient);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecuteAjouterPatient()
        {
            var dialogViewModel = new PatientDialogViewModel();
            var dialog = new PatientDialogView(dialogViewModel)
            {
                Owner = Application.Current.MainWindow
            };

            dialog.ShowDialog();

            if (dialogViewModel.Patient != null)
            {
                try
                {
                    var defaultMedecin = _context.Medecins.FirstOrDefault();
                    if (defaultMedecin == null)
                    {
                        MessageBox.Show("Aucun médecin trouvé dans la base de données. Impossible de créer un patient.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var newPatient = new Core.Entities.Patient(
                        dialogViewModel.Patient.Nom,
                        dialogViewModel.Patient.DateNaissance.GetValueOrDefault(DateTime.Now),
                        dialogViewModel.Patient.Adresse,
                        dialogViewModel.Patient.Telephone,
                        dialogViewModel.Patient.Email,
                        defaultMedecin
                    );

                    _context.Patients.Add(newPatient);
                    _context.SaveChanges();

                    // Update ViewModel with ID from DB
                    dialogViewModel.Patient.Identifiant = newPatient.Id.ToString();
                    
                    Patients.Add(dialogViewModel.Patient);
                    SelectedPatient = dialogViewModel.Patient;
                    SelectedTabIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'ajout du patient : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteModifierPatient()
        {
            return SelectedPatient != null && !IsNewPatient;
        }

        private bool CanExecuteSupprimerPatient()
        {
            return SelectedPatient != null && !IsNewPatient;
        }

        private bool CanExecuteConsulterHistorique()
        {
            return SelectedPatient != null && !IsNewPatient;
        }

        private void ExecuteConsulterHistorique()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                var viewModel = new HistoriquePatientViewModel(SelectedPatient);
                var historiqueWindow = new HistoriquePatientView(viewModel)
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                
                historiqueWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture de l'historique : {ex.Message}", 
                              "Erreur", 
                              MessageBoxButton.OK, 
                              MessageBoxImage.Error);
            }
        }

        private void ExecuteModifierPatient()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialogViewModel = new PatientDialogViewModel(SelectedPatient);
            var dialog = new PatientDialogView(dialogViewModel)
            {
                Owner = Application.Current.MainWindow
            };

            dialog.ShowDialog();

            if (dialogViewModel.Patient != null)
            {
                try
                {
                    if (int.TryParse(SelectedPatient.Identifiant, out int patientId))
                    {
                        var patientEntity = _context.Patients.Find(patientId);
                        if (patientEntity != null)
                        {
                            patientEntity.Nom = dialogViewModel.Patient.Nom;
                            patientEntity.DateNaissance = dialogViewModel.Patient.DateNaissance;
                            patientEntity.Adresse = dialogViewModel.Patient.Adresse;
                            patientEntity.NumeroTelephone = dialogViewModel.Patient.Telephone;
                            patientEntity.AdresseCourriel = dialogViewModel.Patient.Email;

                            _context.SaveChanges();

                            // Update ViewModel
                            SelectedPatient.Nom = dialogViewModel.Patient.Nom;
                            SelectedPatient.DateNaissance = dialogViewModel.Patient.DateNaissance;
                            SelectedPatient.Adresse = dialogViewModel.Patient.Adresse;
                            SelectedPatient.Telephone = dialogViewModel.Patient.Telephone;
                            SelectedPatient.Email = dialogViewModel.Patient.Email;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la modification du patient : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadPatientsFromDb()
        {
            try 
            {
                _context.Database.EnsureCreated();
                
                var patients = _context.Patients
                    .Include(p => p.DossierMedical)
                        .ThenInclude(dm => dm.Consultations)
                    .Include(p => p.DossierMedical)
                        .ThenInclude(dm => dm.Prescriptions)
                    .ToList();

                var patientViewModels = new ObservableCollection<PatientViewModel>();

                foreach (var p in patients)
                {
                    var vm = new PatientViewModel
                    {
                        Identifiant = p.Id.ToString(),
                        Nom = p.Nom ?? "Inconnu",
                        DateNaissance = p.DateNaissance,
                        Adresse = p.Adresse ?? "",
                        Telephone = p.NumeroTelephone ?? "",
                        Email = p.AdresseCourriel ?? "",
                        Consultations = new ObservableCollection<ConsultationViewModel>(),
                        Prescriptions = new ObservableCollection<PrescriptionViewModel>()
                    };

                    if (p.DossierMedical != null)
                    {
                        vm.DossierMedical = new DossierMedicalViewModel
                        {
                            // Map basic properties if needed
                        };

                        foreach (var c in p.DossierMedical.Consultations)
                        {
                            vm.Consultations.Add(new ConsultationViewModel
                            {
                                Date = c.Date,
                                Motif = c.Motif,
                                Observations = c.Observations,
                                Diagnostic = c.Diagnostic
                            });
                        }

                        foreach (var pr in p.DossierMedical.Prescriptions)
                        {
                            vm.Prescriptions.Add(new PrescriptionViewModel
                            {
                                Medicament = pr.Medicament ?? "",
                                Posologie = $"{pr.Dosage} mg - {pr.Instructions}",
                                Duree = pr.Duree.TotalDays + " jours",
                                Etat = pr.Etat.ToString()
                            });
                        }
                    }

                    patientViewModels.Add(vm);
                }

                Patients = patientViewModels;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la base de données : {ex.Message}", "Erreur DB", MessageBoxButton.OK, MessageBoxImage.Error);
                Patients = new ObservableCollection<PatientViewModel>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}