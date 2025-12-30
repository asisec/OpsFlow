using OpsFlow.Core.Services;
using OpsFlow.UI.Forms.Auth;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Management;

namespace OpsFlow.UI.Forms.Main
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            if (this.HeaderPanel != null)
            {
                this.HeaderPanel.SendToBack();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            WindowManager.Switch<LoginForm>(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            WindowManager.Exit();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            AddPersonelForm frm = new AddPersonelForm();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.guna2Panel1.Controls.Clear();
            this.guna2Panel1.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }
    }
}