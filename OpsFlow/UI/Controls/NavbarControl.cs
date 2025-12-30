using Guna.UI2.WinForms;

using OpsFlow.Core.Services;
using OpsFlow.Core.Session;
using OpsFlow.UI.Forms.Auth;
using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Controls;

public class NavbarControl : UserControl
{
    private Guna2Panel _logoPanel;
    private Guna2PictureBox _pbLogo;
    private Guna2HtmlLabel _lblLogoText;

    private Guna2Panel _menuPanel;
    private Guna2Button _btnDashboard;
    private Guna2Button _btnStaff;
    private Guna2Button _btnTasks;

    private Guna2Panel _bottomPanel;
    private Guna2Separator _separator;
    private Guna2Button _btnSettings;
    private Guna2Button _btnLogout;

    private Guna2Panel _profilePanel;
    private Guna2CirclePictureBox _pbProfile;
    private Guna2HtmlLabel _lblUserName;
    private Guna2Button _btnProfileExpand;

    public event EventHandler? DashboardClicked;
    public event EventHandler? StaffClicked;
    public event EventHandler? TasksClicked;
    public event EventHandler? SettingsClicked;

    public NavbarControl()
    {
        InitializeComponent();
        LoadUserData();
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        BackColor = Color.FromArgb(20, 22, 31);
        Name = "NavbarControl";
        Size = new Size(260, 463);

        InitializeLogoSection();
        InitializeMenuSection();
        InitializeBottomSection();

        ResumeLayout(false);
    }

    private void InitializeLogoSection()
    {
        _logoPanel = new Guna2Panel
        {
            Dock = DockStyle.Top,
            Height = 80,
            BackColor = Color.Transparent
        };

        _pbLogo = new Guna2PictureBox
        {
            Size = new Size(40, 40),
            Location = new Point(20, 20),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        LoadAppLogo();

        _lblLogoText = new Guna2HtmlLabel
        {
            Text = "<span style='font-family: Poppins; font-weight: bold; font-size: 16pt; color: #3b82f6;'>Ops</span><span style='font-family: Poppins; font-weight: bold; font-size: 16pt; color: #a855f7;'>Flow</span>",
            Location = new Point(70, 22),
            BackColor = Color.Transparent
        };

        _logoPanel.Controls.Add(_pbLogo);
        _logoPanel.Controls.Add(_lblLogoText);
        Controls.Add(_logoPanel);
    }

    private void InitializeMenuSection()
    {
        _menuPanel = new Guna2Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10, 20, 10, 0)
        };

        _btnDashboard = CreateMenuButton("Ana Sayfa");
        _btnDashboard.Click += (s, e) => DashboardClicked?.Invoke(this, EventArgs.Empty);

        _btnStaff = CreateMenuButton("Personeller");
        _btnStaff.Click += (s, e) => StaffClicked?.Invoke(this, EventArgs.Empty);

        _btnTasks = CreateMenuButton("Görevler");
        _btnTasks.Click += (s, e) => TasksClicked?.Invoke(this, EventArgs.Empty);

        _menuPanel.Controls.Add(_btnTasks);
        _menuPanel.Controls.Add(_btnStaff);
        _menuPanel.Controls.Add(_btnDashboard);

        Controls.Add(_menuPanel);
        _menuPanel.BringToFront();
    }

    private void InitializeBottomSection()
    {
        _bottomPanel = new Guna2Panel
        {
            Dock = DockStyle.Bottom,
            Height = 180,
            Padding = new Padding(10, 0, 10, 10)
        };

        _separator = new Guna2Separator
        {
            Dock = DockStyle.Top,
            FillColor = Color.FromArgb(40, 44, 55),
            Height = 1
        };

        _btnSettings = CreateMenuButton("Ayarlar");
        _btnSettings.Dock = DockStyle.Top;
        _btnSettings.Click += (s, e) => SettingsClicked?.Invoke(this, EventArgs.Empty);

        _btnLogout = CreateMenuButton("Çıkış Yap");
        _btnLogout.Dock = DockStyle.Top;
        _btnLogout.Click += BtnLogout_Click;

        InitializeProfileSection();

        _bottomPanel.Controls.Add(_profilePanel);
        _bottomPanel.Controls.Add(_btnLogout);
        _bottomPanel.Controls.Add(_btnSettings);
        _bottomPanel.Controls.Add(_separator);

        Controls.Add(_bottomPanel);
    }

    private void InitializeProfileSection()
    {
        _profilePanel = new Guna2Panel
        {
            Dock = DockStyle.Bottom,
            Height = 60,
            FillColor = Color.FromArgb(30, 34, 45),
            BorderRadius = 10,
            Margin = new Padding(0, 10, 0, 0)
        };

        _pbProfile = new Guna2CirclePictureBox
        {
            Size = new Size(40, 40),
            Location = new Point(10, 10),
            SizeMode = PictureBoxSizeMode.StretchImage,
            FillColor = Color.Gray
        };

        _lblUserName = new Guna2HtmlLabel
        {
            Text = "<span style='font-family: Poppins; font-size: 9pt; font-weight: 600; color: #ffffff;'>Kullanıcı</span>",
            Location = new Point(60, 20),
            AutoSize = false,
            Width = 130,
            Height = 20,
            TextAlignment = ContentAlignment.MiddleLeft
        };

        _btnProfileExpand = new Guna2Button
        {
            Size = new Size(20, 20),
            Location = new Point(200, 20),
            FillColor = Color.Transparent,
            Text = "^",
            ForeColor = Color.LightGray,
            Font = new Font("Consolas", 10),
            UseTransparentBackground = true
        };

        _profilePanel.Controls.Add(_pbProfile);
        _profilePanel.Controls.Add(_lblUserName);
        _profilePanel.Controls.Add(_btnProfileExpand);
    }

    private Guna2Button CreateMenuButton(string text)
    {
        var btn = new Guna2Button
        {
            Text = text,
            Dock = DockStyle.Top,
            Height = 45,
            FillColor = Color.Transparent,
            ForeColor = Color.FromArgb(200, 200, 200),
            Font = new Font("Poppins", 10F, FontStyle.Regular),
            TextAlign = HorizontalAlignment.Left,
            ImageOffset = new Point(5, 0),
            TextOffset = new Point(15, 0),
            BorderRadius = 8,
            Cursor = Cursors.Hand,
            Animated = true
        };

        btn.HoverState.FillColor = Color.FromArgb(40, 44, 60);
        btn.HoverState.ForeColor = Color.White;

        return btn;
    }

    private void LoadUserData()
    {
        var user = UserSession.CurrentUser;
        if (user != null)
        {
            _lblUserName.Text = $"<span style='font-family: Poppins; font-size: 9pt; font-weight: 600; color: #ffffff;'>{user.Name} {user.Surname}</span>";

            if (!string.IsNullOrEmpty(user.AvatarUrl) && File.Exists(user.AvatarUrl))
            {
                _pbProfile.Image = Image.FromFile(user.AvatarUrl);
            }
        }
    }

    private void LoadAppLogo()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Logo.png");
            if (File.Exists(path))
                _pbLogo.Image = Image.FromFile(path);
        }
        catch { }
    }

    private void BtnLogout_Click(object? sender, EventArgs e)
    {
        UserSession.ClearSession();
        var parentForm = this.FindForm();
        if (parentForm != null)
        {
            WindowManager.Switch<LoginForm>(parentForm);
        }
    }
}