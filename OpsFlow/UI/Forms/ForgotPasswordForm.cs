using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs;

namespace OpsFlow.UI.Forms
{
    public partial class ForgotPasswordForm : BaseForm
    {
        private readonly IEmailService _emailService;
        private readonly ISecurityService _securityService;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            _emailService = new EmailService();
            _securityService = new SecurityService();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e) { }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
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

            string originalText = btnResetPassword.Text;
            btnResetPassword.Enabled = false;
            btnResetPassword.Text = "İşleniyor...";

            try
            {
                await Task.Run(async () =>
                {
                    var connectionService = new DatabaseConnectionService();
                    using (var context = connectionService.CreateContext())
                    {
                        var userService = new UserService(context);
                        bool userExists = userService.UserExists(email);

                        if (!userExists)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                Notifier.Show("Hata", "Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.", NotificationType.Error);
                            });
                            return;
                        }

                        string code = _securityService.CreateVerificationSession(email);

                        await _emailService.SendEmailAsync(email, "OpsFlow Doğrulama Kodu", code);

                        this.Invoke((MethodInvoker)delegate
                        {
                            VerificationForm verificationForm = new VerificationForm(email);
                            verificationForm.FormClosed += (s, args) => this.Close();
                            verificationForm.Show();
                            this.Hide();
                        });
                    }
                });
            }
            catch (BusinessException ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Notifier.Show("Sınır Aşıldı", ex.Message, NotificationType.Warning);
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Notifier.Show("Sistem Hatası", $"Bir hata oluştu: {ex.Message}", NotificationType.Error);
                });
            }
            finally
            {
                if (!this.IsDisposed && btnResetPassword.Created)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnResetPassword.Enabled = true;
                        btnResetPassword.Text = originalText;
                    });
                }
            }
        }
    }
}