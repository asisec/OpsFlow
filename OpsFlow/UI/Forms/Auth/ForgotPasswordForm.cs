using OpsFlow.Core.Enums;
using OpsFlow.Core.Services;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs;

namespace OpsFlow.UI.Forms
{
    public partial class ForgotPasswordForm : BaseForm
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WindowManager.Switch<LoginForm>(this);
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (btnResetPassword.Text == "İşleniyor...")
                return;

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                Notifier.Show("Eksik Bilgi", "Lütfen geçerli bir e-posta adresi giriniz.", NotificationType.Warning);
                return;
            }

            btnResetPassword.Enabled = false;
            btnResetPassword.Text = "İşleniyor...";

            try
            {
                bool userExists = await Task.Run(() =>
                {
                    var connectionService = new DatabaseConnectionService();
                    using (var context = connectionService.CreateContext())
                    {
                        var userService = new UserService(context);
                        return userService.UserExists(email);
                    }
                });

                if (!userExists)
                {
                    Notifier.Show("Hata", "Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.", NotificationType.Error);
                    btnResetPassword.Enabled = true;
                    btnResetPassword.Text = "Şifremi Sıfırla";
                    return;
                }

                WindowManager.Switch<VerificationForm>(this, [email]);
            }
            catch (Exception ex)
            {
                Notifier.Show("Sistem Hatası", $"Bir hata oluştu: {ex.Message}", NotificationType.Error);
                btnResetPassword.Enabled = true;
                btnResetPassword.Text = "Şifremi Sıfırla";
            }
        }
    }
}