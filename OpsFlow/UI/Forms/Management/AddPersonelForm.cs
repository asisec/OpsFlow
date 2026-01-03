using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs.Notifications;

namespace OpsFlow.UI.Forms.Management
{
    public partial class AddPersonelForm : BaseForm
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IDatabaseConnectionService _dbService;
        private string? _uploadedFilePath;
        private List<Role> _roles = new List<Role>();
        private List<Company> _companies = new List<Company>();

        public string? UploadedAvatarPath => _uploadedFilePath;

        public AddPersonelForm()
        {
            InitializeComponent();
            if (this.HeaderPanel != null) this.HeaderPanel.SendToBack();
            _fileUploadService = FileUploadServiceFactory.Create();
            _dbService = new DatabaseConnectionService();
            
            this.Load += AddPersonelForm_Load;
            btnSave.Click += BtnSave_Click;
        }

        private async void AddPersonelForm_Load(object? sender, EventArgs e)
        {
            await LoadComboBoxDataAsync();
        }

        private async Task LoadComboBoxDataAsync()
        {
            cmbRole.BeginUpdate();
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Yükleniyor...");
            cmbRole.SelectedIndex = 0;
            cmbRole.EndUpdate();

            cmbDepartment.BeginUpdate();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("Yükleniyor...");
            cmbDepartment.SelectedIndex = 0;
            cmbDepartment.EndUpdate();

            cmbTitle.BeginUpdate();
            cmbTitle.Items.Clear();
            cmbTitle.Items.Add("Departman seçiniz");
            cmbTitle.Items.Add("İnsan Kaynakları");
            cmbTitle.Items.Add("Bilgi İşlem");
            cmbTitle.Items.Add("Muhasebe");
            cmbTitle.Items.Add("Satış");
            cmbTitle.Items.Add("Pazarlama");
            cmbTitle.Items.Add("Üretim");
            cmbTitle.Items.Add("Yönetim");
            cmbTitle.SelectedIndex = 0;
            cmbTitle.EndUpdate();

            List<Role>? roles = null;
            List<Company>? companies = null;

            try
            {
                var rolesTask = Task.Run(async () =>
                {
                    using var roleContext = _dbService.CreateContext();
                    var roleService = new RoleService(roleContext);
                    return await roleService.GetAllRolesAsync();
                });

                var companiesTask = Task.Run(async () =>
                {
                    using var companyContext = _dbService.CreateContext();
                    var companyService = new CompanyService(companyContext);
                    return await companyService.GetAllCompaniesAsync();
                });

                await Task.WhenAll(rolesTask, companiesTask);

                roles = await rolesTask;
                companies = await companiesTask;
            }
            catch (DatabaseQueryException dbEx)
            {
                string errorMessage = dbEx.Message;
                if (dbEx.InnerException != null)
                {
                    errorMessage += $"\n\nDetay: {dbEx.InnerException.Message}";
                }

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            MessageBox.Show(errorMessage, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }));
                }
                else
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        MessageBox.Show(errorMessage, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Veriler yüklenirken bir hata oluştu: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
                }

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            MessageBox.Show(errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }));
                }
                else
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        MessageBox.Show(errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }

            if (roles != null && companies != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        LoadComboBoxes(roles, companies);
                    }));
                }
                else
                {
                    LoadComboBoxes(roles, companies);
                }
            }
        }

        private void LoadComboBoxes(List<Role> roles, List<Company> companies)
        {
            _roles = roles;
            _companies = companies;

            cmbRole.BeginUpdate();
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Rol seçiniz");
            foreach (var role in roles)
                cmbRole.Items.Add(role.RoleName);
            cmbRole.SelectedIndex = 0;
            cmbRole.EndUpdate();

            cmbDepartment.BeginUpdate();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("Şirket seçiniz");
            foreach (var company in companies)
                cmbDepartment.Items.Add(company.CompanyName);
            cmbDepartment.SelectedIndex = 0;
            cmbDepartment.EndUpdate();

            cmbTitle.BeginUpdate();
            cmbTitle.Items.Clear();
            cmbTitle.Items.Add("Departman seçiniz");
            cmbTitle.Items.Add("İnsan Kaynakları");
            cmbTitle.Items.Add("Bilgi İşlem");
            cmbTitle.Items.Add("Muhasebe");
            cmbTitle.Items.Add("Satış");
            cmbTitle.Items.Add("Pazarlama");
            cmbTitle.Items.Add("Üretim");
            cmbTitle.Items.Add("Yönetim");
            cmbTitle.SelectedIndex = 0;
            cmbTitle.EndUpdate();
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void picProfilePhoto_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog.Title = "Profil Fotoğrafı Seç";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        Notifier.Show("Dosya Yükleniyor", "Dosya kontrol ediliyor ve yükleniyor...", NotificationType.Information);

                        string uploadedPath = await _fileUploadService.UploadProfilePhotoAsync(selectedFilePath);
                        _uploadedFilePath = uploadedPath;

                        if (Uri.TryCreate(uploadedPath, UriKind.Absolute, out Uri? uri) && 
                            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                byte[] imageData = await client.GetByteArrayAsync(uri);
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    picProfilePhoto.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            string fullPath = _fileUploadService.GetFullPath(uploadedPath);
                            picProfilePhoto.Image = Image.FromFile(fullPath);
                        }

                        Notifier.Show("Başarılı", "Profil fotoğrafı başarıyla yüklendi.", NotificationType.Success);
                    }
                    catch (FileUploadException ex)
                    {
                        Notifier.Show("Dosya Yükleme Hatası", ex.Message, NotificationType.Error);
                        _uploadedFilePath = null;
                    }
                    catch (Exception ex)
                    {
                        Notifier.Show("Hata", $"Beklenmeyen bir hata oluştu: {ex.Message}", NotificationType.Error);
                        _uploadedFilePath = null;
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string surname = txtSurname.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtTelephone.Text.Trim();
                string password = txtPassword.Text;
                string selectedRoleName = cmbRole.SelectedItem?.ToString() ?? string.Empty;
                string selectedCompanyName = cmbDepartment.SelectedItem?.ToString() ?? string.Empty;

                var validationResult = FormValidationHelper.ValidatePersonelForm(
                    name, surname, email, password, selectedRoleName, selectedCompanyName);

                if (!validationResult.IsValid)
                {
                    Notifier.Show("Hata", validationResult.ErrorMessage!, NotificationType.Error);
                    return;
                }

                var selectedRole = ComboBoxHelper.FindRoleByName(_roles, selectedRoleName);
                var selectedCompany = ComboBoxHelper.FindCompanyByName(_companies, selectedCompanyName);

                if (selectedRole == null)
                {
                    Notifier.Show("Hata", "Seçilen rol bulunamadı.", NotificationType.Error);
                    return;
                }

                if (selectedCompany == null)
                {
                    Notifier.Show("Hata", "Seçilen şirket bulunamadı.", NotificationType.Error);
                    return;
                }

                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Kaydediliyor", "Kullanıcı bilgileri kaydediliyor...", NotificationType.Information);
                }));

                var newUser = new User
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                    Password = password,
                    AvatarUrl = _uploadedFilePath
                };

                await Task.Run(async () =>
                {
                    using var context = _dbService.CreateContext();
                    var userService = new UserService(context);
                    var registrationService = new UserRegistrationService(context, userService);
                    await registrationService.RegisterPersonelAsync(newUser, selectedRole.Id, selectedCompany.Id);
                });

                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Başarılı", "Kullanıcı başarıyla kaydedildi.", NotificationType.Success);
                    ClearForm();
                }));
            }
            catch (BusinessException ex)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("İş Kuralı Hatası", ex.Message, NotificationType.Error);
                }));
            }
            catch (ValidationException ex)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Doğrulama Hatası", ex.Message, NotificationType.Error);
                }));
            }
            catch (DatabaseQueryException ex)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Veritabanı Hatası", ex.Message, NotificationType.Error);
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Hata", $"Beklenmeyen bir hata oluştu: {ex.Message}", NotificationType.Error);
                }));
            }
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtPassword.Text = string.Empty;
            picProfilePhoto.Image = null;
            _uploadedFilePath = null;

            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0;
            if (cmbTitle.Items.Count > 0)
                cmbTitle.SelectedIndex = 0;
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCompanyRegister_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is Form anaForm)
            {
                Form dimmer = new Form();
                dimmer.FormBorderStyle = FormBorderStyle.None;
                dimmer.BackColor = Color.Black;
                dimmer.Opacity = 0.60d;
                dimmer.ShowInTaskbar = false;
                dimmer.StartPosition = FormStartPosition.Manual;
                dimmer.Location = anaForm.PointToScreen(Point.Empty);
                dimmer.Size = anaForm.Size;

                using (CompanyRegisterForm popup = new CompanyRegisterForm())
                {
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    dimmer.Show(anaForm);
                    popup.ShowDialog(dimmer);
                    dimmer.Close();
                }
            }
        }
    }
}