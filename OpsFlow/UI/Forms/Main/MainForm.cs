using Guna.UI2.WinForms;

using OpsFlow.UI.Controls;
using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Forms.Main;

public partial class MainForm : BaseForm
{
    private NavbarControl? _navbar;
    private Guna2Panel? _contentPanel;

    public MainForm()
    {
        InitializeComponent();
        InitializeLayout();
    }

    private void InitializeLayout()
    {
        Text = "OpsFlow Dashboard";

        _navbar = new NavbarControl
        {
            Dock = DockStyle.Left
        };

        _contentPanel = new Guna2Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(245, 247, 251)
        };

        Controls.Add(_contentPanel);
        Controls.Add(_navbar);

        _navbar.DashboardClicked += (s, e) => LoadContent("Dashboard");
        _navbar.StaffClicked += (s, e) => LoadContent("Staff");
        _navbar.TasksClicked += (s, e) => LoadContent("Tasks");
        _navbar.SettingsClicked += (s, e) => LoadContent("Settings");

        if (HeaderPanel != null)
        {
            HeaderPanel.BringToFront();
        }
    }

    private void LoadContent(string viewName)
    {

    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        Application.Exit();
    }
}