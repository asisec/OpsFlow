using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Management;

public partial class PersonelCard : UserControl
{
    public PersonelCard()
    {
        InitializeComponent();
    }

    private void btnViewProfile_Click(object sender, EventArgs e)
    {
        if (this.FindForm() is Form anaForm)
        {
            Form dimmer = new Form();
            dimmer.FormBorderStyle = FormBorderStyle.None;
            dimmer.BackColor = Color.Black;
            dimmer.Opacity = 0.60d;
            dimmer.ShowInTaskbar = false;
            dimmer.StartPosition = FormStartPosition.Manual;
            dimmer.Location = anaForm.Location;
            dimmer.Size = anaForm.Size;
            using (ProfileEditForm popup = new ProfileEditForm())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                dimmer.Show(anaForm);
                popup.ShowDialog(dimmer);
                dimmer.Close();
            }
        }
    }
}
