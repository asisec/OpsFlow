using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

using Guna.UI2.WinForms;

using OpsFlow.UI.Forms.Management;

using Timer = System.Windows.Forms.Timer;

namespace OpsFlow.UI.Controls;

public class NavbarControl : UserControl
{
    private Guna2Panel _logoPanel = null!;
    private Guna2PictureBox _logoPictureBox = null!;

    private Guna2Panel _menuPanel = null!;
    private Guna2Button _btnDashboard = null!;
    private Guna2Button _btnStaff = null!;
    private Guna2Button _btnTasks = null!;

    private Guna2Panel _userPanel = null!;
    private Guna2CirclePictureBox _userAvatar = null!;
    private Label _userNameLabel = null!;
    private Label _userRoleLabel = null!;
    private Label _arrowLabel = null!;

    private Guna2Panel _dropdownPanel = null!;
    private Guna2Button _btnSettings = null!;
    private Guna2Button _btnLogout = null!;

    // CS8618 Düzeltmesi: Başlangıç değeri atandı.
    private readonly string _cacheDirectory = Path.Combine(Application.StartupPath, "Cache", "Avatars");

    private Timer _animationTimer = null!;
    private bool _isDropdownOpen = false;

    // IDE0044 Düzeltmesi: Salt okunur yapıldı.
    private readonly int _targetHeight = 110;

    public event EventHandler? DashboardClicked;
    public event EventHandler? StaffClicked;
    public event EventHandler? TasksClicked;
    public event EventHandler? SettingsClicked;

    public NavbarControl()
    {
        InitializeComponent();

        InitializeLogoPanel();
        InitializeUserPanel();
        InitializeMenuPanel();
        InitializeDropdownMenu();
        InitializeAnimation();

        _logoPanel.SendToBack();
        _userPanel.SendToBack();
        _menuPanel.BringToFront();

        _dropdownPanel.BringToFront();

        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        EnsureCacheDirectoryExists();
    }

    private void EnsureCacheDirectoryExists()
    {
        if (string.IsNullOrEmpty(_cacheDirectory)) return;

        if (!Directory.Exists(_cacheDirectory))
        {
            Directory.CreateDirectory(_cacheDirectory);
        }
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        BackColor = Color.FromArgb(20, 24, 36);
        Name = "NavbarControl";
        Size = new Size(260, 600);

        ResumeLayout(false);
    }

    private void InitializeAnimation()
    {
        _animationTimer = new Timer
        {
            Interval = 10
        };
        _animationTimer.Tick += AnimationTimer_Tick;
    }

