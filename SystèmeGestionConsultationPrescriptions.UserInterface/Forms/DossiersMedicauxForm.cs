using System;
using System.Windows.Forms;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using SystèmeGestionConsultationPrescriptions.Infrastructure;

public partial class DossiersMedicauxForm : Form
{
    private readonly int _medecinId;
    private readonly DossierMedicalRepository _dossierMedicalRepository;

    public DossiersMedicauxForm(int medecinId)
    {
        InitializeComponent();
        _medecinId = medecinId;
        var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
        _dossierMedicalRepository = new DossierMedicalRepository(dbContext);
        ConfigureDataGridView();
        LoadDossiersMedicaux();
    }

    private void ConfigureDataGridView()
    {
        dgvDossiersMedicaux.Columns.Add("Id", "ID");
        dgvDossiersMedicaux.Columns.Add("Patient", "Patient");
        dgvDossiersMedicaux.Columns.Add("DateCreation", "Date de création");
        dgvDossiersMedicaux.Columns.Add("DerniereMaj", "Dernière mise à jour");
        
        dgvDossiersMedicaux.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDossiersMedicaux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDossiersMedicaux.MultiSelect = false;
        dgvDossiersMedicaux.ReadOnly = true;
    }

    private async void LoadDossiersMedicaux()
    {
        try
        {
            var dossiers = await _dossierMedicalRepository.GetByMedecinIdAsync(_medecinId);
            dgvDossiersMedicaux.Rows.Clear();
            foreach (var dossier in dossiers)
            {
                dgvDossiersMedicaux.Rows.Add(
                    dossier.Id,
                    $"{dossier.Patient.Nom} ",
                    dossier.DateCreation.ToShortDateString()
                    
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des dossiers médicaux: {ex.Message}",
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
} 