using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using System;
using System.Windows.Forms;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class ConsultationsForm : Form
    {
        private readonly int _medecinId;
        private readonly int _sessionId;
        private readonly ConsultationRepository _consultationRepository;
        private readonly DossierMedicalRepository _dossierMedicalRepository;

        public ConsultationsForm(int medecinId, int sessionId)
        {
            InitializeComponent();
            _medecinId = medecinId;
            _sessionId = sessionId;
            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            _consultationRepository = new ConsultationRepository(dbContext);
            _dossierMedicalRepository = new DossierMedicalRepository(dbContext);

            ConfigureDataGridView();
            LoadConsultations();
            ConfigureButtons();
        }

        private void ConfigureDataGridView()
        {
            dgvConsultations.Columns.Add("Id", "ID");
            dgvConsultations.Columns.Add("Date", "Date");
            dgvConsultations.Columns.Add("Patient", "Patient");
            dgvConsultations.Columns.Add("Motif", "Motif");
            dgvConsultations.Columns.Add("Diagnostic", "Diagnostic");

            dgvConsultations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultations.MultiSelect = false;
            dgvConsultations.ReadOnly = true;
            dgvConsultations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void LoadConsultations()
        {
            try
            {
                dgvConsultations.Rows.Clear();
                var consultations = await _consultationRepository.GetByMedecinIdAsync(_medecinId);

                foreach (var consultation in consultations)
                {
                    dgvConsultations.Rows.Add(
                        consultation.Id,
                        consultation.Date.ToShortDateString(),
                        consultation.DossierMedical?.Patient?.Nom,
                        consultation.Motif,
                        consultation.Diagnostic
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des consultations: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureButtons()
        {
            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;
            btnPrescriptions.Click += BtnPrescriptions_Click;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            var addConsultationForm = new ConsultationEditForm(_medecinId, _sessionId);
            if (addConsultationForm.ShowDialog() == DialogResult.OK)
            {
                LoadConsultations();
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.SelectedRows.Count == 0) return;

            var consultationId = (int)dgvConsultations.SelectedRows[0].Cells["Id"].Value;
            var editConsultationForm = new ConsultationEditForm(_medecinId, _sessionId, consultationId);
            if (editConsultationForm.ShowDialog() == DialogResult.OK)
            {
                LoadConsultations();
            }
        }

        private async void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.SelectedRows.Count == 0) return;

            var consultationId = (int)dgvConsultations.SelectedRows[0].Cells["Id"].Value;
            var patientNom = dgvConsultations.SelectedRows[0].Cells["Patient"].Value.ToString();
            var date = dgvConsultations.SelectedRows[0].Cells["Date"].Value.ToString();

            if (MessageBox.Show(
                $"Voulez-vous vraiment supprimer la consultation du {date} pour le patient {patientNom} ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _consultationRepository.DeleteAsync(consultationId);
                    LoadConsultations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression de la consultation: {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPrescriptions_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une consultation pour voir ses prescriptions.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var consultationId = (int)dgvConsultations.SelectedRows[0].Cells["Id"].Value;
            var prescriptionsForm = new PrescriptionsForm(consultationId);
            prescriptionsForm.ShowDialog();
        }
    }
} 