using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;

namespace SystèmeGestionConsultationPrescriptions.ConsoleTestApp.ServiceTests
{
    public class PatientServiceTests
    {
        public static async Task ExecuterTests()
        {
            Console.WriteLine("\nTest - Services de patient");
            using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
            {
                var patientRepository = new PatientRepository(context);
                var dossierMedicalRepository = new DossierMedicalRepository(context);
                var medecinRepository = new MedecinRepository(context);
                var patientService = new PatientService(patientRepository, medecinRepository, dossierMedicalRepository);

                // Test 1: Création d'un nouveau patient
                var nouveauPatient = new Patient(
                    nom: "TestPatient",
                    dateNaissance: new DateTime(1990, 1, 1),
                    adresse: "456 rue Patient",
                    numeroTelephone: "555-9876",
                    adresseCourriel: "patient.test@test.com",
                    medecin: await context.Medecins.FirstOrDefaultAsync()
                );

                var patientCree = patientService.AddPatient(nouveauPatient);
                Console.WriteLine($"Test 1 - Nouveau patient créé avec ID: {patientCree.Id}");

                // Test 2: Création du dossier médical
                var medecin = await context.Medecins.FirstOrDefaultAsync();
                if (medecin != null)
                {
                    await patientService.CreerDossierMedicalAsync(patientCree.Id, medecin.Id);
                    Console.WriteLine($"Test 2 - Dossier médical créé pour le patient {patientCree.Id}");
                }

                // Test 3: Récupération du patient avec son dossier médical
                var patientAvecDossier = await patientService.GetByIdWithDossiersMedicauxAsync(patientCree.Id);
                if (patientAvecDossier?.DossierMedical != null)
                {
                    Console.WriteLine($"Test 3 - Patient trouvé avec dossier médical ID: {patientAvecDossier.DossierMedical.Id}");
                }

                // Test 4: Récupération du patient avec son médecin
                var patientAvecMedecin = await patientService.GetByIdWithMedecinAsync(patientCree.Id);
                if (patientAvecMedecin?.Medecin != null)
                {
                    Console.WriteLine($"Test 4 - Patient trouvé avec médecin: {patientAvecMedecin.Medecin.Nom}");
                }
            }
        }
    }
} 