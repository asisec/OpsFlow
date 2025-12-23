using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class ResetPasswordForm : Form
    {
        private void BildirimGoster(string baslik, string mesaj)
        {
            lblSuccessTitle.Text = baslik;
            lblSuccessMessage.Text = mesaj;

            pnlSuccessToast.BringToFront(); // En öne getir
            pnlSuccessToast.Visible = true; // Göster

            tmrAutoClose.Stop();
            tmrAutoClose.Start(); // 3 saniye saymaya başla
        }
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnCloseError_Click(object sender, EventArgs e)
        {
            tmrAutoClose.Stop();
            pnlSuccessToast.Visible = false;
        }

        private void tmrAutoClose_Tick(object sender, EventArgs e)
        {
            tmrAutoClose.Stop();
            pnlSuccessToast.Visible = false;
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            BildirimGoster("Şifreniz Oluşturuldu", "Şifreniz başarılı bir şekilde oluşturuldu");
        }
    }
}