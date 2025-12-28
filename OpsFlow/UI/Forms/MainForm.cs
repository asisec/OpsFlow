using Guna.UI2.WinForms;
using OpsFlow.UI.Forms.Dialogs;
using System;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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