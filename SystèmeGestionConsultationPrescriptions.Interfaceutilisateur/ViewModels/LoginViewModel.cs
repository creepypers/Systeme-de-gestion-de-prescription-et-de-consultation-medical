using System.Windows;
using System.Windows.Input;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
                (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin()
        {
            if (Username == "admin" && Password == "admin123")
            {
                var mainWindow = new MainView();
                mainWindow.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect.", 
                    "Erreur de connexion", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
            }
        }
    }
} 