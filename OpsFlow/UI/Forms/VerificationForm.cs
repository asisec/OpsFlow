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

        private void btnCloseError_Click_1(object sender, EventArgs e)
        {
            tmrAutoClose.Stop();
            pnlErrorToast.Visible = false;
        }

        private void tmrAutoClose_Tick_1(object sender, EventArgs e)
        {
            tmrAutoClose.Stop();
            pnlErrorToast.Visible = false;
        }
    }
}
