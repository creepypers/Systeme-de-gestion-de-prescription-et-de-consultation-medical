using System.Windows;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class MainView : Window
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel?.SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialogViewModel = new ConsultationDialogViewModel(ViewModel.SelectedPatient);
            var dialog = new ConsultationDialogView(dialogViewModel)
            {
                Owner = this
            };

            dialog.ShowDialog();

            // Rafraîchir la liste des consultations si nécessaire
            if (ViewModel != null)
            {
                // ViewModel.RefreshConsultations();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ViewModel?.SelectedPatient == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialogViewModel = new PrescriptionDialogViewModel(ViewModel.SelectedPatient);
            var dialog = new PrescriptionDialogView(dialogViewModel)
            {
                Owner = this
            };

            dialog.ShowDialog();

            // Rafraîchir la liste des prescriptions si nécessaire
            if (ViewModel != null)
            {
                // ViewModel.RefreshPrescriptions();
            }
        }
    }
} 