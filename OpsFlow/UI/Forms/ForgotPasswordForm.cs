using OpsFlow.Core.Services;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Core;

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
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnResetPassword.Enabled = true;
                    btnResetPassword.Text = "Şifremi Sıfırla";
                    return;
                }

                WindowManager.Switch<VerificationForm>(this, [email]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnResetPassword.Enabled = true;
                btnResetPassword.Text = "Şifremi Sıfırla";
            }
        }
    }
}