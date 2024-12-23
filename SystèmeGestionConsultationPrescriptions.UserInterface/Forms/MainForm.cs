using SystèmeGestionConsultationPrescriptions.Core.Entities;
using System.Windows.Forms;

namespace SystèmeGestionConsultationPrescriptions.UserInterface.Forms
{
    public partial class MainForm : Form
    {
        private readonly Medecin _medecin;
        private readonly int _sessionId;
        private Form? activeForm;

        public MainForm(Medecin medecin, int sessionId)
        {
            InitializeComponent();
            _medecin = medecin;
            _sessionId = sessionId;
            ConfigureWelcomeMessage();
        }

        private void ConfigureWelcomeMessage()
        {
            lblWelcome.Text = $"Bienvenue Dr. {_medecin.Nom} {_medecin.Prenom}";
        }

        private void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDossiersMedicaux_Click(object sender, EventArgs e)
        {
            var dossiersMedicauxForm = new DossiersMedicauxForm(_medecin.Id);
            OpenChildForm(dossiersMedicauxForm);
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            var patientsForm = new PatientsForm(_medecin.Id);
            OpenChildForm(patientsForm);
        }

        private void btnConsultations_Click(object sender, EventArgs e)
        {
            var consultationsForm = new ConsultationsForm(_medecin.Id, _sessionId);
            OpenChildForm(consultationsForm);
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            var prescriptionsForm = new PrescriptionsForm(_medecin.Id, _sessionId);
            OpenChildForm(prescriptionsForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Déconnexion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new LoginForm().Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Add any initialization code here
        }

        

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
} 