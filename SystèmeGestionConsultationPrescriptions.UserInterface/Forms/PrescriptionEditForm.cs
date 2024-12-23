using System;
using System.Windows.Forms;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.Core.Enums;
using SystèmeGestionConsultationPrescriptions.Infrastructure;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class PrescriptionEditForm : Form
    {
        private readonly int _consultationId;
        private readonly int? _prescriptionId;
        private readonly ConsultationRepository _consultationRepository;

        public PrescriptionEditForm(int consultationId, int? prescriptionId = null)
        {
            InitializeComponent();
            _consultationId = consultationId;
            _prescriptionId = prescriptionId;
            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            _consultationRepository = new ConsultationRepository(dbContext);

            if (_prescriptionId.HasValue)
            {
                this.Text = "Modifier une prescription";
                LoadPrescription();
            }
            else
            {
                this.Text = "Nouvelle prescription";
            }
        }

        private async void LoadPrescription()
        {
            try
            {
                var prescription = await _consultationRepository.GetPrescriptionByIdAsync(_prescriptionId.Value);
                if (prescription != null)
                {
                    txtMedicament.Text = prescription.Medicament;
                    numDosage.Value = prescription.Dosage;
                    txtInstructions.Text = prescription.Instructions;
                    numDuree.Value = prescription.Duree.Days;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la prescription: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnSauvegarder_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var prescription = new Prescription
                {
                    Id = _prescriptionId ?? 0,
                    ConsultationId = _consultationId,
                    Medicament = txtMedicament.Text,
                    Dosage = (int)numDosage.Value,
                    Instructions = txtInstructions.Text,
                    Duree = TimeSpan.FromDays((double)numDuree.Value),
                    Etat = EtatPrescription.Active
                };

                if (_prescriptionId.HasValue)
                    await _consultationRepository.UpdatePrescriptionAsync(prescription);
                else
                    await _consultationRepository.AddPrescriptionAsync(prescription);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement de la prescription: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtMedicament.Text) ||
                string.IsNullOrWhiteSpace(txtInstructions.Text) ||
                numDosage.Value <= 0 ||
                numDuree.Value <= 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs correctement.",
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