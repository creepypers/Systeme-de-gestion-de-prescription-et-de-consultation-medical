using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;

namespace SystèmeGestionConsultationPrescriptions.ConsoleTestApp.ServiceTests
{
    public class ConsultationServiceTests
    {
        public static async Task ExecuterTests()
        {
            Console.WriteLine("\nTest - Services de consultation");
            using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
            {
                var consultationRepository = new ConsultationRepository(context);
                var dossierMedicalRepository = new DossierMedicalRepository(context);
                var sessionRepository = new SessionRepository(context);
                var consultationService = new ConsultationService(consultationRepository, dossierMedicalRepository, sessionRepository);

                // Test 1: Récupération de toutes les consultations
                var consultations = consultationService.GetConsultations(false);
                Console.WriteLine($"Test 1 - Nombre total de consultations: {consultations.Count}");

                if (consultations.Any())
                {
                    var premiereConsultation = consultations.First();
                    
                    // Test 2: Récupération d'une consultation avec ses prescriptions
                    var consultationAvecPrescriptions = await consultationService.GetByIdWithPrescriptionsAsync(premiereConsultation.Id);
                    if (consultationAvecPrescriptions != null)
                    {
                        Console.WriteLine($"Test 2 - Consultation {consultationAvecPrescriptions.Id} trouvée avec {consultationAvecPrescriptions.Prescriptions.Count} prescription(s)");
                    }

                    // Test 3: Création d'une nouvelle consultation
                    var session = await context.Sessions.FirstOrDefaultAsync();
                    var dossierMedical = await context.DossiersMedical.FirstOrDefaultAsync();
                    
                    if (session != null && dossierMedical != null)
                    {
                        var nouvelleConsultation = new Consultation
                        {
                            Date = DateTime.Now,
                            Motif = "Test de création",
                            Observations = "Test d'observation",
                            Diagnostic = "Test de diagnostic",
                            Session = session,
                            DossierMedical = dossierMedical
                        };

                       Consultation consultationCreee =  consultationService.AddConsultation(nouvelleConsultation);
                        Console.WriteLine($"Test 3 - Nouvelle consultation créée avec ID: {consultationCreee.Id}");

                        // Test 4: Ajout d'une prescription à la nouvelle consultation
                        var prescription = new Prescription(
                            medicament: "Test Médicament",
                            dosage: 100,
                            instructions: "Test instructions",
                            duree: TimeSpan.FromDays(7),
                            consultation: consultationCreee
                        );

                        await consultationService.AddPrescriptionAsync(consultationCreee.Id, prescription);
                        Console.WriteLine($"Test 4 - Prescription ajoutée à la consultation {consultationCreee.Id}");

                        // Test 5: Vérification finale
                        var consultationFinale = await consultationService.GetByIdWithPrescriptionsAsync(consultationCreee.Id);
                        if (consultationFinale != null)
                        {
                            Console.WriteLine($"Test 5 - Vérification finale: {consultationFinale.Prescriptions.Count} prescription(s) dans la consultation");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Session ou dossier médical non trouvé pour les tests de création");
                    }
                }
                else
                {
                    Console.WriteLine("Aucune consultation trouvée dans la base de données");
                }
            }
        }
    }
} 