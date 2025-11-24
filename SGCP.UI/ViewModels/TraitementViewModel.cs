using System;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur.ViewModels
{
    public class TraitementViewModel : ViewModelBase
    {
        private DateTime? _dateCloture;
        
        public DateTime? DateCloture
        {
            get => _dateCloture;
            set => SetProperty(ref _dateCloture, value);
        }
        
        // Autres propriétés existantes...
    }
} 