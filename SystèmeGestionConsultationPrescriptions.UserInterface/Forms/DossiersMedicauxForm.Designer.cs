public partial class DossiersMedicauxForm
{
    private void InitializeComponent()
    {
        this.dgvDossiersMedicaux = new DataGridView();
        
        // Configuration de base du formulaire
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1200, 800);
        this.Name = "DossiersMedicauxForm";
        this.Text = "Dossiers Médicaux";
        
        // Configuration du DataGridView
        ((System.ComponentModel.ISupportInitialize)(this.dgvDossiersMedicaux)).BeginInit();
        this.dgvDossiersMedicaux.Dock = DockStyle.Fill;
        this.dgvDossiersMedicaux.Location = new Point(0, 0);
        this.dgvDossiersMedicaux.Name = "dgvDossiersMedicaux";
        this.dgvDossiersMedicaux.Size = new Size(1200, 800);
        this.dgvDossiersMedicaux.TabIndex = 0;
        this.dgvDossiersMedicaux.AllowUserToAddRows = false;
        this.dgvDossiersMedicaux.AllowUserToDeleteRows = false;
        this.dgvDossiersMedicaux.BackgroundColor = Color.White;
        
        // Ajout du DataGridView au formulaire
        this.Controls.Add(this.dgvDossiersMedicaux);
        
        ((System.ComponentModel.ISupportInitialize)(this.dgvDossiersMedicaux)).EndInit();
        this.ResumeLayout(false);
    }

    private DataGridView dgvDossiersMedicaux;
} 