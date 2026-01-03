using Azure.Storage.Blobs;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Core.Services
{
    public class AppBootstrapper
    {
        private readonly IDatabaseConnectionService _dbService;

        public AppBootstrapper(IDatabaseConnectionService dbService)
        {
            _dbService = dbService;
        }

        public async Task InitializeAsync(Action<string, int> progressCallback)
        {
            progressCallback("Yapılandırma dosyaları kontrol ediliyor...", 10);
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            if (!File.Exists(envPath))
            {
                throw new ConfigurationException("Kritik sistem dosyası (.env) bulunamadı.");
            }

            ValidateEnvironmentVariables();
            await Task.Delay(300);

            progressCallback("Veritabanı bağlantısı doğrulanıyor...", 30);
            bool isDbOk = await Task.Run(() =>
            {
                try
                {
                    using var context = _dbService.CreateContext();
                    return context.Database.CanConnect();
                }
                catch { return false; }
            });

            if (!isDbOk)
            {
                throw new DatabaseConnectionException("Veritabanı sunucusu yanıt vermiyor.");
            }
            await Task.Delay(300);

            progressCallback("Depolama servisleri kontrol ediliyor...", 50);
            await ValidateStorageServicesAsync();
            await Task.Delay(300);

            progressCallback("E-posta servisleri hazırlanıyor...", 70);
            ValidateEmailConfiguration();
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "EmailTemplates", "VerificationCode.html");
            if (!File.Exists(templatePath))
            {
                throw new ResourceException("E-posta şablonları eksik.");
            }
            await Task.Delay(300);

            progressCallback("Sistem kaynakları kontrol ediliyor...", 85);
            ValidateResourceFiles();
            await Task.Delay(300);

            progressCallback("Uygulama hazır, başlatılıyor...", 100);
            await Task.Delay(500);
        }

        private void ValidateEnvironmentVariables()
        {
            var requiredVars = new[]
            {
                "DB_HOST", "DB_PORT", "DB_DATABASE", "DB_USERNAME", "DB_PASSWORD",
                "SMTP_HOST", "SMTP_PORT", "SMTP_EMAIL", "SMTP_PASSWORD"
            };

            var missingVars = new List<string>();
            foreach (var varName in requiredVars)
            {
                if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(varName)))
                {
                    missingVars.Add(varName);
                }
            }

            if (missingVars.Any())
            {
                throw new ConfigurationException($"Eksik ortam değişkenleri: {string.Join(", ", missingVars)}");
            }

            var useAzure = Environment.GetEnvironmentVariable("USE_AZURE_STORAGE");
            if (!string.IsNullOrWhiteSpace(useAzure) && bool.TryParse(useAzure, out bool useAzureStorage) && useAzureStorage)
            {
                if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING")))
                {
                    throw new ConfigurationException("Azure Storage kullanılıyor ancak AZURE_STORAGE_CONNECTION_STRING tanımlı değil.");
                }
            }
        }

        private async Task ValidateStorageServicesAsync()
        {
            var useAzure = Environment.GetEnvironmentVariable("USE_AZURE_STORAGE");
            if (!string.IsNullOrWhiteSpace(useAzure) && bool.TryParse(useAzure, out bool useAzureStorage) && useAzureStorage)
            {
                try
                {
                    string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                    var connectionString = ReadConnectionStringFromEnvFile(envPath);
                    
                    if (string.IsNullOrWhiteSpace(connectionString))
                    {
                        throw new ConfigurationException("USE_AZURE_STORAGE=true olarak ayarlandı ancak AZURE_STORAGE_CONNECTION_STRING tanımlı değil.");
                    }

                    connectionString = connectionString.Trim();
                    
                    if (connectionString.StartsWith("\"") && connectionString.EndsWith("\""))
                    {
                        connectionString = connectionString.Substring(1, connectionString.Length - 2).Trim();
                    }
                    if (connectionString.StartsWith("'") && connectionString.EndsWith("'"))
                    {
                        connectionString = connectionString.Substring(1, connectionString.Length - 2).Trim();
                    }

                    if (connectionString.Contains("AccountName-") || connectionString.Contains("AccountKey-"))
                    {
                        connectionString = connectionString.Replace("DefaultEndpointsProtocol-DefaultEndpointsProtocol-", "DefaultEndpointsProtocol=")
                                                          .Replace("AccountName-", "AccountName=")
                                                          .Replace("AccountKey-", "AccountKey=")
                                                          .Replace("EndpointSuffix-", "EndpointSuffix=")
                                                          .Replace("--", "==");
                    }

                    if (!connectionString.Contains("AccountName=") || !connectionString.Contains("AccountKey="))
                    {
                        string preview = connectionString.Length > 80 ? connectionString.Substring(0, 77) + "..." : connectionString;
                        throw new ConfigurationException($"AZURE_STORAGE_CONNECTION_STRING geçersiz format. Connection string 'AccountName=' ve 'AccountKey=' içermelidir.\n\nOkunan değer: {preview}\n\nDoğru format: DefaultEndpointsProtocol=https;AccountName=HESAP_ADI;AccountKey=ANAHTAR;EndpointSuffix=core.windows.net");
                    }

                    if (!connectionString.Contains("DefaultEndpointsProtocol="))
                    {
                        connectionString = "DefaultEndpointsProtocol=https;" + connectionString;
                    }

                    await Task.Run(async () =>
                    {
                        try
                        {
                            var blobServiceClient = new BlobServiceClient(connectionString);
                            var properties = await blobServiceClient.GetPropertiesAsync();
                            
                            var containerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONTAINER_NAME") ?? "avatars";
                            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                            
                            try
                            {
                                await containerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                            }
                            catch (Azure.RequestFailedException ex) when (ex.ErrorCode == "PublicAccessNotPermitted")
                            {
                                await containerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.None);
                            }
                        }
                        catch (FormatException formatEx)
                        {
                            string errorMsg = formatEx.Message;
                            if (formatEx.InnerException != null)
                            {
                                errorMsg += $" ({formatEx.InnerException.Message})";
                            }
                            throw new ConfigurationException($"Connection string formatı geçersiz: {errorMsg}. Lütfen .env dosyasında connection string'in tırnak içinde olduğundan ve tek satırda olduğundan emin olun.", formatEx);
                        }
                        catch (ArgumentException argEx)
                        {
                            string errorMsg = argEx.Message;
                            if (argEx.InnerException != null)
                            {
                                errorMsg += $" ({argEx.InnerException.Message})";
                            }
                            throw new ConfigurationException($"Connection string geçersiz: {errorMsg}. Lütfen Azure Portal'dan connection string'i kontrol edin ve .env dosyasında tırnak içinde yazın.", argEx);
                        }
                        catch (Azure.RequestFailedException azureEx)
                        {
                            string errorDetail = $"Azure Storage bağlantı hatası: {azureEx.Message}";
                            if (azureEx.ErrorCode != null)
                            {
                                errorDetail += $" ({azureEx.ErrorCode})";
                            }
                            throw new FileUploadException(errorDetail, azureEx);
                        }
                        catch (Exception ex)
                        {
                            throw new FileUploadException($"Azure Blob Storage bağlantısı doğrulanamadı: {ex.Message}", ex);
                        }
                    });
                }
                catch (ConfigurationException)
                {
                    throw;
                }
                catch (FileUploadException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new FileUploadException("Azure Blob Storage bağlantısı doğrulanamadı.", ex);
                }
            }
            else
            {
                string uploadsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Uploads");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                string avatarsPath = Path.Combine(uploadsPath, "Avatars");
                if (!Directory.Exists(avatarsPath))
                {
                    Directory.CreateDirectory(avatarsPath);
                }
            }
        }

        private void ValidateEmailConfiguration()
        {
            var smtpHost = Environment.GetEnvironmentVariable("SMTP_HOST");
            var smtpPort = Environment.GetEnvironmentVariable("SMTP_PORT");

            if (string.IsNullOrWhiteSpace(smtpHost))
            {
                throw new ConfigurationException("SMTP_HOST ortam değişkeni tanımlı değil.");
            }

            if (string.IsNullOrWhiteSpace(smtpPort) || !int.TryParse(smtpPort, out _))
            {
                throw new ValidationException("SMTP_PORT geçerli bir sayı değil.");
            }
        }

        private void ValidateResourceFiles()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var requiredIcons = new[] { "Error.png", "Success.png", "Warning.png", "Information.png" };

            foreach (var icon in requiredIcons)
            {
                string iconPath = Path.Combine(baseDir, "Resources", "Icons", icon);
                if (!File.Exists(iconPath))
                {
                    throw new ResourceException($"Gerekli ikon dosyası bulunamadı: {icon}");
                }
            }

            string logoPath = Path.Combine(baseDir, "Resources", "Images", "Logo.png");
            if (!File.Exists(logoPath))
            {
            }
        }

        private string? ReadConnectionStringFromEnvFile(string envPath)
        {
            try
            {
                if (!File.Exists(envPath))
                    return null;

                var lines = File.ReadAllLines(envPath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        continue;

                    if (line.StartsWith("AZURE_STORAGE_CONNECTION_STRING=", StringComparison.OrdinalIgnoreCase))
                    {
                        int equalsIndex = line.IndexOf('=');
                        if (equalsIndex >= 0 && equalsIndex < line.Length - 1)
                        {
                            string value = line.Substring(equalsIndex + 1).Trim();
                            
                            if (value.StartsWith("\"") && value.EndsWith("\""))
                            {
                                value = value.Substring(1, value.Length - 2);
                            }
                            else if (value.StartsWith("'") && value.EndsWith("'"))
                            {
                                value = value.Substring(1, value.Length - 2);
                            }
                            
                            return value;
                        }
                    }
                }
            }
            catch
            {
            }
            
            return Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        }
    }
}