    private void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        if (_isDropdownOpen)
        {
            if (!_dropdownPanel.Visible)
            {
                _dropdownPanel.Visible = true;
                _dropdownPanel.Height = 0;
                _dropdownPanel.BringToFront();
            }

            if (_dropdownPanel.Height < _targetHeight)
            {
                _dropdownPanel.Height += 10;

                int newTop = _userPanel.Location.Y - _dropdownPanel.Height - 5;
                _dropdownPanel.Location = new Point(10, newTop);

                if (_dropdownPanel.Height > _targetHeight)
                    _dropdownPanel.Height = _targetHeight;
            }
            else
            {
                _animationTimer.Stop();
            }

            _arrowLabel.Text = "▲";
        }
        else
        {
            if (_dropdownPanel.Height > 0)
            {
                _dropdownPanel.Height -= 10;

                int newTop = _userPanel.Location.Y - _dropdownPanel.Height - 5;
                _dropdownPanel.Location = new Point(10, newTop);

                if (_dropdownPanel.Height <= 0)
                {
                    _dropdownPanel.Height = 0;
                    _dropdownPanel.Visible = false;
                    _animationTimer.Stop();
                }
            }
            _arrowLabel.Text = "▼";
        }
    }

    private void InitializeLogoPanel()
    {
        _logoPanel = new Guna2Panel
        {
            Dock = DockStyle.Top,
            Height = 100,
            BackColor = Color.Transparent
        };

        _logoPictureBox = new Guna2PictureBox
        {
            Size = new Size(200, 70),
            Location = new Point(30, 15),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Transparent,
            UseTransparentBackground = true
        };

        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            try
            {
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Logo.png");

                if (File.Exists(logoPath))
                {
                    _logoPictureBox.Image = Image.FromFile(logoPath);
                }
                else
                {
                    string? baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string? projectPath = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;

                    if (!string.IsNullOrEmpty(projectPath))
                    {
                        string devPath = Path.Combine(projectPath, "Resources", "Images", "Logo.png");
                        if (File.Exists(devPath))
                        {
                            _logoPictureBox.Image = Image.FromFile(devPath);
                        }
                    }
                }
            }
            catch { }
        }

        _logoPanel.Controls.Add(_logoPictureBox);
        Controls.Add(_logoPanel);
    }

    private void InitializeMenuPanel()
    {
        _menuPanel = new Guna2Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10, 20, 10, 0),
            BackColor = Color.Transparent
        };

        CreateMenuButton(ref _btnDashboard, "Ana Sayfa", 10);

        var separator1 = CreateSeparator(70);
        _menuPanel.Controls.Add(separator1);

        CreateMenuButton(ref _btnStaff, "Personeller", 80);

        var separator2 = CreateSeparator(140);
        _menuPanel.Controls.Add(separator2);

        CreateMenuButton(ref _btnTasks, "Görevler", 150);

        _btnDashboard.Click += (s, e) => DashboardClicked?.Invoke(this, EventArgs.Empty);
        _btnStaff.Click += (s, e) => StaffClicked?.Invoke(this, EventArgs.Empty);
        _btnTasks.Click += (s, e) => TasksClicked?.Invoke(this, EventArgs.Empty);

        _menuPanel.Controls.Add(_btnDashboard);
        _menuPanel.Controls.Add(_btnStaff);
        _menuPanel.Controls.Add(_btnTasks);

        Controls.Add(_menuPanel);
    }

    private void InitializeDropdownMenu()
    {
        _dropdownPanel = new Guna2Panel
        {
            Width = 240,
            Height = 0,
            BackColor = Color.FromArgb(26, 31, 46),
            Visible = false,
            BorderRadius = 12,
            BorderColor = Color.FromArgb(40, 44, 55),
            BorderThickness = 1
        };

        _btnSettings = new Guna2Button
        {
            Text = "Ayarlar",
            FillColor = Color.Transparent,
            ForeColor = Color.Gray,
            HoverState = { FillColor = Color.FromArgb(40, 44, 55), ForeColor = Color.White },
            TextAlign = HorizontalAlignment.Left,
            Height = 40,
            Width = 220,
            Location = new Point(10, 5),
            BorderRadius = 10,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI Semibold", 10F),
            Image = GetIcon("settings"),
            ImageOffset = new Point(5, 0),
            TextOffset = new Point(10, 0)
        };
        _btnSettings.Click += (s, e) =>
        {
            SettingsClicked?.Invoke(this, EventArgs.Empty);
            ToggleUserMenu();
        };

        var separator = new Guna2Separator
        {
            Width = 200,
            Height = 1,
            Location = new Point(20, 50),
            FillColor = Color.FromArgb(40, 44, 55),
            FillThickness = 1
        };

        _btnLogout = new Guna2Button
        {
            Text = "Çıkış Yap",
            FillColor = Color.Transparent,
            ForeColor = Color.FromArgb(232, 17, 35),
            HoverState = { FillColor = Color.FromArgb(40, 44, 55), ForeColor = Color.Red },
            TextAlign = HorizontalAlignment.Left,
            Height = 40,
            Width = 220,
            Location = new Point(10, 55),
            BorderRadius = 10,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI Semibold", 10F),
            Image = GetIcon("logout"),
            ImageOffset = new Point(5, 0),
            TextOffset = new Point(10, 0)
        };

        _btnLogout.Click += (s, e) =>
        {
            if (this.ParentForm is Form anaForm)
            {
                Form dimmer = new Form();
                dimmer.FormBorderStyle = FormBorderStyle.None;
                dimmer.BackColor = Color.Black;
                dimmer.Opacity = 0.60d;
                dimmer.ShowInTaskbar = false;
                dimmer.StartPosition = FormStartPosition.Manual;

                dimmer.Location = anaForm.PointToScreen(Point.Empty);
                dimmer.Size = anaForm.Size;

                using (LogoutForm confirmation = new LogoutForm())
                {
                    confirmation.StartPosition = FormStartPosition.CenterScreen;

                    dimmer.Show(anaForm);

                    DialogResult result = confirmation.ShowDialog(dimmer);

                    dimmer.Close();

                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        };

        _dropdownPanel.Controls.Add(_btnSettings);
        _dropdownPanel.Controls.Add(separator);
        _dropdownPanel.Controls.Add(_btnLogout);

        Controls.Add(_dropdownPanel);
    }

    private void InitializeUserPanel()
    {
        _userPanel = new Guna2Panel
        {
            Dock = DockStyle.Bottom,
            Height = 90,
            BackColor = Color.FromArgb(26, 31, 46),
            Cursor = Cursors.Hand,
            Padding = new Padding(10)
        };

        _userPanel.Click += (s, e) => ToggleUserMenu();

        _userAvatar = new Guna2CirclePictureBox
        {
            Size = new Size(50, 50),
            Location = new Point(15, 20),
            SizeMode = PictureBoxSizeMode.StretchImage,
            FillColor = Color.FromArgb(40, 44, 55),
            BackColor = Color.Transparent,
            UseTransparentBackground = true
        };
        _userAvatar.Click += (s, e) => ToggleUserMenu();

        _userNameLabel = new Label
        {
            Text = "...",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 11, FontStyle.Bold),
            Location = new Point(75, 25),
            AutoSize = true,
            Cursor = Cursors.Hand
        };
        _userNameLabel.Click += (s, e) => ToggleUserMenu();

        _userRoleLabel = new Label
        {
            Text = "...",
            ForeColor = Color.Gray,
            Font = new Font("Segoe UI Semibold", 9),
            Location = new Point(75, 48),
            AutoSize = true,
            Cursor = Cursors.Hand
        };
        _userRoleLabel.Click += (s, e) => ToggleUserMenu();

        _arrowLabel = new Label
        {
            Text = "▼",
            ForeColor = Color.Gray,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Location = new Point(220, 35),
            AutoSize = true,
            Cursor = Cursors.Hand
        };
        _arrowLabel.Click += (s, e) => ToggleUserMenu();

        _userPanel.Controls.Add(_userAvatar);
        _userPanel.Controls.Add(_userNameLabel);
        _userPanel.Controls.Add(_userRoleLabel);
        _userPanel.Controls.Add(_arrowLabel);

        Controls.Add(_userPanel);
    }

    private void ToggleUserMenu()
    {
        if (_animationTimer.Enabled) return;

        _isDropdownOpen = !_isDropdownOpen;
        _dropdownPanel.BringToFront();
        _animationTimer.Start();
    }

    // CA1822 Düzeltmesi: Static yapıldı (Zaten statikti, korundu).
    private static void CreateMenuButton(ref Guna2Button btn, string text, int top)
    {
        btn = new Guna2Button
        {
            Text = text,
            Top = top,
            Height = 50,
            Width = 240,
            FillColor = Color.Transparent,
            ForeColor = Color.FromArgb(160, 160, 160),
            TextAlign = HorizontalAlignment.Left,
            TextOffset = new Point(15, 0),
            BorderRadius = 12,
            Cursor = Cursors.Hand,
            Animated = true,
            Font = new Font("Segoe UI Semibold", 11F)
        };

        btn.HoverState.FillColor = Color.FromArgb(40, 44, 55);
        btn.HoverState.ForeColor = Color.White;
    }

    // CA1822 Düzeltmesi: Static yapıldı.
    private static Guna2Separator CreateSeparator(int top)
    {
        return new Guna2Separator
        {
            Width = 200,
            Height = 1,
            Location = new Point(30, top),
            FillColor = Color.FromArgb(40, 44, 55),
            FillThickness = 1
        };
    }

    public void SetUserInfo(string name, string surname, string role, string? avatarUrl)
    {
        _userNameLabel.Text = $"{name} {surname}";
        _userRoleLabel.Text = role;

        _userAvatar.Image = null;

        if (string.IsNullOrEmpty(avatarUrl)) return;

        LoadAvatarAsync(avatarUrl);
    }

    private async void LoadAvatarAsync(string url)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        try
        {
            if (File.Exists(url))
            {
                _userAvatar.Image = Image.FromFile(url);
                return;
            }

            if (string.IsNullOrEmpty(_cacheDirectory)) return;

            string fileName = GetHashString(url) + ".png";
            string localPath = Path.Combine(_cacheDirectory, fileName);

            if (File.Exists(localPath))
            {
                using var stream = new FileStream(localPath, FileMode.Open, FileAccess.Read);
                _userAvatar.Image = Image.FromStream(stream);
                return;
            }

            if (url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "OpsFlow-Client/1.0");

                var imageBytes = await client.GetByteArrayAsync(url);

                await File.WriteAllBytesAsync(localPath, imageBytes);

                using var ms = new MemoryStream(imageBytes);
                _userAvatar.Image = new Bitmap(ms);
            }
        }
        catch
        {
            _userAvatar.Image = null;
        }
    }

    // CA1822 Düzeltmesi: Static yapıldı.
    private static string GetHashString(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);
        return Convert.ToHexString(hashBytes);
    }

    // CA1822 Düzeltmesi: Static yapıldı.
    private static Image? GetIcon(string iconName)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return null;

        try
        {
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icons", $"{iconName}.png");

            if (File.Exists(iconPath))
            {
                return Image.FromFile(iconPath);
            }
            else
            {
                string? baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string? projectPath = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;

                if (!string.IsNullOrEmpty(projectPath))
                {
                    string devPath = Path.Combine(projectPath, "Resources", "Icons", $"{iconName}.png");
                    if (File.Exists(devPath))
                    {
                        return Image.FromFile(devPath);
                    }
                }
            }
        }
        catch { }

        return null;
    }
}