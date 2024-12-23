namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    partial class PatientsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvPatients = new DataGridView();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            
            // DataGridView
            dgvPatients.Dock = DockStyle.Top;
            dgvPatients.Location = new Point(0, 0);
            dgvPatients.Size = new Size(800, 400);
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Boutons
            btnAjouter.Text = "Ajouter";
            btnAjouter.Location = new Point(10, 420);
            btnAjouter.Size = new Size(100, 30);
            
            btnModifier.Text = "Modifier";
            btnModifier.Location = new Point(120, 420);
            btnModifier.Size = new Size(100, 30);
            
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.Location = new Point(230, 420);
            btnSupprimer.Size = new Size(100, 30);
            
            // Form
            Controls.Add(dgvPatients);
            Controls.Add(btnAjouter);
            Controls.Add(btnModifier);
            Controls.Add(btnSupprimer);
            Size = new Size(800, 500);
            
            components = new System.ComponentModel.Container();
        }

        private DataGridView dgvPatients;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
    }
} 