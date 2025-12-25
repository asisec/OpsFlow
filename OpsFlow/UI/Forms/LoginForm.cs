using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Dialogs;
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

        private void lnkForgotText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionService = new DatabaseConnectionService();

                using (var context = connectionService.CreateContext())
                {
                    var userService = new UserService(context);

                    var user = userService.Authenticate(txtEmail.Text.Trim(), txtPassword.Text.Trim());

                    Notifier.Show("Başarılı", "Giriş yapıldı, yönlendiriliyorsunuz...", NotificationType.Success);

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();

                    mainForm.FormClosed += (s, args) => this.Close();
                }
            }
            catch (ValidationException ex)
            {
                Notifier.Show("Eksik Bilgi", ex.Message, NotificationType.Warning);
            }
            catch (AuthenticationException ex)
            {
                Notifier.Show("Giriş Başarısız", ex.Message, NotificationType.Error);
            }
            catch (Exception ex)
            {
                Notifier.Show("Sistem Hatası", $"Beklenmedik bir hata oluştu: {ex.Message}", NotificationType.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void timerFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                tmrFadeIn.Stop();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }
    }
}