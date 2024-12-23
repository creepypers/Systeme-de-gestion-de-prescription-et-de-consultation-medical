namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    partial class ConsultationsForm
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
            dgvConsultations = new DataGridView();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnPrescriptions = new Button();
            panelButtons = new Panel();

            // Configuration du DataGridView
            dgvConsultations.Dock = DockStyle.Fill;

            // Configuration des boutons
            panelButtons.Height = 50;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Padding = new Padding(10);

            ConfigureButton(btnAjouter, "Ajouter", 0);
            ConfigureButton(btnModifier, "Modifier", 1);
            ConfigureButton(btnSupprimer, "Supprimer", 2);
            ConfigureButton(btnPrescriptions, "Prescriptions", 3);

            // Ajout des contrôles
            panelButtons.Controls.AddRange(new Control[] { 
                btnAjouter, btnModifier, btnSupprimer, btnPrescriptions 
            });
            Controls.Add(dgvConsultations);
            Controls.Add(panelButtons);

            // Configuration du formulaire
            this.Size = new Size(800, 600);
            this.Text = "Consultations";
        }

        private void ConfigureButton(Button btn, string text, int position)
        {
            btn.Text = text;
            btn.Size = new Size(120, 30);
            btn.Location = new Point(10 + position * 130, 10);
            btn.BackColor = Color.FromArgb(20, 39, 78);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
        }

        private DataGridView dgvConsultations;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnPrescriptions;
        private Panel panelButtons;
    }
} 