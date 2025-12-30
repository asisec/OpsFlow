using Guna.UI2.WinForms;
using OpsFlow.UI.Controls;
using OpsFlow.UI.Forms.Core;
using OpsFlow.Core.Models;

namespace OpsFlow.UI.Forms.Main;

public partial class MainForm : BaseForm
{
    private NavbarControl? _navbar;
    private Guna2Panel? _contentPanel;

    public MainForm()
    {
        InitializeComponent();
        InitializeLayout();
        LoadUserData();
    }

    private void InitializeLayout()
    {
        Text = "OpsFlow Dashboard";
        BackColor = Color.FromArgb(26, 31, 46);

        _navbar = new NavbarControl
        {
            Dock = DockStyle.Left
        };

        _contentPanel = new Guna2Panel
        {
            Dock = DockStyle.Fill,
            FillColor = Color.FromArgb(26, 31, 46),
            BackColor = Color.FromArgb(26, 31, 46)
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

    private void LoadUserData()
    {
        var currentUser = UserSession.CurrentUser;

        if (currentUser != null && _navbar != null)
        {
            string roleName = currentUser.Role != null ? currentUser.Role.RoleName : "Personel";

            _navbar.SetUserInfo(
                currentUser.Name,
                currentUser.Surname,
                roleName,
                currentUser.AvatarUrl
            );
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