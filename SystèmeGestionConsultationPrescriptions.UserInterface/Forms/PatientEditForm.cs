using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using System;
using System.Windows.Forms;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class PatientEditForm : Form
    {
        private readonly int _medecinId;
        private readonly int? _patientId;
        private readonly PatientRepository _patientRepository;

        public PatientEditForm(int medecinId, int? patientId = null)
        {
            InitializeComponent();
            _medecinId = medecinId;
            _patientId = patientId;
            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            _patientRepository = new PatientRepository(dbContext);

            if (_patientId.HasValue)
            {
                this.Text = "Modifier un patient";
                LoadPatient();
            }
            else
            {
                this.Text = "Ajouter un patient";
            }
        }

        private async void LoadPatient()
        {
            try
            {
                var patient = await _patientRepository.GetByIdAsync(_patientId.Value);
                if (patient != null)
                {
                    txtNom.Text = patient.Nom;
                    txtAdresse.Text = patient.Adresse;
                    dtpDateNaissance.Value = patient.DateNaissance ?? DateTime.Now;
                    txtTelephone.Text = patient.NumeroTelephone;
                    txtEmail.Text = patient.AdresseCourriel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement du patient: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnSauvegarder_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var patient = new Patient
                {
                    Id = _patientId ?? 0,
                    MedecinId = _medecinId,
                    Nom = txtNom.Text,
                    DateNaissance = dtpDateNaissance.Value,
                    Adresse = txtAdresse.Text,
                    NumeroTelephone = txtTelephone.Text,
                    AdresseCourriel = txtEmail.Text
                };

                if (_patientId.HasValue)
                    await _patientRepository.UpdateAsync(patient);
                else
                    await _patientRepository.AddAsync(patient);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement du patient: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtAdresse.Text) ||
                string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 