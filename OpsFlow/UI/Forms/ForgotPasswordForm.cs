using OpsFlow.Core.Enums;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Dialogs;
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

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                Notifier.Show("Eksik Bilgi", "Lütfen geçerli bir e-posta adresi giriniz.", NotificationType.Warning);
                return;
            }

            try
            {
                var connectionService = new DatabaseConnectionService();
                using (var context = connectionService.CreateContext())
                {
                    var userService = new UserService(context);
                    bool userExists = userService.UserExists(email);

                    if (userExists)
                    {
                        string code = _securityService.CreateVerificationSession(email);

                        _emailService.SendEmail(email, "OpsFlow Doğrulama Kodu", $"Doğrulama kodunuz: {code}");

                        Notifier.Show("Bilgi", "Doğrulama kodu e-posta adresinize gönderildi.", NotificationType.Info);

                        VerificationForm verificationForm = new VerificationForm(email);
                        verificationForm.Show();
                        this.Hide();
                        verificationForm.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        Notifier.Show("Hata", "Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.", NotificationType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Notifier.Show("Sistem Hatası", $"Bir hata oluştu: {ex.Message}", NotificationType.Error);
            }
        }
    }
}