namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    partial class ConsultationEditForm
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
            // Création des contrôles
            lblPatient = new Label();
            cmbPatient = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblMotif = new Label();
            txtMotif = new TextBox();
            lblObservations = new Label();
            txtObservations = new TextBox();
            lblDiagnostic = new Label();
            txtDiagnostic = new TextBox();
            btnSauvegarder = new Button();
            btnAnnuler = new Button();

            // Configuration du formulaire
            this.Text = "Consultation";
            this.Size = new Size(600, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(20);

            // Configuration des contrôles
            ConfigureLabel(lblPatient, "Patient *", 20);
            ConfigureComboBox(cmbPatient, 50);
            ConfigureLabel(lblDate, "Date *", 100);
            ConfigureDateTimePicker(dtpDate, 130);
            ConfigureLabel(lblMotif, "Motif *", 180);
            ConfigureTextBox(txtMotif, 210, 60);
            ConfigureLabel(lblObservations, "Observations", 280);
            ConfigureTextBox(txtObservations, 310, 60);
            ConfigureLabel(lblDiagnostic, "Diagnostic *", 380);
            ConfigureTextBox(txtDiagnostic, 410, 60);

            // Configuration des boutons
            ConfigureButton(btnSauvegarder, "Sauvegarder", true);
            ConfigureButton(btnAnnuler, "Annuler", false);

            // Ajout des contrôles au formulaire
            Controls.AddRange(new Control[] {
                lblPatient, cmbPatient,
                lblDate, dtpDate,
                lblMotif, txtMotif,
                lblObservations, txtObservations,
                lblDiagnostic, txtDiagnostic,
                btnSauvegarder, btnAnnuler
            });
        }

        private void ConfigureLabel(Label lbl, string text, int top)
        {
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, top);
        }

        private void ConfigureTextBox(TextBox txt, int top, int height)
        {
            txt.Location = new Point(20, top);
            txt.Size = new Size(540, height);
            txt.Multiline = height > 30;
        }

        private void ConfigureComboBox(ComboBox cmb, int top)
        {
            cmb.Location = new Point(20, top);
            cmb.Size = new Size(540, 30);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigureDateTimePicker(DateTimePicker dtp, int top)
        {
            dtp.Location = new Point(20, top);
            dtp.Size = new Size(540, 30);
            dtp.Format = DateTimePickerFormat.Short;
        }

        private void ConfigureButton(Button btn, string text, bool isPrimary)
        {
            btn.Text = text;
            btn.Size = new Size(100, 35);
            btn.Location = new Point(isPrimary ? 460 : 350, 420);
            btn.BackColor = isPrimary ? Color.FromArgb(20, 39, 78) : Color.FromArgb(180, 180, 180);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
        }

        private Label lblPatient;
        private ComboBox cmbPatient;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblMotif;
        private TextBox txtMotif;
        private Label lblObservations;
        private TextBox txtObservations;
        private Label lblDiagnostic;
        private TextBox txtDiagnostic;
        private Button btnSauvegarder;
        private Button btnAnnuler;
    }
} 