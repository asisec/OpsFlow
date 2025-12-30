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

        }
    }
}