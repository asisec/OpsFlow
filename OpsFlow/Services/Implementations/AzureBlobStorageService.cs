using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using OpsFlow.Core.Config;
using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class AzureBlobStorageService : IFileUploadService
    {
        private readonly AzureBlobStorageSettings _settings;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;

        public AzureBlobStorageService()
        {
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            var connectionString = ReadConnectionStringFromEnvFile(envPath) ?? Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            var containerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONTAINER_NAME") ?? "avatars";
            var baseUrl = Environment.GetEnvironmentVariable("AZURE_STORAGE_BASE_URL");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ConfigurationException("AZURE_STORAGE_CONNECTION_STRING env değeri boş veya tanımsız.");

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

            _settings = new AzureBlobStorageSettings
            {
                ConnectionString = connectionString,
                ContainerName = containerName,
                BaseUrl = baseUrl
            };

            _blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
            _containerClient = _blobServiceClient.GetBlobContainerClient(_settings.ContainerName);

            try
            {
                _containerClient.CreateIfNotExists(PublicAccessType.Blob);
            }
            catch (Azure.RequestFailedException ex) when (ex.ErrorCode == "PublicAccessNotPermitted")
            {
                _containerClient.CreateIfNotExists(PublicAccessType.None);
            }
        }

        public async Task<string> UploadProfilePhotoAsync(string filePath, int? userId = null)
        {
            try
            {
                FileValidationHelper.ValidateFileForUpload(filePath);

                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string fileName = GenerateUniqueFileName(userId, extension);
                string blobName = $"Avatars/{fileName}";

                BlobClient blobClient = _containerClient.GetBlobClient(blobName);

                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    await blobClient.UploadAsync(fileStream, overwrite: true);
                }

                if (!string.IsNullOrWhiteSpace(_settings.BaseUrl))
                {
                    string baseUrl = _settings.BaseUrl.TrimEnd('/');
                    return $"{baseUrl}/{_settings.ContainerName}/{blobName}";
                }

                return blobClient.Uri.ToString();
            }
            catch (ArgumentException ex)
            {
                throw new FileUploadException($"Dosya doğrulama hatası: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new FileUploadException($"Azure Blob Storage'a dosya yükleme sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task DeleteFileAsync(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            try
            {
                string blobName = ExtractBlobNameFromUrl(relativePath);
                BlobClient blobClient = _containerClient.GetBlobClient(blobName);

                if (await blobClient.ExistsAsync())
                {
                    await blobClient.DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                throw new FileUploadException($"Azure Blob Storage'dan dosya silme sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        public bool FileExists(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return false;

            try
            {
                string blobName = ExtractBlobNameFromUrl(relativePath);
                BlobClient blobClient = _containerClient.GetBlobClient(blobName);
                return blobClient.Exists().Value;
            }
            catch
            {
                return false;
            }
        }

        public string GetFullPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                throw new ArgumentException("Göreli yol boş olamaz.");

            if (Uri.TryCreate(relativePath, UriKind.Absolute, out Uri? uri))
            {
                return uri.ToString();
            }

            if (!string.IsNullOrWhiteSpace(_settings.BaseUrl))
            {
                string baseUrl = _settings.BaseUrl.TrimEnd('/');
                return $"{baseUrl}/{_settings.ContainerName}/{relativePath}";
            }

            BlobClient blobClient = _containerClient.GetBlobClient(relativePath);
            return blobClient.Uri.ToString();
        }

        private string ExtractBlobNameFromUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
            {
                string path = uri.AbsolutePath;
                if (path.StartsWith("/"))
                    path = path.Substring(1);

                int containerIndex = path.IndexOf(_settings.ContainerName);
                if (containerIndex >= 0)
                {
                    return path.Substring(containerIndex + _settings.ContainerName.Length + 1);
                }

                return path;
            }

            return url;
        }

        private string GenerateUniqueFileName(int? userId, string extension)
        {
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string guid = Guid.NewGuid().ToString("N")[..8];
            string prefix = userId.HasValue ? $"user_{userId}_" : "avatar_";

            return $"{prefix}{timestamp}_{guid}{extension}";
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

            return null;
        }
    }
}