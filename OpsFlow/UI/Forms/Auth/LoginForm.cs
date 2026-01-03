using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Core.Services;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Main;
using OpsFlow.UI.Forms.Dialogs.Notifications;

namespace OpsFlow.UI.Forms.Auth;

public partial class LoginForm : BaseForm
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void lnkForgotText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        WindowManager.Switch<ForgotPasswordForm>(this);
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (btnLogin.Text == "Giriş yapılıyor...")
            return;

        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Notifier.Show("Eksik Bilgi", "Lütfen e-posta ve şifre alanlarını doldurunuz.", NotificationType.Warning);
            return;
        }

        btnLogin.Text = "Giriş yapılıyor...";
        btnLogin.Enabled = false;

        try
        {
            using var context = DatabaseManager.CreateContext();
            var userService = new UserService(context);

            var user = await Task.Run(() => userService.Authenticate(email, password));
            UserSession.StartSession(user);

            Notifier.Show("Giriş Başarılı", "Hoş geldiniz, yönlendiriliyorsunuz...", NotificationType.Success);
            WindowManager.Switch<MainForm>(this);
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
            var msg = "Beklenmedik bir hata oluştu.";
            if (ex is OpsFlow.Core.Exceptions.DatabaseQueryException && ex.InnerException != null)
                msg += $"\nDB Hatası: {ex.InnerException.Message}";
            else
                msg += $"\n{ex.Message}";
            Notifier.Show("Sistem Hatası", msg, NotificationType.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                btnLogin.Text = "Giriş Yap";
                btnLogin.Enabled = true;
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