using System.Windows;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;
using System.Threading;
using System.Globalization;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class ConsultationDialogView : Window
    {
        public ConsultationDialogView(ConsultationDialogViewModel viewModel)
        {
            // Définir la culture française


            InitializeComponent();
            DataContext = viewModel;

            if (viewModel != null)
            {
                viewModel.RequestClose += (s, e) => Close();
            }
        }
    }
} 