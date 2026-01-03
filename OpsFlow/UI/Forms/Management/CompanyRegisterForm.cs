using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Core.Services;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs.Notifications;

namespace OpsFlow.UI.Forms.Management
{
    public partial class CompanyRegisterForm : BaseForm
    {
        private bool _isProcessing = false;

        public CompanyRegisterForm()
        {
            InitializeComponent();
            btnSaveCompany.Click += BtnSaveCompany_Click;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private async void BtnSaveCompany_Click(object? sender, EventArgs e)
        {
            if (_isProcessing)
                return;

            _isProcessing = true;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    btnSaveCompany.Enabled = false;
                    btnSaveCompany.Text = "Kaydediliyor...";
                }));
            }
            else
            {
                btnSaveCompany.Enabled = false;
                btnSaveCompany.Text = "Kaydediliyor...";
            }

            try
            {
                string companyName = txtName.Text.Trim();
                string taxNumber = txtTaxNumber.Text.Trim();
                string address = txtAddress.Text.Trim();
                string phone = txtPhone.Text.Trim();

                var validationResult = CompanyValidationHelper.ValidateCompanyForm(
                    companyName, taxNumber, phone);

                if (!validationResult.IsValid)
                {
                    Notifier.Show("Hata", validationResult.ErrorMessage!, NotificationType.Error);
                    return;
                }

                Notifier.Show("Kaydediliyor", "Şirket bilgileri kaydediliyor...", NotificationType.Information);

                var newCompany = new Company
                {
                    CompanyName = companyName,
                    TaxNumber = string.IsNullOrWhiteSpace(taxNumber) ? null : taxNumber,
                    Address = string.IsNullOrWhiteSpace(address) ? null : address,
                    Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                    CreatedAt = DateTime.UtcNow
                };

                using var context = DatabaseManager.CreateContext();
                var companyService = new CompanyService(context);
                await companyService.RegisterCompanyAsync(newCompany);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        Notifier.Show("Başarılı", "Şirket başarıyla kaydedildi.", NotificationType.Success);
                        ClearForm();
                    }));
                }
                else
                {
                    Notifier.Show("Başarılı", "Şirket başarıyla kaydedildi.", NotificationType.Success);
                    ClearForm();
                }

                await Task.Delay(1200);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Close()));
                }
                else
                {
                    this.Close();
                }
            }
            catch (BusinessException ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        Notifier.Show("İş Kuralı Hatası", ex.Message, NotificationType.Error);
                    }));
                }
                else
                {
                    Notifier.Show("İş Kuralı Hatası", ex.Message, NotificationType.Error);
                }
            }
            catch (ValidationException ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        Notifier.Show("Doğrulama Hatası", ex.Message, NotificationType.Error);
                    }));
                }
                else
                {
                    Notifier.Show("Doğrulama Hatası", ex.Message, NotificationType.Error);
                }
            }
            catch (DatabaseQueryException ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null && !ex.Message.Contains(ex.InnerException.Message))
                {
                    errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        Notifier.Show("Veritabanı Hatası", errorMessage, NotificationType.Error);
                    }));
                }
                else
                {
                    Notifier.Show("Veritabanı Hatası", errorMessage, NotificationType.Error);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Beklenmeyen bir hata oluştu: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        Notifier.Show("Hata", errorMessage, NotificationType.Error);
                    }));
                }
                else
                {
                    Notifier.Show("Hata", errorMessage, NotificationType.Error);
                }
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnSaveCompany.Enabled = true;
                            btnSaveCompany.Text = "Kaydet";
                            _isProcessing = false;
                        }));
                    }
                    else
                    {
                        btnSaveCompany.Enabled = true;
                        btnSaveCompany.Text = "Kaydet";
                        _isProcessing = false;
                    }
                }
            }
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtTaxNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
    }
}