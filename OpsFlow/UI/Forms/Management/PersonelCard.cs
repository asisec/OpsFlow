using OpsFlow.Core.Models;
using OpsFlow.Core.Services;
using OpsFlow.Services.Implementations;

namespace OpsFlow.UI.Forms.Management;

public partial class PersonelCard : UserControl
{
    private User? _user;

    public PersonelCard()
    {
        InitializeComponent();
        this.Margin = new Padding(35, 35, 35, 35);
    }

    public void SetUserData(User user)
    {
        _user = user;

        lblName.Text = $"{user.Name} {user.Surname}";
        
        string departmentName = user.Department?.DepartmentName ?? "Departman Yok";
        btnRoleBadge.Text = departmentName;

        Size textSize = TextRenderer.MeasureText(departmentName, btnRoleBadge.Font);
        int requiredWidth = textSize.Width + 24;
        int maxWidth = 215;
        btnRoleBadge.Width = Math.Min(requiredWidth, maxWidth);

        LoadAvatarAsync(user.AvatarUrl);
    }

    private async void LoadAvatarAsync(string? avatarUrl)
    {
        if (string.IsNullOrWhiteSpace(avatarUrl))
        {
            PictureBox.Image = null;
            return;
        }

        try
        {
            if (Uri.TryCreate(avatarUrl, UriKind.Absolute, out Uri? uri) && 
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageData = await client.GetByteArrayAsync(uri);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        PictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = {
                    Path.Combine(baseDir, "Resources", "Uploads", avatarUrl),
                    Path.Combine(baseDir, "..", "..", "..", "Resources", "Uploads", avatarUrl),
                    Path.Combine(baseDir, "..", "..", "Resources", "Uploads", avatarUrl),
                    avatarUrl
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        PictureBox.Image = Image.FromFile(path);
                        return;
                    }
                }

                PictureBox.Image = null;
            }
        }
        catch
        {
            PictureBox.Image = null;
        }
    }

    private async void btnViewProfile_Click(object sender, EventArgs e)
    {
        if (_user == null) return;

        if (this.FindForm() is Form anaForm)
        {
            Form dimmer = new Form();
            dimmer.FormBorderStyle = FormBorderStyle.None;
            dimmer.BackColor = Color.Black;
            dimmer.Opacity = 0.60d;
            dimmer.ShowInTaskbar = false;
            dimmer.StartPosition = FormStartPosition.Manual;
            dimmer.Location = anaForm.Location;
            dimmer.Size = anaForm.Size;
            using (ProfileEditForm popup = new ProfileEditForm(_user))
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                dimmer.Show(anaForm);
                DialogResult result = popup.ShowDialog(dimmer);
                dimmer.Close();
                
                // Eğer kullanıcı bilgileri güncellendiyse, kartı yeniden yükle
                if (result == DialogResult.OK)
                {
                    await RefreshUserDataAsync();
                }
            }
        }
    }

    private async Task RefreshUserDataAsync()
    {
        if (_user == null) return;

        try
        {
            using var context = OpsFlow.Core.Services.DatabaseManager.CreateContext();
            var userService = new OpsFlow.Services.Implementations.UserService(context);
            
            // Güncel kullanıcı bilgilerini veritabanından çek
            var updatedUser = userService.GetUserById(_user.Id);
            if (updatedUser != null)
            {
                // Kartı güncel verilerle yeniden yükle
                SetUserData(updatedUser);
            }
        }
        catch
        {
            // Hata durumunda sessizce devam et
        }
    }
}
