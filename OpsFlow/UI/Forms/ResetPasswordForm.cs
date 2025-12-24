using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class ResetPasswordForm : Form
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
                MessageBox.Show("Şifreler uyuşmuyor!");
                return;
            }

            if (string.IsNullOrEmpty(_email))
            {
                MessageBox.Show("E-posta adresi alınamadı. Lütfen işlemi baştan başlatın.");
                return;
            }

            try
            {
                using (var context = _dbService.CreateContext())
                {
                    var userService = new UserService(context);

                    userService.ResetPassword(_email, txtPassword.Text);

                    _securityService.ClearSession(_email);

                    MessageBox.Show("Şifreniz başarıyla değiştirildi. Giriş yapabilirsiniz.");

                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Close();
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                string hataMesaji = ex.Message;
                if (ex.InnerException != null)
                {
                    hataMesaji += "\nDetay: " + ex.InnerException.Message;
                }
                MessageBox.Show("Hata: " + hataMesaji);
            }
        }
    }
}