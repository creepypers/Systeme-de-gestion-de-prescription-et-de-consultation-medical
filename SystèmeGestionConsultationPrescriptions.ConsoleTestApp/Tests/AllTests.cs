using Xunit;
using SystèmeGestionConsultationPrescriptions.Core.Entities;

namespace SystèmeGestionConsultationPrescriptions.ConsoleTestApp.Tests
{
    public class programs
    {
        [Fact]
        public void TestDossierMedical_AjoutConsultation_DevoirAjouterConsultation()
        {
            // Arrange
            var dossierMedical = new DossierMedical(1, DateTime.Now);
            var consultation = new Consultation(
                DateTime.Now,
                "Consultation de routine",
                "Patient en bonne santé",
                "Aucun problème majeur"
            );

            // Act
            dossierMedical.AjouterConsultation(consultation);

            // Assert
            Assert.Contains(consultation, dossierMedical.consultations);
        }

        [Fact]
        public void TestDossierMedical_AjoutTraitementActif_DevoirAjouterTraitement()
        {
            // Arrange
            var dossierMedical = new DossierMedical(1, DateTime.Now);
            var prescription = new Prescription
            {
                Medicament = "Aspirine",
                Dosage = 500,
                Instructions = "1 comprimé par jour",
                Etat = EtatPrescription.Active
            };

            // Act
            dossierMedical.AjouterTraitement(prescription);

            // Assert
            Assert.Contains(prescription, dossierMedical.traitementActifs);
        }

        [Fact]
        public void TestMedecin_GestionPatients_DevoirGererPatients()
        {
            // Arrange
            var medecin = new Medecin(
                "docteur1",
                "password123",
                "12345",
                "Dr",
                "Smith",
                "123 rue",
                "514-555-0123",
                "dr.smith@email.com"
            );
            var dossierMedical = new DossierMedical(1, DateTime.Now);
            var patient = new Patient(
                "Dupont",
                new DateTime(1980, 1, 1),
                "456 rue principale",
                "514-555-0199",
                "dupont@email.com",
                medecin,
                dossierMedical
            );

            // Act
            medecin.AjouterPatient(patient);
            var contientPatient = medecin.Patients.Contains(patient);
            medecin.RetirerPatient(patient);
            var patientRetire = !medecin.Patients.Contains(patient);

            // Assert
            Assert.True(contientPatient);
            Assert.True(patientRetire);
        }

        [Fact]
        public void TestPrescription_DefinirPeriode_DevoirCalculerDuree()
        {
            // Arrange
            var prescription = new Prescription();
            var dateDebut = DateTime.Now;
            var dateFin = dateDebut.AddDays(7);

            // Act
            prescription.DefinirPeriode(dateDebut, dateFin);

            // Assert
            Assert.Equal(TimeSpan.FromDays(7), prescription.Duree);
            Assert.Equal(dateDebut, prescription.DateDebut);
            Assert.Equal(dateFin, prescription.DateFin);
        }

        [Fact]
        public void TestDossierMedical_VerifierTraitements_DevoirMettreAJourTraitementsExpires()
        {
            // Arrange
            var dossierMedical = new DossierMedical(1, DateTime.Now);
            var prescription = new Prescription
            {
                Medicament = "Antibiotique",
                Dosage = 250,
                Instructions = "2 fois par jour",
                Etat = EtatPrescription.Active
            };
            prescription.DefinirPeriode(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-3));
            dossierMedical.AjouterTraitement(prescription);

            // Act
            dossierMedical.VerifierEtMettreAJourTraitements();

            // Assert
            Assert.DoesNotContain(prescription, dossierMedical.traitementActifs);
            Assert.Contains(dossierMedical.TraitementsPasses, t => t.Contains("Antibiotique"));
        }
    }
}