using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
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


        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var connectionService = new DatabaseConnectionService();

                using (var context = connectionService.CreateContext())
                {
                    var userService = new UserService(context);

                    var user = userService.Authenticate(txtEmail.Text.Trim(), txtPassword.Text.Trim());

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();

                    mainForm.FormClosed += (s, args) => this.Close();
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (AuthenticationException ex)
            {
                MessageBox.Show(ex.Message, "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmedik bir hata oluştu: {ex.Message}", "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}