namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    partial class PatientEditForm
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
            // Initialisation des composants
            lblNom = new Label();
            txtNom = new TextBox();
            lblDateNaissance = new Label();
            dtpDateNaissance = new DateTimePicker();
            lblAdresse = new Label();
            txtAdresse = new TextBox();
            lblTelephone = new Label();
            txtTelephone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSauvegarder = new Button();
            btnAnnuler = new Button();
            panelForm = new Panel();

            // Configuration du formulaire principal
            this.Text = "Gestion Patient";
            this.ClientSize = new Size(500, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Padding = new Padding(20);

            // Configuration du panel
            panelForm.Dock = DockStyle.Fill;
            panelForm.Padding = new Padding(20);

            // Configuration des labels
            ConfigureLabel(lblNom, "Nom du patient *", 0);
            ConfigureLabel(lblDateNaissance, "Date de naissance *", 1);
            ConfigureLabel(lblAdresse, "Adresse *", 2);
            ConfigureLabel(lblTelephone, "Numéro de téléphone *", 3);
            ConfigureLabel(lblEmail, "Adresse email", 4);

            // Configuration des champs de saisie
            ConfigureTextBox(txtNom, 0);
            ConfigureDateTimePicker(dtpDateNaissance, 1);
            ConfigureTextBox(txtAdresse, 2);
            ConfigureTextBox(txtTelephone, 3);
            ConfigureTextBox(txtEmail, 4);

            // Configuration des boutons
            var buttonPanel = new Panel
            {
                Height = 40,
                Dock = DockStyle.Bottom,
                Padding = new Padding(0, 5, 0, 0)
            };

            btnSauvegarder.Text = "Sauvegarder";
            btnSauvegarder.Size = new Size(100, 35);
            btnSauvegarder.BackColor = Color.FromArgb(20, 39, 78);
            btnSauvegarder.ForeColor = Color.White;
            btnSauvegarder.FlatStyle = FlatStyle.Flat;
            btnSauvegarder.Dock = DockStyle.Right;
            btnSauvegarder.Click += btnSauvegarder_Click;

            btnAnnuler.Text = "Annuler";
            btnAnnuler.Size = new Size(100, 35);
            btnAnnuler.BackColor = Color.FromArgb(180, 180, 180);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.Dock = DockStyle.Right;
            btnAnnuler.Margin = new Padding(0, 0, 10, 0);
            btnAnnuler.Click += btnAnnuler_Click;

            buttonPanel.Controls.Add(btnSauvegarder);
            buttonPanel.Controls.Add(btnAnnuler);

            // Ajout des contrôles au formulaire
            this.Controls.Add(panelForm);
            this.Controls.Add(buttonPanel);
            panelForm.Controls.AddRange(new Control[] {
                lblNom, txtNom,
                lblDateNaissance, dtpDateNaissance,
                lblAdresse, txtAdresse,
                lblTelephone, txtTelephone,
                lblEmail, txtEmail
            });
        }

        private void ConfigureLabel(Label label, string text, int position)
        {
            label.Text = text;
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            label.Location = new Point(0, position * 70);
            label.Margin = new Padding(0, 10, 0, 0);
        }

        private void ConfigureTextBox(TextBox textBox, int position)
        {
            textBox.Location = new Point(0, position * 70 + 25);
            textBox.Size = new Size(440, 30);
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ConfigureDateTimePicker(DateTimePicker dtp, int position)
        {
            dtp.Location = new Point(0, position * 70 + 25);
            dtp.Size = new Size(440, 30);
            dtp.Font = new Font("Segoe UI", 10F);
            dtp.Format = DateTimePickerFormat.Short;
        }

        private Label lblNom;
        private TextBox txtNom;
        private Label lblDateNaissance;
        private DateTimePicker dtpDateNaissance;
        private Label lblAdresse;
        private TextBox txtAdresse;
        private Label lblTelephone;
        private TextBox txtTelephone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnSauvegarder;
        private Button btnAnnuler;
        private Panel panelForm;
    }
} 