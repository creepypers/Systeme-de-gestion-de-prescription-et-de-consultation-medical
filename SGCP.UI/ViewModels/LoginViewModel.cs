using System.Windows;
using System.Windows.Input;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Commands;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views;
using SystèmeGestionConsultationPrescriptions.core.Interfaces;
using System;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
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

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void ExecuteLogin()
        {
            try
            {
                var medecin = await _authenticationService.AuthenticateAsync(Username, Password);

                if (medecin != null)
                {
                    await _authenticationService.CreateSessionAsync(medecin.Id);

                    var mainWindow = new MainView();
                    mainWindow.Show();
                    
                    // Close the current window (LoginView)
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is LoginView)
                        {
                            window.Close();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect.", 
                        "Erreur de connexion", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 