using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;

namespace SystèmeGestionConsultationPrescriptions.ConsoleTestApp.ServiceTests
{
    public class PrescriptionServiceTests
    {
        public static async Task ExecuterTests()
        {
            Console.WriteLine("\nTest - Services de prescription");
            using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
            {
                var consultationRepository = new ConsultationRepository(context);
                var dossierMedicalRepository = new DossierMedicalRepository(context);
                var consultationService = new ConsultationService(consultationRepository, dossierMedicalRepository);

                var consultation = await context.Consultations.FirstOrDefaultAsync();
                if (consultation != null)
                {
                    // Création d'une nouvelle prescription via le service
                    var nouvellePrescription = new Prescription(
                        medicament: "Ibuprofène",
                        dosage: 400,
                        instructions: "1 comprimé toutes les 8 heures",
                        duree: TimeSpan.FromDays(3),
                        consultation: consultation
                    );

                    await consultationService.AddPrescriptionAsync(consultation.Id, nouvellePrescription);
                    Console.WriteLine($"Nouvelle prescription ajoutée à la consultation {consultation.Id}");

                    // Vérification de l'ajout
                    var consultationMiseAJour = await consultationService.GetByIdWithPrescriptionsAsync(consultation.Id);
                    if (consultationMiseAJour != null)
                    {
                        Console.WriteLine($"La consultation contient maintenant {consultationMiseAJour.Prescriptions.Count} prescription(s)");
                    }
                }
                else
                {
                    Console.WriteLine("Aucune consultation trouvée pour tester le service de prescription");
                }
            }
        }
    }
} 