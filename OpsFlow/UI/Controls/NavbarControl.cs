using Guna.UI2.WinForms;

using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace OpsFlow.UI.Controls;

public class NavbarControl : UserControl
{
    private Guna2Panel _logoPanel;
    private Guna2PictureBox _logoPictureBox;
    // _appLabel kaldırıldı.

    private Guna2Panel _menuPanel;
    private Guna2Button _btnDashboard;
    private Guna2Button _btnStaff;
    private Guna2Button _btnTasks;

    private Guna2Panel _userPanel;
    private Guna2CirclePictureBox _userAvatar;
    private Label _userNameLabel;
    private Label _userRoleLabel;
    private Guna2Button _btnSettings;
    private Guna2Button _btnLogout;

    private readonly string _cacheDirectory;

    public event EventHandler? DashboardClicked;
    public event EventHandler? StaffClicked;
    public event EventHandler? TasksClicked;
    public event EventHandler? SettingsClicked;

    public NavbarControl()
    {
        _cacheDirectory = Path.Combine(Application.StartupPath, "Cache", "Avatars");
        InitializeComponent();
        EnsureCacheDirectoryExists();
    }

    private void EnsureCacheDirectoryExists()
    {
        if (!Directory.Exists(_cacheDirectory))
        {
            Directory.CreateDirectory(_cacheDirectory);
        }
    }

    private void InitializeComponent()
    {
        Dock = DockStyle.Left;
        Width = 260;
        BackColor = Color.FromArgb(20, 24, 36);

        InitializeLogoPanel();
        InitializeUserPanel();
        InitializeMenuPanel();
    }

    private void InitializeLogoPanel()
    {
        _logoPanel = new Guna2Panel
        {
            Dock = DockStyle.Top,
            Height = 100,
            BackColor = Color.Transparent
        };

        // Logo ayarları: Yazıyı sildik, logoyu büyüttük ve ortaladık.
        _logoPictureBox = new Guna2PictureBox
        {
            Size = new Size(200, 70), // Genişlik ve yükseklik artırıldı
            Location = new Point(30, 15), // Ortalanmış konum (Panel 260px, Logo 200px -> (260-200)/2 = 30)
            SizeMode = PictureBoxSizeMode.Zoom, // Resmi bozmadan sığdırır
            BackColor = Color.Transparent,
            UseTransparentBackground = true
        };

        string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Logo.png");

        if (File.Exists(logoPath))
        {
            _logoPictureBox.Image = Image.FromFile(logoPath);
        }
        else
        {
            // Geliştirme ortamında (debug) geriye gidip dosyayı bulma yedeği
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName ?? "";
            string devPath = Path.Combine(projectPath, "Resources", "Images", "Logo.png");

            if (File.Exists(devPath))
            {
                _logoPictureBox.Image = Image.FromFile(devPath);
            }
        }

        _logoPanel.Controls.Add(_logoPictureBox);
        // _appLabel eklentisi kaldırıldı.
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

        CreateMenuButton(ref _btnDashboard, "Ana Sayfa", 0);
        CreateMenuButton(ref _btnStaff, "Personeller", 50);
        CreateMenuButton(ref _btnTasks, "Görevler", 100);

        _btnDashboard.Click += (s, e) => DashboardClicked?.Invoke(this, EventArgs.Empty);
        _btnStaff.Click += (s, e) => StaffClicked?.Invoke(this, EventArgs.Empty);
        _btnTasks.Click += (s, e) => TasksClicked?.Invoke(this, EventArgs.Empty);

        _menuPanel.Controls.Add(_btnDashboard);
        _menuPanel.Controls.Add(_btnStaff);
        _menuPanel.Controls.Add(_btnTasks);

        Controls.Add(_menuPanel);
        _menuPanel.BringToFront();
    }

    private void InitializeUserPanel()
    {
        _userPanel = new Guna2Panel
        {
            Dock = DockStyle.Bottom,
            Height = 160,
            BackColor = Color.FromArgb(26, 31, 46)
        };

        _btnSettings = new Guna2Button
        {
            Text = "Ayarlar",
            FillColor = Color.Transparent,
            ForeColor = Color.Gray,
            HoverState = { FillColor = Color.Transparent, ForeColor = Color.White },
            TextAlign = HorizontalAlignment.Left,
            Height = 35,
            Width = 240,
            Location = new Point(10, 10),
            Cursor = Cursors.Hand
        };
        _btnSettings.Click += (s, e) => SettingsClicked?.Invoke(this, EventArgs.Empty);

        _btnLogout = new Guna2Button
        {
            Text = "Çıkış Yap",
            FillColor = Color.Transparent,
            ForeColor = Color.FromArgb(232, 17, 35),
            HoverState = { FillColor = Color.Transparent, ForeColor = Color.Red },
            TextAlign = HorizontalAlignment.Left,
            Height = 35,
            Width = 240,
            Location = new Point(10, 45),
            Cursor = Cursors.Hand
        };
        _btnLogout.Click += (s, e) => Application.Restart();

        var separator = new Guna2Separator
        {
            Location = new Point(15, 85),
            Width = 230,
            FillColor = Color.FromArgb(40, 44, 55)
        };

        _userAvatar = new Guna2CirclePictureBox
        {
            Size = new Size(40, 40),
            Location = new Point(15, 100),
            SizeMode = PictureBoxSizeMode.StretchImage,
            FillColor = Color.FromArgb(40, 44, 55),
            BackColor = Color.Transparent,
            UseTransparentBackground = true
        };

        _userNameLabel = new Label
        {
            Text = "...",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Location = new Point(65, 102),
            AutoSize = true
        };

        _userRoleLabel = new Label
        {
            Text = "...",
            ForeColor = Color.Gray,
            Font = new Font("Segoe UI", 8, FontStyle.Regular),
            Location = new Point(65, 122),
            AutoSize = true
        };

        _userPanel.Controls.Add(_btnSettings);
        _userPanel.Controls.Add(_btnLogout);
        _userPanel.Controls.Add(separator);
        _userPanel.Controls.Add(_userAvatar);
        _userPanel.Controls.Add(_userNameLabel);
        _userPanel.Controls.Add(_userRoleLabel);

        Controls.Add(_userPanel);
    }

    private void CreateMenuButton(ref Guna2Button btn, string text, int top)
    {
        btn = new Guna2Button
        {
            Text = text,
            Top = top,
            Height = 45,
            Width = 240,
            FillColor = Color.Transparent,
            ForeColor = Color.FromArgb(160, 160, 160),
            TextAlign = HorizontalAlignment.Left,
            TextOffset = new Point(10, 0),
            BorderRadius = 8,
            Cursor = Cursors.Hand,
            Animated = true
        };

        btn.HoverState.FillColor = Color.FromArgb(40, 44, 55);
        btn.HoverState.ForeColor = Color.White;
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
        try
        {
            if (File.Exists(url))
            {
                _userAvatar.Image = Image.FromFile(url);
                return;
            }

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

    private string GetHashString(string input)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(hash);
    }
}