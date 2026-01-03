using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Management;

public partial class LogoutForm : Form
{
    public LogoutForm()
    {
        InitializeComponent();
    }

    private void btnConfirmLogout_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Yes;
        this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.No;
        this.Close();
    }
}
