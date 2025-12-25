using Guna.UI2.WinForms;
using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Dialogs;
using System;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class VerificationForm : Form
    {
        private readonly string _email;
        private readonly ISecurityService _securityService;

        public VerificationForm(string email)
        {
            InitializeComponent();
            _email = email;
            _securityService = new SecurityService();
        }

        public VerificationForm()
        {
            InitializeComponent();
            _email = string.Empty;
            _securityService = new SecurityService();
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

                Notifier.Show("Başarılı", "Kod doğrulandı! Şifre sıfırlama ekranına yönlendiriliyorsunuz.", NotificationType.Success);

                ResetPasswordForm resetForm = new ResetPasswordForm(_email);
                resetForm.Show();
                this.Hide();

                resetForm.FormClosed += (s, args) => this.Close();
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
            {
                e.Handled = true;
            }
        }

        private void HandleDigitTextChanged(object sender, EventArgs e)
        {
            var currentBox = (Guna2TextBox)sender;

            if (currentBox.Text.Length == 1)
            {
                this.SelectNextControl(currentBox, true, true, true, true);
            }
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
                }
            }
        }
    }
}