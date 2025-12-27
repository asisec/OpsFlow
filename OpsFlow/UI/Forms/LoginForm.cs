using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Dialogs;
using System;
using System.Threading.Tasks;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Giriş yapılıyor...")
                return;

            System.Drawing.Font originalFont = btnLogin.Font;
            btnLogin.Text = "Giriş yapılıyor...";

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                await Task.Run(() =>
                {
                    var connectionService = new DatabaseConnectionService();
                    using (var context = connectionService.CreateContext())
                    {
                        var userService = new UserService(context);
                        var user = userService.Authenticate(email, password);
                    }
                });

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

                Notifier.Show("Başarılı", "Giriş başarılı, yönlendiriliyorsunuz...", NotificationType.Success);

                mainForm.FormClosed += (s, args) => this.Close();
            }
            catch (ValidationException ex)
            {
                Notifier.Show("Doğrulama Hatası", ex.Message, NotificationType.Warning);
            }
            catch (AuthenticationException ex)
            {
                Notifier.Show("Giriş Başarısız", ex.Message, NotificationType.Error);
            }
            catch (Exception ex)
            {
                Notifier.Show("Sistem Hatası", $"Beklenmedik bir hata oluştu: {ex.Message}", NotificationType.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnLogin.Text = "Giriş Yap";
                    btnLogin.Font = originalFont;
                }
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