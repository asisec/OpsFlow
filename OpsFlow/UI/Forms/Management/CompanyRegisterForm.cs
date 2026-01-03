using OpsFlow.Core.Enums;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs.Notifications;

namespace OpsFlow.UI.Forms.Management
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
                Notifier.Show("Hata", "Lütfen şirket adı ve vergi numarasını giriniz.", NotificationType.Error);
                return;
            }

            Notifier.Show("Başarılı", "Şirket kaydı başarıyla alındı!", NotificationType.Success);

            this.Close();
        }
    }
}