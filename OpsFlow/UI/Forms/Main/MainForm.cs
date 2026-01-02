using Guna.UI2.WinForms;
using OpsFlow.UI.Controls;
using OpsFlow.UI.Forms.Core;
using OpsFlow.Core.Models;
using OpsFlow.UI.Forms.Management;

namespace OpsFlow.UI.Forms.Main;

public partial class MainForm : BaseForm
{
    private Guna2Panel _contentPanel = null!;
    private NavbarControl _navbar = null!;
    private Form? _activeForm = null;

    public MainForm()
    {
        InitializeComponent();
        InitializeLayout();
        BindNavbarEvents();
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

        if (HeaderPanel != null)
        {
            HeaderPanel.BringToFront();
        }
    }

    private void BindNavbarEvents()
    {
        _navbar.DashboardClicked += (s, e) => LoadContent("Dashboard");
        _navbar.StaffClicked += (s, e) => LoadContent("Staff");
        _navbar.TasksClicked += (s, e) => LoadContent("Tasks");
        _navbar.SettingsClicked += (s, e) => LoadContent("Settings");
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
        switch (viewName)
        {
            case "Dashboard":
                break;
            case "Staff":
                LoadForm(new AddPersonelForm());
                break;
            case "Tasks":
                break;
            case "Settings":
                break;
            default:
                break;
        }
    }

    private void LoadForm(Form childForm)
    {
        if (_activeForm != null)
        {
            _activeForm.Close();
            _activeForm.Dispose();
        }

        _activeForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        
        _contentPanel.Controls.Add(childForm);
        _contentPanel.Tag = childForm;
        
        childForm.BringToFront();
        childForm.Show();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        Application.Exit();
    }
}