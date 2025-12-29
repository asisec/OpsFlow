using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Forms
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            if (this.HeaderPanel != null)
            {
                this.HeaderPanel.SendToBack();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void sidebarNavList_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}