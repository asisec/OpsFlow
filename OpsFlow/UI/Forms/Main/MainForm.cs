using OpsFlow.Core.Services;
using OpsFlow.UI.Forms.Auth;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Management;

namespace OpsFlow.UI.Forms.Main;

public partial class MainForm : BaseForm
{
    private NavbarControl _navbar = null!;
    private Guna2Panel _contentPanel = null!;

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

        HeaderPanel?.BringToFront();
    }

    private void LoadUserData()
    {
        var currentUser = UserSession.CurrentUser;

        if (currentUser != null)
        {
            string roleName = currentUser.Role?.RoleName ?? "Personel";

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
        _contentPanel.Controls.Clear();

        switch (viewName)
        {
            case "Dashboard":
                break;
            case "Staff":
                break;
            case "Tasks":
                break;
            case "Settings":
                break;
            default:
                break;
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {

        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        Application.Exit();
    }
}