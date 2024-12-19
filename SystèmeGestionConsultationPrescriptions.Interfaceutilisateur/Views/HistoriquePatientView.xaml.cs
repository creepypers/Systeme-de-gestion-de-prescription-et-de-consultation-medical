using System.Windows;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class HistoriquePatientView : Window
    {
        public HistoriquePatientView(HistoriquePatientViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}