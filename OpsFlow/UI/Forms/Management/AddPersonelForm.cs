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

        private void picProfilePhoto_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}