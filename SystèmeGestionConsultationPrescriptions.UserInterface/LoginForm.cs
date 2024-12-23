using SystèmeGestionConsultationPrescriptions.core.Interfaces;
using SystèmeGestionConsultationPrescriptions.Core.Entities;
using SystèmeGestionConsultationPrescriptions.UserInterface.Forms;
using SystèmeGestionConsultationPrescriptions.Core.Services;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Repository;
using SystèmeGestionConsultationPrescriptions.Infrastructure;

namespace SystèmeGestionConsultationPrescriptions.UserInterface
{
    public partial class LoginForm : Form
    {
        private readonly IAuthenticationService _authService;

        public LoginForm()
        {
            InitializeComponent();
            var dbContext = new SystèmeGestionConsultationPrescriptionsDBContext();
            var medecinRepo = new MedecinRepository(dbContext);
            var sessionRepo = new SessionRepository(dbContext);
            _authService = new AuthenticationService(sessionRepo, medecinRepo);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var medecin = await _authService.AuthenticateAsync(username, password);
                if (medecin != null)
                {
                    var session = await _authService.CreateSessionAsync(medecin.Id);
                    var mainForm = new MainForm(medecin, session.Id);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
} 