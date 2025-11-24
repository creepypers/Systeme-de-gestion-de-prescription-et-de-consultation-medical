using System.Windows;
using SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.Views
{
    public partial class ConsulterPrescriptionDialogView : Window
    {
        public ConsulterPrescriptionDialogView(PrescriptionViewModel prescription)
        {
            InitializeComponent();
            DataContext = new ConsulterPrescriptionDialogViewModel(prescription);

            if (DataContext is ConsulterPrescriptionDialogViewModel viewModel)
            {
                viewModel.RequestClose += (s, e) => Close();
            }
        }
    }
} 