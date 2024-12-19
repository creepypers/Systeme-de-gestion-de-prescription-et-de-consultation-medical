using System.Windows;
using System.Windows.Controls;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
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