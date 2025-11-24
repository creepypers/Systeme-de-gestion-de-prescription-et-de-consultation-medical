using System.Windows;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class PatientDialogView : Window
    {
        public PatientDialogView(PatientDialogViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.RequestClose += (s, e) => Close();
        }
    }
}
