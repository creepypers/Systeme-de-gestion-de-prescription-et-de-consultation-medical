namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    partial class PrescriptionEditForm
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
            lblMedicament = new Label();
            txtMedicament = new TextBox();
            lblDosage = new Label();
            numDosage = new NumericUpDown();
            lblInstructions = new Label();
            txtInstructions = new TextBox();
            lblDuree = new Label();
            numDuree = new NumericUpDown();
            btnSauvegarder = new Button();
            btnAnnuler = new Button();
            ((System.ComponentModel.ISupportInitialize)numDosage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuree).BeginInit();
            SuspendLayout();
            // 
            // lblMedicament
            // 
            lblMedicament.Location = new Point(0, 0);
            lblMedicament.Name = "lblMedicament";
            lblMedicament.Size = new Size(100, 23);
            lblMedicament.TabIndex = 0;
            // 
            // txtMedicament
            // 
            txtMedicament.Location = new Point(0, 0);
            txtMedicament.Name = "txtMedicament";
            txtMedicament.Size = new Size(100, 39);
            txtMedicament.TabIndex = 1;
            // 
            // lblDosage
            // 
            lblDosage.Location = new Point(0, 0);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(100, 23);
            lblDosage.TabIndex = 2;
            // 
            // numDosage
            // 
            numDosage.Location = new Point(0, 0);
            numDosage.Name = "numDosage";
            numDosage.Size = new Size(120, 39);
            numDosage.TabIndex = 3;
            // 
            // lblInstructions
            // 
            lblInstructions.Location = new Point(0, 0);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(100, 23);
            lblInstructions.TabIndex = 4;
            // 
            // txtInstructions
            // 
            txtInstructions.Location = new Point(0, 0);
            txtInstructions.Name = "txtInstructions";
            txtInstructions.Size = new Size(100, 39);
            txtInstructions.TabIndex = 5;
            // 
            // lblDuree
            // 
            lblDuree.Location = new Point(0, 0);
            lblDuree.Name = "lblDuree";
            lblDuree.Size = new Size(100, 23);
            lblDuree.TabIndex = 6;
            // 
            // numDuree
            // 
            numDuree.Location = new Point(0, 0);
            numDuree.Name = "numDuree";
            numDuree.Size = new Size(120, 39);
            numDuree.TabIndex = 7;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Location = new Point(0, 0);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(75, 23);
            btnSauvegarder.TabIndex = 8;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(0, 0);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(75, 23);
            btnAnnuler.TabIndex = 9;
            // 
            // PrescriptionEditForm
            // 
            ClientSize = new Size(474, 329);
            Controls.Add(lblMedicament);
            Controls.Add(txtMedicament);
            Controls.Add(lblDosage);
            Controls.Add(numDosage);
            Controls.Add(lblInstructions);
            Controls.Add(txtInstructions);
            Controls.Add(lblDuree);
            Controls.Add(numDuree);
            Controls.Add(btnSauvegarder);
            Controls.Add(btnAnnuler);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrescriptionEditForm";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Prescription";
            ((System.ComponentModel.ISupportInitialize)numDosage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuree).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureLabel(Label lbl, string text, int top)
        {
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, top);
        }

        private void ConfigureTextBox(TextBox txt, int top, bool multiline = false)
        {
            txt.Location = new Point(20, top);
            txt.Size = new Size(440, multiline ? 60 : 30);
            txt.Multiline = multiline;
        }

        private void ConfigureNumericUpDown(NumericUpDown num, int top)
        {
            num.Location = new Point(20, top);
            num.Size = new Size(440, 30);
            num.Minimum = 1;
            num.Maximum = 1000;
        }

        private void ConfigureButton(Button btn, string text, bool isPrimary)
        {
            btn.Text = text;
            btn.Size = new Size(100, 35);
            btn.Location = new Point(isPrimary ? 360 : 250, 320);
            btn.BackColor = isPrimary ? Color.FromArgb(20, 39, 78) : Color.FromArgb(180, 180, 180);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += isPrimary ? btnSauvegarder_Click : btnAnnuler_Click;
        }

        private Label lblMedicament;
        private TextBox txtMedicament;
        private Label lblDosage;
        private NumericUpDown numDosage;
        private Label lblInstructions;
        private TextBox txtInstructions;
        private Label lblDuree;
        private NumericUpDown numDuree;
        private Button btnSauvegarder;
        private Button btnAnnuler;
    }
} 