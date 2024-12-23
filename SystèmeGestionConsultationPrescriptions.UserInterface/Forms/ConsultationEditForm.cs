using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using System;
using System.Windows.Forms;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class ConsultationEditForm : Form
    {
        private readonly int _medecinId;
        private readonly int _sessionId;
        private readonly int? _consultationId;
        private readonly ConsultationRepository _consultationRepository;
        private readonly PatientRepository _patientRepository;
        private readonly DossierMedicalRepository _dossierMedicalRepository;

        public ConsultationEditForm(int medecinId, int sessionId, int? consultationId = null)
        {
            InitializeComponent();
            _medecinId = medecinId;
            _sessionId = sessionId;
            _consultationId = consultationId;

            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            _consultationRepository = new ConsultationRepository(dbContext);
            _patientRepository = new PatientRepository(dbContext);
            _dossierMedicalRepository = new DossierMedicalRepository(dbContext);

            LoadPatients();

            if (_consultationId.HasValue)
            {
                this.Text = "Modifier une consultation";
                LoadConsultation();
            }
            else
            {
                this.Text = "Nouvelle consultation";
                dtpDate.Value = DateTime.Now;
            }
        }

        private async void LoadPatients()
        {
            try
            {
                var patients = await _patientRepository.GetPatientsByMedecinIdAsync(_medecinId);
                cmbPatient.DataSource = patients;
                cmbPatient.DisplayMember = "Nom";
                cmbPatient.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des patients: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadConsultation()
        {
            try
            {
                var consultation = await _consultationRepository.GetByIdAsync(_consultationId.Value);
                if (consultation != null)
                {
                    dtpDate.Value = consultation.Date;
                    cmbPatient.SelectedValue = consultation.DossierMedical.PatientId;
                    txtMotif.Text = consultation.Motif;
                    txtObservations.Text = consultation.Observations;
                    txtDiagnostic.Text = consultation.Diagnostic;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la consultation: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnSauvegarder_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var patientId = (int)cmbPatient.SelectedValue;
                var dossierMedical = await _dossierMedicalRepository.GetByPatientIdAsync(patientId)
                    ?? await CreateDossierMedical(patientId);

                var consultation = new Consultation
                {
                    Id = _consultationId ?? 0,
                    Date = dtpDate.Value,
                    Motif = txtMotif.Text,
                    Observations = txtObservations.Text,
                    Diagnostic = txtDiagnostic.Text,
                    DossierMedicalId = dossierMedical.Id,
                    SessionId = _sessionId
                };

                if (_consultationId.HasValue)
                    await _consultationRepository.UpdateAsync(consultation);
                else
                    await _consultationRepository.AddAsync(consultation);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement de la consultation: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<DossierMedical> CreateDossierMedical(int patientId)
        {
            var dossierMedical = new DossierMedical
            {
                DateCreation = DateTime.Now,
                PatientId = patientId,
                MedecinId = _medecinId
            };

            await _dossierMedicalRepository.AddAsync(dossierMedical);
            return dossierMedical;
        }

        private bool ValidateForm()
        {
            if (cmbPatient.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMotif.Text) ||
                string.IsNullOrWhiteSpace(txtDiagnostic.Text))
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