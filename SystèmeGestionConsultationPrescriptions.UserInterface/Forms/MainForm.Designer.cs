namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    partial class MainForm
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
            panelMenu = new Panel();
            btnLogout = new Button();
            btnPrescriptions = new Button();
            btnConsultations = new Button();
            btnPatients = new Button();
            panelLogo = new Panel();
            lblWelcome = new Label();
            panelMain = new Panel();
            btnDossiersMedicaux = new Button();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(20, 39, 78);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnPrescriptions);
            panelMenu.Controls.Add(btnConsultations);
            panelMenu.Controls.Add(btnDossiersMedicaux);
            panelMenu.Controls.Add(btnPatients);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(5, 5, 5, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(406, 1166);
            panelMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 1070);
            btnLogout.Margin = new Padding(5, 5, 5, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(406, 96);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Déconnexion";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPrescriptions
            // 
            btnPrescriptions.Dock = DockStyle.Top;
            btnPrescriptions.FlatAppearance.BorderSize = 0;
            btnPrescriptions.FlatStyle = FlatStyle.Flat;
            btnPrescriptions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrescriptions.ForeColor = Color.White;
            btnPrescriptions.Location = new Point(0, 352);
            btnPrescriptions.Margin = new Padding(5, 5, 5, 5);
            btnPrescriptions.Name = "btnPrescriptions";
            btnPrescriptions.Size = new Size(406, 96);
            btnPrescriptions.TabIndex = 3;
            btnPrescriptions.Text = "Prescriptions";
            btnPrescriptions.UseVisualStyleBackColor = true;
            btnPrescriptions.Click += btnPrescriptions_Click;

            // btnDossiersMedicaux
            btnDossiersMedicaux.Dock = DockStyle.Top;
            btnDossiersMedicaux.FlatAppearance.BorderSize = 0;
            btnDossiersMedicaux.FlatStyle = FlatStyle.Flat;
            btnDossiersMedicaux.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDossiersMedicaux.ForeColor = Color.White;
            btnDossiersMedicaux.Location = new Point(0, 448);
            btnDossiersMedicaux.Margin = new Padding(5, 5, 5, 5);
            btnDossiersMedicaux.Name = "btnDossiersMedicaux";
            btnDossiersMedicaux.Size = new Size(406, 96);
            btnDossiersMedicaux.TabIndex = 5;
            btnDossiersMedicaux.Text = "Dossiers Médicaux";
            btnDossiersMedicaux.UseVisualStyleBackColor = true;
            btnDossiersMedicaux.Click += btnDossiersMedicaux_Click;

            // 
            // btnConsultations
            // 
            btnConsultations.Dock = DockStyle.Top;
            btnConsultations.FlatAppearance.BorderSize = 0;
            btnConsultations.FlatStyle = FlatStyle.Flat;
            btnConsultations.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConsultations.ForeColor = Color.White;
            btnConsultations.Location = new Point(0, 256);
            btnConsultations.Margin = new Padding(5, 5, 5, 5);
            btnConsultations.Name = "btnConsultations";
            btnConsultations.Size = new Size(406, 96);
            btnConsultations.TabIndex = 2;
            btnConsultations.Text = "Consultations";
            btnConsultations.UseVisualStyleBackColor = true;
            btnConsultations.Click += btnConsultations_Click;
            // 
            // btnPatients
            // 
            btnPatients.Dock = DockStyle.Top;
            btnPatients.FlatAppearance.BorderSize = 0;
            btnPatients.FlatStyle = FlatStyle.Flat;
            btnPatients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPatients.ForeColor = Color.White;
            btnPatients.Location = new Point(0, 160);
            btnPatients.Margin = new Padding(5, 5, 5, 5);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(406, 96);
            btnPatients.TabIndex = 1;
            btnPatients.Text = "Patients";
            btnPatients.UseVisualStyleBackColor = true;
            btnPatients.Click += btnPatients_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(lblWelcome);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(5, 5, 5, 5);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(406, 160);
            panelLogo.TabIndex = 0;

           



            // 
            // lblWelcome
            // 
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Margin = new Padding(5, 0, 5, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(406, 160);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bienvenue Dr.";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(406, 0);
            panelMain.Margin = new Padding(5, 5, 5, 5);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1515, 1166);
            panelMain.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1921, 1166);
            Controls.Add(panelMain);
            Controls.Add(panelMenu);
            Margin = new Padding(5, 5, 5, 5);
            MinimumSize = new Size(1934, 1186);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Système de Gestion Médicale";
            Load += MainForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelMenu;
        private Panel panelLogo;
        private Label lblWelcome;
        private Button btnPatients;
        private Button btnDossiersMedicaux;
        private Button btnPrescriptions;
        private Button btnConsultations;
        private Button btnLogout;
        private Panel panelMain;
    }
} 