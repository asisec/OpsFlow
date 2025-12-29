using Guna.UI2.WinForms;

using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Services;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs;

namespace OpsFlow.UI.Forms
{
    public partial class VerificationForm : BaseForm
    {
        private readonly string _email;
        private readonly ISecurityService _securityService;
        private readonly IEmailService _emailService;
        private bool _isResending = false;
        private bool _isLimitExceeded = false;

        public VerificationForm(string email)
        {
            InitializeComponent();
            _email = email;
            _securityService = new SecurityService();
            _emailService = new EmailService();

            this.Load += (s, e) =>
            {
                txtDigit1.Focus();
                _ = SendInitialCodeFlowAsync();
            };
        }

        public VerificationForm()
        {
            InitializeComponent();
            _email = string.Empty;
            _securityService = new SecurityService();
            _emailService = new EmailService();
        }

        private async Task SendInitialCodeFlowAsync()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Notifier.Show("İşlem Başladı", "Doğrulama kodu oluşturuluyor ve gönderiliyor...", NotificationType.Information);
                });

                string code = await Task.Run(() => _securityService.CreateVerificationSession(_email));
                await _emailService.SendEmailAsync(_email, "OpsFlow Doğrulama Kodu", code);

                this.Invoke((MethodInvoker)delegate
                {
                    Notifier.Show("Kod Gönderildi", "Doğrulama kodu e-posta adresinize ulaştırıldı.", NotificationType.Success);
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
                    Notifier.Show("Hata", "Kod gönderilemedi: " + ex.Message, NotificationType.Error);
                });
            }
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            string code = $"{txtDigit1.Text}{txtDigit2.Text}{txtDigit3.Text}{txtDigit4.Text}{txtDigit5.Text}{txtDigit6.Text}";

            if (code.Length < 6)
            {
                Notifier.Show("Eksik Kod", "Lütfen 6 haneli kodu eksiksiz giriniz.", NotificationType.Warning);
                return;
            }

            try
            {
                _securityService.VerifyCode(_email, code);
                Notifier.Show("Başarılı", "Kod doğrulandı! Yeni şifrenizi giriniz.", NotificationType.Success);
                WindowManager.Switch<ResetPasswordForm>(this, [_email]);
            }
            catch (VerificationException ex)
            {
                Notifier.Show("Doğrulama Hatası", ex.Message, NotificationType.Error);
                ClearAndResetInput();
            }
            catch (Exception ex)
            {
                Notifier.Show("Hata", "Sistem hatası: " + ex.Message, NotificationType.Error);
                ClearAndResetInput();
            }
        }

        private async void lnkResendCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_isResending || _isLimitExceeded) return;

            string originalText = "kodu tekrar gönder";
            _isResending = true;
            lnkResendCode.Text = "gönderiliyor...";
            lnkResendCode.LinkColor = Color.DarkGray;
            lnkResendCode.Cursor = Cursors.WaitCursor;

            try
            {
                string newCode = await Task.Run(() => _securityService.ResendVerificationCode(_email));
                await _emailService.SendEmailAsync(_email, "OpsFlow Yeni Doğrulama Kodu", newCode);

                this.Invoke((MethodInvoker)delegate
                {
                    Notifier.Show("Kod Gönderildi", "Yeni doğrulama kodu e-posta adresinize ulaştırıldı.", NotificationType.Success);
                });
            }
            catch (BusinessException ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    _isLimitExceeded = true;
                    lnkResendCode.Text = "kod alma sınırı aşıldı";
                    lnkResendCode.LinkColor = Color.FromArgb(150, 150, 150);
                    lnkResendCode.Cursor = Cursors.No;
                    Notifier.Show("Sınır Aşıldı", ex.Message, NotificationType.Warning);
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Notifier.Show("Hata", "Kod gönderilirken bir sorun oluştu: " + ex.Message, NotificationType.Error);
                });
            }
            finally
            {
                if (!this.IsDisposed && !_isLimitExceeded)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lnkResendCode.Text = originalText;
                        lnkResendCode.LinkColor = Color.FromArgb(108, 64, 200);
                        lnkResendCode.Cursor = Cursors.Hand;
                        _isResending = false;
                    });
                }
            }
        }

        private void ClearAndResetInput()
        {
            txtDigit1.Clear(); txtDigit2.Clear(); txtDigit3.Clear();
            txtDigit4.Clear(); txtDigit5.Clear(); txtDigit6.Clear();
            txtDigit1.Focus();
        }

        private void HandleDigitKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void HandleDigitTextChanged(object sender, EventArgs e)
        {
            var currentBox = (Guna2TextBox)sender;
            if (currentBox.Text.Length == 1)
                this.SelectNextControl(currentBox, true, true, true, true);
        }

        private void HandleDigitKeyDown(object sender, KeyEventArgs e)
        {
            var currentBox = (Guna2TextBox)sender;
            if (e.KeyCode == Keys.Back && currentBox.Text.Length == 0)
            {
                e.SuppressKeyPress = true;
                bool focusChanged = this.SelectNextControl(currentBox, false, true, true, true);
                if (focusChanged && this.ActiveControl is Guna2TextBox previousBox)
                {
                    previousBox.Clear();
                    previousBox.Focus();
                }
            }
        }
    }
}