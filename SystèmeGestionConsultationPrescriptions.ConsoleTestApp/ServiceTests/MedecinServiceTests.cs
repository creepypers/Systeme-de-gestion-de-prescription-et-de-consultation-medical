using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;

namespace SystèmeGestionConsultationPrescriptions.ConsoleTestApp.ServiceTests
{
    public class MedecinServiceTests
    {
        public static async Task ExecuterTests()
        {
            Console.WriteLine("\nTest - Services de médecin");
            using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
            {
                var medecinRepository = new MedecinRepository(context);
                var sessionRepository = new SessionRepository(context);
                var medecinService = new MedecinService(medecinRepository, sessionRepository);

                // Test 1: Création d'un nouveau médecin
                var nouveauMedecin = new Medecin(
                    nomUtilisateur: "DrTest",
                    motDePasse: "Test123!",
                    numeroLicence: "TEST123",
                    nom: "Test",
                    prenom: "Docteur",
                    adresse: "123 rue Test",
                    numeroTelephone: "555-0123",
                    adresseCourriel: "dr.test@test.com"
                );

                var medecinCree = medecinService.AddMedecin(nouveauMedecin);
                Console.WriteLine($"Test 1 - Nouveau médecin créé avec ID: {medecinCree.Id}");

                // Test 2: Création d'une session pour le médecin
                var session = new Session(DateTime.Now, null, medecinCree);
                await sessionRepository.AddAsync(session);
                Console.WriteLine($"Test 2 - Nouvelle session créée pour le médecin {medecinCree.Id}");

                // Test 3: Récupération du médecin avec ses sessions
                var medecinAvecSessions = await medecinService.GetByIdWithSessionsAsync(medecinCree.Id);
                if (medecinAvecSessions != null)
                {
                    Console.WriteLine($"Test 3 - Médecin trouvé avec {medecinAvecSessions.Sessions.Count} session(s)");
                }

                // Test 4: Validation des credentials
                var credentialsValides = await medecinService.ValiderCredentialsAsync("DrTest", "Test123!");
                Console.WriteLine($"Test 4 - Validation des credentials: {(credentialsValides ? "Réussie" : "Échouée")}");
            }
        }
    }
} 