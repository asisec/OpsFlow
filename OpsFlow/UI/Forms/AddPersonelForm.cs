using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms
{
    public partial class AddPersonelForm : Form
    {
        public AddPersonelForm()
        {
            InitializeComponent();
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
           private void guna2Button1_Click(object sender, EventArgs e)
           {
            Form modalBackground = new Form();

            using (CompanyRegisterForm popup = new CompanyRegisterForm())
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = 0.50d;
                modalBackground.BackColor = Color.Black;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.Show(this);
                popup.Owner = modalBackground;
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.ShowDialog();
                modalBackground.Dispose();
            }
           }
    }
}