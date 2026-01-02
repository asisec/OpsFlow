using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs.Notifications;

namespace OpsFlow.UI.Forms.Management
{
    public partial class AddPersonelForm : BaseForm
    {
        private readonly IFileUploadService _fileUploadService;
        private string? _uploadedFilePath;

        public string? UploadedAvatarPath => _uploadedFilePath;

        public AddPersonelForm()
        {
            InitializeComponent();
            if (this.HeaderPanel != null) this.HeaderPanel.SendToBack();
            _fileUploadService = new FileUploadService();
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

                        string relativePath = await _fileUploadService.UploadProfilePhotoAsync(selectedFilePath);
                        _uploadedFilePath = relativePath;

                        string fullPath = _fileUploadService.GetFullPath(relativePath);
                        picProfilePhoto.Image = Image.FromFile(fullPath);

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCompanyRegister_Click(object sender, EventArgs e)
        {
            Form dimmer = new Form();
            dimmer.FormBorderStyle = FormBorderStyle.None;
            dimmer.BackColor = Color.Black;
            dimmer.Opacity = 0.60d;
            dimmer.ShowInTaskbar = false;
            dimmer.StartPosition = FormStartPosition.Manual;
            dimmer.Location = this.Location;
            dimmer.Size = this.Size;
            using (CompanyRegisterForm popup = new CompanyRegisterForm())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                dimmer.Show(this);
                popup.ShowDialog(dimmer);
                dimmer.Close();
            }
        }
    }
}