using Guna.UI2.WinForms;

namespace OpsFlow.UI.Forms.Management;

public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
    }
    private void SettingsForm_Load(object sender, EventArgs e)
    {
        ShowPage(new ProfileControl());
        HighlightButton(btnProfile);
    }
    private void ShowPage(UserControl page)
    {
        pnlSettingsContent.Controls.Clear();
        page.Dock = DockStyle.Fill;
        pnlSettingsContent.Controls.Add(page);
    }
    private void HighlightButton(Guna2Button activeBtn)
    {
        btnGeneral.FillColor = Color.Transparent;
        btnProfile.FillColor = Color.Transparent;
        btnNotifications.FillColor = Color.Transparent;
        activeBtn.FillColor = Color.FromArgb(40, 44, 55);
    }

    private void btnProfile_Click(object sender, EventArgs e)
    {
        ShowPage(new ProfileControl());
        HighlightButton((Guna2Button)sender);
    }

    private void btnGeneral_Click(object sender, EventArgs e)
    {
        HighlightButton((Guna2Button)sender);
    }
}