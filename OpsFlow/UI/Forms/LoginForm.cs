using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkForgotText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
