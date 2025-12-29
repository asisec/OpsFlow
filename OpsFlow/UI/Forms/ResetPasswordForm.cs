using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs;

namespace OpsFlow.UI.Forms
{
    public partial class ResetPasswordForm : BaseForm
    {
        private readonly string _email;
        private readonly IDatabaseConnectionService _dbService;
        private readonly ISecurityService _securityService;

        public ResetPasswordForm(string email)
        {
            InitializeComponent();
            _email = email;
            _dbService = new DatabaseConnectionService();
            _securityService = new SecurityService();
        }

        public ResetPasswordForm()
        {
            InitializeComponent();
            _dbService = new DatabaseConnectionService();
            _securityService = new SecurityService();
            _email = string.Empty;
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                Notifier.Show("Hata", "Girdiğiniz şifreler birbiriyle uyuşmuyor!", NotificationType.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_email))
            {
                Notifier.Show("Eksik Bilgi", "E-posta adresi sistem tarafından alınamadı. Lütfen işlemi baştan başlatın.", NotificationType.Error);
                return;
            }

            try
            {
                using (var context = _dbService.CreateContext())
                {
                    var userService = new UserService(context);
                    userService.ResetPassword(_email, txtPassword.Text);

                    _securityService.ClearSession(_email);

                    Notifier.Show("Başarılı", "Şifreniz başarıyla güncellendi. Yeni şifrenizle giriş yapabilirsiniz.", NotificationType.Success);

                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Close();
                }
            }
            catch (ValidationException ex)
            {
                Notifier.Show("Uyarı", ex.Message, NotificationType.Warning);
            }
            catch (Exception ex)
            {
                string errorMessage = "Sistem hatası nedeniyle şifre güncellenemedi.";
                if (ex.InnerException != null)
                {
                    errorMessage += "\nDetay: " + ex.InnerException.Message;
                }
                Notifier.Show("Hata", errorMessage, NotificationType.Error);
            }
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}