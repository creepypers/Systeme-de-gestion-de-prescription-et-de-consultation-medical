using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;

namespace SystèmeGestionConsultationPrescriptions.ConsoleTestApp.ServiceTests
{
    public class SessionServiceTests
    {
        public static async Task ExecuterTests()
        {
            Console.WriteLine("\nTest - Services de session");
            using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
            {
                var sessionRepository = new SessionRepository(context);
                var sessionService = new SessionService(sessionRepository);

                // Test 1: Création d'une nouvelle session
                var medecin = await context.Medecins.FirstOrDefaultAsync();
                if (medecin != null)
                {
                    var nouvelleSession = new Session(
                        dateConnexion: DateTime.Now,
                        dateDeconnexion: DateTime.Now,
                        medecin: medecin
                    );

                    await sessionService.AddSessionAsync(nouvelleSession);
                    Console.WriteLine($"Test 1 - Nouvelle session créée avec ID: {nouvelleSession.Id}");

                    // Test 2: Ajout d'une consultation à la session
                    var consultation = new Consultation
                    {
                        Date = DateTime.Now,
                        Motif = "Test via SessionService",
                        Session = nouvelleSession,
                        DossierMedical = await context.DossiersMedical.FirstOrDefaultAsync()
                    };

                    await sessionService.AjouterConsultationAsync(nouvelleSession.Id, consultation);
                    Console.WriteLine($"Test 2 - Consultation ajoutée à la session {nouvelleSession.Id}");

                    // Test 3: Validation de l'authentification
                    var authentificationValide = await sessionService.ValiderAuthentificationAsync(medecin.NomUtilisateur, medecin.MotDePasse);
                    Console.WriteLine($"Test 3 - Validation de l'authentification: {(authentificationValide ? "Réussie" : "Échouée")}");

                    // Test 4: Fermeture de la session
                    nouvelleSession.DateDeconnexion = DateTime.Now;
                    await sessionService.UpdateSessionAsync(nouvelleSession);
                    Console.WriteLine($"Test 4 - Session {nouvelleSession.Id} fermée");
                }
                else
                {
                    Console.WriteLine("Aucun médecin trouvé pour les tests de session");
                }
            }
        }
    }
} 