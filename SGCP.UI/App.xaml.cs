using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SystèmeGestionConsultationPrescriptions.Interfaceutilisateur
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                using (var context = new SystèmeGestionConsultationPrescriptions.Infrastructure.SystèmeGestionConsultationPrescriptionsDBContext())
                {
                    SystèmeGestionConsultationPrescriptions.Infrastructure.DbInitializer.Initialize(context);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de l'initialisation de la base de données : {ex.Message}\n\n{ex.StackTrace}", "Erreur de démarrage", MessageBoxButton.OK, MessageBoxImage.Error);
                Current.Shutdown();
            }
        }
    }
}
