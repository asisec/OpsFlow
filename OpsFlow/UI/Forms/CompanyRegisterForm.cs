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
    public partial class CompanyRegisterForm : BaseForm
    {
        public CompanyRegisterForm()
        {
            InitializeComponent();
            this.btnSaveCompany.Click += new EventHandler(btnSaveCompany_Click);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveCompany_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtTaxNumber.Text))
            {
                MessageBox.Show("Lütfen şirket adı ve vergi numarasını giriniz.");
                return;
            }

            MessageBox.Show("Şirket kaydı başarıyla alındı!");

            this.Close();
        }
    }
}
