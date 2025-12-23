using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class VerificationForm : Form
    {
        public VerificationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {

        }

        private void SadeceRakamGirisi(object sender, KeyPressEventArgs e)
        {
            // Gelen tuş Rakam DEĞİLSE (!) ve Kontrol tuşu (Silme/Backspace) DEĞİLSE (!)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // İşlemi iptal et (Yani kutuya yazma)
            }
        }

        private void SiradakiKutuyaGec(object sender, EventArgs e)
        {
            // Olayı tetikleyen kutuyu (sender) yakalıyoruz
            Guna.UI2.WinForms.Guna2TextBox suankiKutu = (Guna.UI2.WinForms.Guna2TextBox)sender;

            // Eğer kutunun içine 1 karakter yazıldıysa
            if (suankiKutu.Text.Length == 1)
            {
                // TabIndex sırasına göre bir sonraki elemana odaklan (Focus)
                this.SelectNextControl(suankiKutu, true, true, true, true);
            }
        }

        private void GeriyeDon(object sender, KeyEventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox suankiKutu = (Guna.UI2.WinForms.Guna2TextBox)sender;

            // Eğer Backspace'e basıldıysa VE şu anki kutu zaten boşsa
            if (e.KeyCode == Keys.Back && suankiKutu.Text.Length == 0)
            {
                e.SuppressKeyPress = true; // Tuşun varsayılan işlemini durdur (Bip sesini keser)

                // 1. Bir önceki kutuya odaklan (forward: false)
                bool odakDegisti = this.SelectNextControl(suankiKutu, false, true, true, true);

                // 2. Eğer odak başarıyla değiştiyse ve yeni yer bir TextBox ise
                if (odakDegisti && this.ActiveControl is Guna.UI2.WinForms.Guna2TextBox)
                {
                    // Yeni odaklandığımız (bir önceki) kutuyu yakala
                    Guna.UI2.WinForms.Guna2TextBox oncekiKutu = (Guna.UI2.WinForms.Guna2TextBox)this.ActiveControl;

                    // VE İÇİNİ TEMİZLE
                    oncekiKutu.Clear();
                }
            }
        }
    }
}
