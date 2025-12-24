using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
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

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            string code = $"{txtDigit1.Text}{txtDigit2.Text}{txtDigit3.Text}{txtDigit4.Text}{txtDigit5.Text}{txtDigit6.Text}";

            if (code.Length < 6)
            {
                MessageBox.Show("Lütfen 6 haneli kodu eksiksiz giriniz.", "Eksik Kod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _securityService.VerifyCode(_email, code);

                MessageBox.Show("Kod doğrulandı! Şifre sıfırlama ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetPasswordForm resetForm = new ResetPasswordForm(_email);
                resetForm.Show();
                this.Hide();

                resetForm.FormClosed += (s, args) => this.Close();
            }
            catch (VerificationException ex)
            {
                MessageBox.Show(ex.Message, "Hatalı Kod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TemizleVeBasaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TemizleVeBasaDon();
            }
        }

        private void TemizleVeBasaDon()
        {
            txtDigit1.Clear();
            txtDigit2.Clear();
            txtDigit3.Clear();
            txtDigit4.Clear();
            txtDigit5.Clear();
            txtDigit6.Clear();
            txtDigit1.Focus();
        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {
        }

        private void SadeceRakamGirisi(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SiradakiKutuyaGec(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox suankiKutu = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (suankiKutu.Text.Length == 1)
            {
                this.SelectNextControl(suankiKutu, true, true, true, true);
            }
        }

        private void GeriyeDon(object sender, KeyEventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox suankiKutu = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (e.KeyCode == Keys.Back && suankiKutu.Text.Length == 0)
            {
                e.SuppressKeyPress = true;
                bool odakDegisti = this.SelectNextControl(suankiKutu, false, true, true, true);

                if (odakDegisti && this.ActiveControl is Guna.UI2.WinForms.Guna2TextBox)
                {
                    Guna.UI2.WinForms.Guna2TextBox oncekiKutu = (Guna.UI2.WinForms.Guna2TextBox)this.ActiveControl;
                    oncekiKutu.Clear();
                }
            }
        }
    }
}