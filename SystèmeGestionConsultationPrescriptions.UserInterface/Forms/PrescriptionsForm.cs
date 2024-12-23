using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Enums;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using System;
using System.Windows.Forms;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class PrescriptionsForm : Form
    {
        private readonly int _medecinId;
        private readonly int _sessionId;
        private readonly int _consultationId;
        private readonly ConsultationRepository _consultationRepository;

        public PrescriptionsForm(int medecinId, int sessionId = 0, int consultationId = 0)
        {
            InitializeComponent();
            
            // Initialiser le repository en premier
            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            _consultationRepository = new ConsultationRepository(dbContext);
            
            // Assigner les autres champs
            _medecinId = medecinId;
            _sessionId = sessionId;
            _consultationId = consultationId;
            
            ConfigureDataGridView();
            LoadPrescriptions();
        }

        private void ConfigureDataGridView()
        {
            dgvPrescriptions.Columns.Add("Id", "ID");
            dgvPrescriptions.Columns.Add("Medicament", "Médicament");
            dgvPrescriptions.Columns.Add("Dosage", "Dosage");
            dgvPrescriptions.Columns.Add("Instructions", "Instructions");
            dgvPrescriptions.Columns.Add("Duree", "Durée (jours)");
            dgvPrescriptions.Columns.Add("Etat", "État");

            dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrescriptions.MultiSelect = false;
            dgvPrescriptions.ReadOnly = true;
            dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void LoadPrescriptions()
        {
            try
            {
                dgvPrescriptions.Rows.Clear();
                        var prescriptions = await _consultationRepository.GetPrescriptionsByMedecinIdAsync(_medecinId);

                foreach (var prescription in prescriptions)
                {
                    dgvPrescriptions.Rows.Add(
                        prescription.Id,
                        prescription.Medicament,
                        prescription.Dosage,
                        prescription.Instructions,
                        prescription.Duree.Days,
                        prescription.Etat.ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des prescriptions: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureButtons()
        {
            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;
            btnTerminer.Click += BtnTerminer_Click;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            var addPrescriptionForm = new PrescriptionEditForm(_sessionId);
            if (addPrescriptionForm.ShowDialog() == DialogResult.OK)
            {
                LoadPrescriptions();
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0) return;

            var prescriptionId = (int)dgvPrescriptions.SelectedRows[0].Cells["Id"].Value;
            var editPrescriptionForm = new PrescriptionEditForm(_sessionId, prescriptionId);
            if (editPrescriptionForm.ShowDialog() == DialogResult.OK)
            {
                LoadPrescriptions();
            }
        }

        private async void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0) return;

            var prescriptionId = (int)dgvPrescriptions.SelectedRows[0].Cells["Id"].Value;
            var medicament = dgvPrescriptions.SelectedRows[0].Cells["Medicament"].Value.ToString();

            if (MessageBox.Show(
                $"Voulez-vous vraiment supprimer la prescription de {medicament} ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _consultationRepository.DeletePrescriptionAsync(prescriptionId);
                    LoadPrescriptions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression de la prescription: {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnTerminer_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0) return;

            var prescriptionId = (int)dgvPrescriptions.SelectedRows[0].Cells["Id"].Value;
            try
            {
                var prescription = await _consultationRepository.GetPrescriptionByIdAsync(prescriptionId);
                if (prescription != null)
                {
                    await _consultationRepository.ChangerEtatAsync( _sessionId, prescriptionId  );
                    LoadPrescriptions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de l'état de la prescription: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 