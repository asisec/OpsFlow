using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly IEmailService _emailService;
        private readonly ISecurityService _securityService;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            _emailService = new EmailService();
            _securityService = new SecurityService();
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Lütfen bir e-posta adresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var connectionService = new DatabaseConnectionService();
                using (var context = connectionService.CreateContext())
                {
                    var userService = new UserService(context);
                    bool exists = userService.UserExists(email);

                    if (exists)
                    {
                        // Kod oluşturuluyor
                        string code = _securityService.CreateVerificationSession(email);

                        // E-posta gönderiliyor (Test mesajı kaldırıldı)
                        _emailService.SendEmail(email, "OpsFlow Doğrulama Kodu", $"Doğrulama kodunuz: {code}");

                        // Doğrulama ekranına geçiş
                        VerificationForm vForm = new VerificationForm(email);
                        vForm.Show();
                        this.Hide();
                        vForm.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}