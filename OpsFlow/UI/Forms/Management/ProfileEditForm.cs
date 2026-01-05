using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Core.Services;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Dialogs.Notifications;
using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Forms.Management;

public partial class ProfileEditForm : Form
{
    private User? _user;
    private User? _originalUser;
    private string? _uploadedFilePath;
    private readonly IFileUploadService _fileUploadService;
    private List<Role> _roles = new List<Role>();
    private List<Department> _departments = new List<Department>();

    public ProfileEditForm(User user)
    {
        InitializeComponent();
        _user = user;
        _originalUser = new User
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Phone = user.Phone,
            RoleId = user.RoleId,
            DepartmentId = user.DepartmentId,
            AvatarUrl = user.AvatarUrl,
            CompanyId = user.CompanyId,
            IsActive = user.IsActive
        };
        _fileUploadService = FileUploadServiceFactory.Create();
        this.Load += ProfileEditForm_Load;
        AttachEventHandlers();
    }

    private async void ProfileEditForm_Load(object? sender, EventArgs e)
    {
        await LoadComboBoxDataAsync();
        LoadUserData();
    }

    private async Task LoadComboBoxDataAsync()
    {
        try
        {
            using var roleContext = DatabaseManager.CreateContext();
            using var departmentContext = DatabaseManager.CreateContext();

            var roleService = new RoleService(roleContext);
            var departmentService = new DepartmentService(departmentContext);

            var rolesTask = roleService.GetAllRolesAsync();
            var departmentsTask = departmentService.GetAllDepartmentsAsync();

            await Task.WhenAll(rolesTask, departmentsTask);

            var roles = await rolesTask;
            var departments = await departmentsTask;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    LoadComboBoxes(roles, departments);
                }));
            }
            else
            {
                LoadComboBoxes(roles, departments);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Veriler yüklenirken bir hata oluştu: {ex.Message}";
            if (ex.InnerException != null)
            {
                errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
            }
            Notifier.Show("Hata", errorMessage, NotificationType.Error);
        }
    }

    private void LoadComboBoxes(List<Role> roles, List<Department> departments)
    {
        _roles = roles;
        _departments = departments;

        txtTitle.BeginUpdate();
        txtTitle.Items.Clear();
        foreach (var role in roles)
            txtTitle.Items.Add(role.RoleName);
        txtTitle.EndUpdate();

        txtDepartmant.BeginUpdate();
        txtDepartmant.Items.Clear();
        foreach (var department in departments)
            txtDepartmant.Items.Add(department.DepartmentName);
        txtDepartmant.EndUpdate();
    }

    private void AttachEventHandlers()
    {
        btnSave.Click += BtnSave_Click;
        btnCancel.Click += BtnCancel_Click;
        btnAddPhoto.Click += BtnAddPhoto_Click;
    }

    private void LoadUserData()
    {
        if (_user == null) return;

        txtName.Text = _user.Name;
        txtSurname.Text = _user.Surname;
        txtEmail.Text = _user.Email;
        txtPhone.Text = _user.Phone ?? string.Empty;
        
        if (_user.Role != null)
        {
            txtTitle.Text = _user.Role.RoleName;
        }
        
        if (_user.Department != null)
        {
            txtDepartmant.Text = _user.Department.DepartmentName;
        }

        LoadAvatarAsync(_user.AvatarUrl);
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

    private void BtnAddPhoto_Click(object? sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _uploadedFilePath = openFileDialog.FileName;
                try
                {
                    PictureBox.Image = Image.FromFile(_uploadedFilePath);
                }
                catch
                {
                    Notifier.Show("Hata", "Seçilen dosya bir resim dosyası değil veya bozuk.", NotificationType.Error);
                    _uploadedFilePath = null;
                }
            }
        }
    }

    private async void BtnSave_Click(object? sender, EventArgs e)
    {
        if (_user == null) return;

        bool hasChanges = HasChanges();

        if (!hasChanges)
        {
            Notifier.Show("Bilgi", "Herhangi bir değişiklik yapılmadı.", NotificationType.Information);
            return;
        }

        try
        {
            this.Enabled = false;
            Notifier.Show("Kaydediliyor", "Değişiklikler kaydediliyor...", NotificationType.Information);

            await Task.Run(async () =>
            {
                using var context = DatabaseManager.CreateContext();
                var userService = new UserService(context);

                // Kullanıcıyı Find ile çek (tracked entity)
                var existingUser = context.Users.Find(_user.Id);
                if (existingUser == null)
                {
                    throw new NotFoundException("Güncellenmek istenen kullanıcı bulunamadı.");
                }

                // Değişiklikleri uygula
                existingUser.Name = txtName.Text.Trim();
                existingUser.Surname = txtSurname.Text.Trim();
                existingUser.Email = txtEmail.Text.Trim();
                existingUser.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();

                // Rol güncelleme
                if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    var selectedRole = ComboBoxHelper.FindRoleByName(_roles, txtTitle.Text);
                    if (selectedRole != null)
                    {
                        existingUser.RoleId = selectedRole.Id;
                    }
                }

                // Departman güncelleme
                if (!string.IsNullOrWhiteSpace(txtDepartmant.Text))
                {
                    var selectedDepartment = ComboBoxHelper.FindDepartmentByName(_departments, txtDepartmant.Text);
                    if (selectedDepartment != null)
                    {
                        existingUser.DepartmentId = selectedDepartment.Id;
                    }
                    else
                    {
                        existingUser.DepartmentId = null;
                    }
                }
                else
                {
                    existingUser.DepartmentId = null;
                }

                // Yeni resim yüklendiyse
                if (!string.IsNullOrWhiteSpace(_uploadedFilePath))
                {
                    var fileUploadService = FileUploadServiceFactory.Create();
                    string relativePath = await fileUploadService.UploadProfilePhotoAsync(_uploadedFilePath, _user.Id);
                    existingUser.AvatarUrl = relativePath;
                }

                // CompanyId'yi koru (değiştirilmemeli)
                existingUser.CompanyId = _user.CompanyId;

                // Validasyon
                if (string.IsNullOrWhiteSpace(existingUser.Name) || existingUser.Name.Length < 2)
                    throw new ValidationException("İsim alanı en az 2 karakter olmalıdır.");

                if (string.IsNullOrWhiteSpace(existingUser.Surname) || existingUser.Surname.Length < 2)
                    throw new ValidationException("Soyisim alanı en az 2 karakter olmalıdır.");

                if (string.IsNullOrWhiteSpace(existingUser.Email) || !existingUser.Email.Contains("@"))
                    throw new ValidationException("Lütfen geçerli bir e-posta adresi giriniz.");

                if (existingUser.RoleId <= 0)
                    throw new ValidationException("Lütfen kullanıcı için bir rol tanımlayınız.");

                // Kullanıcıyı güncelle - tracked entity olduğu için direkt SaveChanges yeterli
                context.SaveChanges();
            });

            // UI thread'de mesajı göster ve formu kapat
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Başarılı", "Kullanıcı bilgileri başarıyla güncellendi.", NotificationType.Success);
                    this.DialogResult = DialogResult.OK;
                    
                    // Mesajın görünmesi için kısa bir gecikme sonrası formu kapat
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1500;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        this.Close();
                    };
                    timer.Start();
                }));
            }
            else
            {
                Notifier.Show("Başarılı", "Kullanıcı bilgileri başarıyla güncellendi.", NotificationType.Success);
                this.DialogResult = DialogResult.OK;
                
                // Mesajın görünmesi için kısa bir gecikme sonrası formu kapat
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    timer.Dispose();
                    this.Close();
                };
                timer.Start();
            }
        }
        catch (ValidationException ex)
        {
            this.Invoke(new Action(() =>
            {
                Notifier.Show("Doğrulama Hatası", ex.Message, NotificationType.Error);
                this.Enabled = true;
            }));
        }
        catch (BusinessException ex)
        {
            this.Invoke(new Action(() =>
            {
                Notifier.Show("İş Kuralı Hatası", ex.Message, NotificationType.Error);
                this.Enabled = true;
            }));
        }
        catch (Exception ex)
        {
            this.Invoke(new Action(() =>
            {
                string errorMessage = $"Kullanıcı bilgileri güncellenirken bir hata oluştu: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
                }
                Notifier.Show("Hata", errorMessage, NotificationType.Error);
                this.Enabled = true;
            }));
        }
    }

    private bool HasChanges()
    {
        if (_originalUser == null || _user == null) return false;

        bool nameChanged = txtName.Text.Trim() != _originalUser.Name;
        bool surnameChanged = txtSurname.Text.Trim() != _originalUser.Surname;
        bool emailChanged = txtEmail.Text.Trim() != _originalUser.Email;
        bool phoneChanged = (txtPhone.Text.Trim() ?? string.Empty) != (_originalUser.Phone ?? string.Empty);
        bool avatarChanged = !string.IsNullOrWhiteSpace(_uploadedFilePath);
        
        bool roleChanged = txtTitle.Text.Trim() != (_user.Role?.RoleName ?? string.Empty);
        bool departmentChanged = txtDepartmant.Text.Trim() != (_user.Department?.DepartmentName ?? string.Empty);

        return nameChanged || surnameChanged || emailChanged || phoneChanged || avatarChanged || roleChanged || departmentChanged;
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }
}
