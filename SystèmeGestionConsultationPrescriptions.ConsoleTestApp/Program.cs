using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core;
using SystèmeGestionConsultationPrescriptions.Core.Interfaces;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Specifications;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.ConsoleTestApp.ServiceTests;


    
    
        Console.WriteLine("Début des tests...");
        Console.WriteLine("------------------");

        // Test 1: Création d'un médecin
        //await Test1();
        
        // Test 2: Création d'un patient
        //await Test2();
        
        //// Test 3: Association médecin-patient
        //await Test3();

        //// Test 4: Création d'une consultation
        //await Test4();

        //// Test 5: Création d'une prescription
        //await Test5();

        //// Test 6: Recherche historique des consultations
        //await Test6();

        //// Test 7: Test des services de consultation
        //await Test7();

        //// Test 8: Test des services de prescription
        await Test8();

        await ConsultationServiceTests.ExecuterTests();

        Console.WriteLine("Appuyez sur une touche pour terminer...");
        Console.ReadKey();
    

    static async Task Test1()
    {
        Console.WriteLine("\nTest 1 - Création d'un médecin");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var medecin = new Medecin(
                nomUtilisateur: "DrDupont",
                motDePasse: "MotDePasse123",
                numeroLicence: "MD12345",
                nom: "Dupont",
                prenom: "Jean",
                adresse: "123 rue Principale",
                numeroTelephone: "418-555-0123",
                adresseCourriel: "dr.dupont@clinique.ca"
            );
            
            context.Add(medecin);
            await context.SaveChangesAsync();
            Console.WriteLine($"Médecin créé avec ID: {medecin.Id}");
        }
    }

    static async Task Test2()
    {
        Console.WriteLine("\nTest 2 - Création d'un patient");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var medecin = await context.Medecins.FirstOrDefaultAsync();
            if (medecin == null)
            {
                Console.WriteLine("Aucun médecin trouvé. Veuillez d'abord exécuter le Test1.");
                return;
            }

            var patient = new Patient(
                nom: "Tremblay",
                dateNaissance: new DateTime(1980, 1, 1),
                adresse: "456 rue des Érables",
                numeroTelephone: "418-555-4567",
                adresseCourriel: "patient@email.ca",
                medecin: medecin
            );

            var dossierMedical = new DossierMedical
            {
                DateCreation = DateTime.Now,
                Medecin = medecin,
                MedecinId = medecin.Id,
                Patient = patient
            };

            patient.DossierMedical = dossierMedical;
            patient.MedecinId = medecin.Id;
            
            context.Add(patient);
            context.Add(dossierMedical);
            await context.SaveChangesAsync();

            // Vérification
            var patientVerif = await context.Patients
                .Include(p => p.DossierMedical)
                .Include(p => p.Medecin)
                .FirstOrDefaultAsync(p => p.Id == patient.Id);

            if (patientVerif != null)
            {
                Console.WriteLine($"Patient créé avec ID: {patient.Id}");
                Console.WriteLine($"Dossier médical créé avec ID: {dossierMedical.Id}");
                Console.WriteLine($"Vérification - Patient associé au médecin: {patientVerif.Medecin?.Nom}");
                Console.WriteLine($"Vérification - Dossier médical associé: {(patientVerif.DossierMedical != null ? "Oui" : "Non")}");
            }
        }
    }

    static async Task Test3()
    {
        Console.WriteLine("\nTest 3 - Association médecin-patient");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var medecin = await context.Medecins.FirstOrDefaultAsync();
            var patient = await context.Patients.FirstOrDefaultAsync();

            if (medecin != null && patient != null)
            {
                medecin.AjouterPatient(patient);
                await context.SaveChangesAsync();
                Console.WriteLine($"Patient {patient.Id} associé au médecin {medecin.Id}");
            }
            else
            {
                Console.WriteLine("Médecin ou patient non trouvé");
            }
        }
    }

    static async Task Test4()
    {
        Console.WriteLine("\nTest 4 - Création d'une consultation");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var medecin = await context.Medecins.FirstOrDefaultAsync();
            var patient = await context.Patients
                .Include(p => p.DossierMedical)
                .FirstOrDefaultAsync();

            if (medecin == null || patient == null)
            {
                Console.WriteLine("Médecin ou patient non trouvé. Veuillez exécuter les tests 1 et 2 d'abord.");
                return;
            }

            if (patient.DossierMedical == null)
            {
                Console.WriteLine("Le patient n'a pas de dossier médical.");
                return;
            }

            var session = new Session(
                dateConnexion: DateTime.Now,
                dateDeconnexion: DateTime.Now.AddHours(1),
                medecin: medecin
            );
            session.MedecinId = medecin.Id;

            var consultation = new Consultation
            {
                Date = DateTime.Now,
                Motif = "Consultation de routine",
                Observations = "Patient en bonne santé générale",
                Diagnostic = "Aucun problème majeur détecté",
                DossierMedical = patient.DossierMedical,
                DossierMedicalId = patient.DossierMedical.Id,
                Session = session
            };

            context.Add(session);
            context.Add(consultation);
            await context.SaveChangesAsync();

            // Vérification
            var consultationVerif = await context.Consultations
                .Include(c => c.Session)
                .Include(c => c.DossierMedical)
                .FirstOrDefaultAsync(c => c.Id == consultation.Id);

            if (consultationVerif != null)
            {
                Console.WriteLine($"Consultation créée avec ID: {consultation.Id}");
                Console.WriteLine($"Session créée avec ID: {session.Id}");
                Console.WriteLine($"Vérification - Consultation liée au dossier médical: {(consultationVerif.DossierMedical != null ? "Oui" : "Non")}");
                Console.WriteLine($"Vérification - Consultation liée à la session: {(consultationVerif.Session != null ? "Oui" : "Non")}");
            }
        }
    }

    static async Task Test5()
    {
        Console.WriteLine("\nTest 5 - Création d'une prescription");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var consultation = await context.Consultations
                .Include(c => c.Session)
                .Include(c => c.DossierMedical)
                .FirstOrDefaultAsync();

            if (consultation != null)
            {
                var prescription = new Prescription(
                    medicament: "Paracétamol",
                    dosage: 1000,
                    instructions: "1 comprimé toutes les 6 heures, à prendre avec de l'eau",
                    duree: TimeSpan.FromDays(5),
                    consultation: consultation


                );

                context.AddAsync(prescription);
                await context.SaveChangesAsync();
                Console.WriteLine($"Prescription créée avec ID: {prescription.Id}");
            }
            else
            {
                Console.WriteLine("Consultation non trouvée");
            }
        }
    }

    static async Task Test6()
    {
        Console.WriteLine("\nTest 6 - Recherche historique des consultations");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var patient = await context.Patients
                .Include(p => p.DossierMedical)
                .ThenInclude(d => d.Consultations)
                .ThenInclude(c => c.Session)
                .ThenInclude(s => s.Medecin)
                .FirstOrDefaultAsync();

            if (patient != null && patient.DossierMedical != null)
            {
                var consultations = patient.DossierMedical.Consultations
                    .OrderByDescending(c => c.Date)
                    .ToList();

                Console.WriteLine($"Historique des consultations pour le patient {patient.Id}:");
                foreach (var consultation in consultations)
                {
                    Console.WriteLine($"- Date: {consultation.Date}, Médecin: {consultation.Session.Medecin.Nom}");
                    Console.WriteLine($"  Motif: {consultation.Motif}");
                    Console.WriteLine($"  Diagnostic: {consultation.Diagnostic}");
                }
            }
            else
            {
                Console.WriteLine("Patient non trouvé ou pas de dossier médical");
            }
        }
    }

    static async Task Test7()
    {
        Console.WriteLine("\nTest 7 - Test des services de consultation");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var consultationRepository = new ConsultationRepository(context);
            var dossierMedicalRepository = new DossierMedicalRepository(context);
            var sessionRepository = new SessionRepository(context);
            var consultationService = new ConsultationService(consultationRepository, dossierMedicalRepository, sessionRepository);

            // Test GetConsultations
            var consultations = consultationService.GetConsultations(false);
            Console.WriteLine($"Nombre total de consultations: {consultations.Count}");

            if (consultations.Any())
            {
                var premiereConsultation = consultations.First();
                
                // Test GetByIdWithPrescriptions
                var consultationAvecPrescriptions = await consultationService.GetByIdWithPrescriptionsAsync(premiereConsultation.Id);
                if (consultationAvecPrescriptions != null)
                {
                    Console.WriteLine($"Consultation {consultationAvecPrescriptions.Id} trouvée avec {consultationAvecPrescriptions.Prescriptions.Count} prescription(s)");
                }
            }
        }
    }

    static async Task Test8()
    {
        Console.WriteLine("\nTest 8 - Test des services de prescription");
        using (var context = new SystèmeGestionConsultationPrescriptionsDBContext())
        {
            var consultationRepository = new ConsultationRepository(context);
            var dossierMedicalRepository = new DossierMedicalRepository(context);
                var sessionRepository = new SessionRepository(context);
            var consultationService = new ConsultationService(consultationRepository, dossierMedicalRepository, sessionRepository);

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
