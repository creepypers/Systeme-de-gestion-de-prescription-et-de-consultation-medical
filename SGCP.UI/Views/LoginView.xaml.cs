using System.Windows;
using System.Windows.Controls;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using SystèmeGestionConsultationPrescriptions.Core.Services;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            
            // Manual Dependency Injection
            var context = new SystèmeGestionConsultationPrescriptionsDBContext();
            var medecinRepository = new MedecinRepository(context);
            var sessionRepository = new SessionRepository(context);
            var authService = new AuthenticationService(sessionRepository, medecinRepository);

            DataContext = new LoginViewModel(authService);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
} 