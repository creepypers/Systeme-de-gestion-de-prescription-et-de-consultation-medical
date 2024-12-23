using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class PatientsForm : Form
    {
        private readonly int _medecinId;
        private readonly PatientRepository _patientRepository;

        public PatientsForm(int medecinId)
        {
            InitializeComponent();
            _medecinId = medecinId;
            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            _patientRepository = new PatientRepository(dbContext);
            
            ConfigureDataGridView();
            LoadPatients();
            ConfigureButtons();
        }

        private void ConfigureDataGridView()
        {
            dgvPatients.Columns.Add("Id", "ID");
            dgvPatients.Columns.Add("Nom", "Nom");
            dgvPatients.Columns.Add("DateNaissance", "Date de naissance");
            dgvPatients.Columns.Add("Adresse", "Adresse");
            dgvPatients.Columns.Add("NumeroTelephone", "Téléphone");
            dgvPatients.Columns.Add("AdresseCourriel", "Email");

            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.ReadOnly = true;
        }

        private async void LoadPatients()
        {
            try
            {
                dgvPatients.Rows.Clear();
                var patients = await _patientRepository.GetPatientsByMedecinIdAsync(_medecinId);
                
                foreach (var patient in patients)
                {
                    dgvPatients.Rows.Add(
                        patient.Id,
                        patient.Nom,
                        patient.DateNaissance?.ToShortDateString(),
                        patient.Adresse,
                        patient.NumeroTelephone,
                        patient.AdresseCourriel
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des patients: {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureButtons()
        {
            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            var addPatientForm = new PatientEditForm(_medecinId);
            if (addPatientForm.ShowDialog() == DialogResult.OK)
            {
                LoadPatients();
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0) return;

            var patientId = (int)dgvPatients.SelectedRows[0].Cells["Id"].Value;
            var editPatientForm = new PatientEditForm(_medecinId, patientId);
            if (editPatientForm.ShowDialog() == DialogResult.OK)
            {
                LoadPatients();
            }
        }

        private async void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0) return;

            var patientId = (int)dgvPatients.SelectedRows[0].Cells["Id"].Value;
            var patientNom = dgvPatients.SelectedRows[0].Cells["Nom"].Value.ToString();

            if (MessageBox.Show(
                $"Voulez-vous vraiment supprimer le patient {patientNom} ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _patientRepository.DeleteAsync(patientId);
                    LoadPatients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du patient: {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
} 