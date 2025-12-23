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
    }
}
