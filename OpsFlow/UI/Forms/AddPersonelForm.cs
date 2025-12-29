using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Forms
{
    public partial class AddPersonelForm : BaseForm
    {
        public AddPersonelForm()
        {
            InitializeComponent();
            if (this.HeaderPanel != null) this.HeaderPanel.SendToBack();
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picProfilePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picProfilePhoto.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}