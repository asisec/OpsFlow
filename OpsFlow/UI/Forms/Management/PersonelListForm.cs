using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Management;

public partial class PersonelListForm : Form
{
    public PersonelListForm()
    {
        InitializeComponent();
        cmbFilterDept.DropDownStyle = ComboBoxStyle.DropDown;
        cmbFilterRole.DropDownStyle = ComboBoxStyle.DropDown;
        cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDown;
        cmbFilterDept.Text = "Departman";
        cmbFilterRole.Text = "Rol";
        cmbFilterStatus.Text = "Durum";
    }

    private void pnlHeader_Paint(object sender, PaintEventArgs e)
    {

    }

    private void guna2HtmlLabel3_Click(object sender, EventArgs e)
    {

    }

    private void btnAddNewMember_Click(object sender, EventArgs e)
    {
        AddPersonelForm frm = new AddPersonelForm();
        frm.TopLevel = false;
        frm.FormBorderStyle = FormBorderStyle.None;
        frm.Dock = DockStyle.Fill;
        Panel? anaPanel = this.Parent as Panel;
        if (anaPanel != null)
        {
            anaPanel.Controls.Clear();
            anaPanel.Controls.Add(frm);
            frm.Show();
        }
    }
}