using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Forms.Management
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

        private void picProfilePhoto_Click_1(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCompanyRegister_Click(object sender, EventArgs e)
        {
            Form dimmer = new Form();
            dimmer.FormBorderStyle = FormBorderStyle.None;
            dimmer.BackColor = Color.Black;
            dimmer.Opacity = 0.60d;
            dimmer.ShowInTaskbar = false;
            dimmer.StartPosition = FormStartPosition.Manual;
            dimmer.Location = this.Location;
            dimmer.Size = this.Size;
            using (CompanyRegisterForm popup = new CompanyRegisterForm())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                dimmer.Show(this);
                popup.ShowDialog(dimmer);
                dimmer.Close();
            }
        }
    }
}