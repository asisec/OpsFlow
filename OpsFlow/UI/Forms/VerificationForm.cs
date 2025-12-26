using Guna.UI2.WinForms;
using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Dialogs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class VerificationForm : Form
    {
        private readonly string _email;
        private readonly ISecurityService _securityService;
        private readonly IEmailService _emailService;

        public VerificationForm(string email)
        {
            InitializeComponent();
            _email = email;
            _securityService = new SecurityService();
            _emailService = new EmailService();
        }

        public VerificationForm()
        {
            InitializeComponent();
            _email = string.Empty;
            _securityService = new SecurityService();
            _emailService = new EmailService();
        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {
            txtDigit1.Focus();
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

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

                Notifier.Show("Başarılı", "Kod doğrulandı! Hoş geldiniz.", NotificationType.Success);

                mainForm.FormClosed += (s, args) => this.Close();
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
            string originalText = "kodu tekrar gönder";
            lnkResendCode.Enabled = false;
            lnkResendCode.Text = "Gönderiliyor...";
            lnkResendCode.LinkColor = Color.Gray;

            try
            {
                string newCode = _securityService.ResendVerificationCode(_email);
                await _emailService.SendEmailAsync(_email, "OpsFlow Yeni Doğrulama Kodu", $"Yeni doğrulama kodunuz: {newCode}");
                Notifier.Show("Kod Gönderildi", "Yeni doğrulama kodu başarıyla gönderildi.", NotificationType.Info);
            }
            catch (BusinessException ex)
            {
                Notifier.Show("Sınır Aşıldı", ex.Message, NotificationType.Warning);
            }
            catch (Exception ex)
            {
                Notifier.Show("Hata", "Kod gönderilemedi: " + ex.Message, NotificationType.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    lnkResendCode.Text = originalText;
                    lnkResendCode.Enabled = true;
                    lnkResendCode.LinkColor = Color.FromArgb(108, 64, 200);
                    lnkResendCode.LinkVisited = false;
                    label1.Focus();
                }
            }
        }

        private void ClearAndResetInput()
        {
            txtDigit1.Clear();
            txtDigit2.Clear();
            txtDigit3.Clear();
            txtDigit4.Clear();
            txtDigit5.Clear();
            txtDigit6.Clear();
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
                    previousBox.Clear();
            }
        }
    }
}