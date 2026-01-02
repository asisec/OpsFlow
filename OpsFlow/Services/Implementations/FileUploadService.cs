using OpsFlow.Core.Exceptions;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _uploadBasePath;
        private const string AvatarsFolder = "Avatars";

        public FileUploadService()
        {
            _uploadBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Uploads");
            EnsureDirectoryExists();
        }

        public async Task<string> UploadProfilePhotoAsync(string filePath, int? userId = null)
        {
            try
            {
                FileValidationHelper.ValidateFileForUpload(filePath);

                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string fileName = GenerateUniqueFileName(userId, extension);
                string relativePath = Path.Combine(AvatarsFolder, fileName);
                string fullPath = GetFullPath(relativePath);

                string avatarDirectory = Path.Combine(_uploadBasePath, AvatarsFolder);
                if (!Directory.Exists(avatarDirectory))
                {
                    Directory.CreateDirectory(avatarDirectory);
                }

                await Task.Run(() =>
                {
                    File.Copy(filePath, fullPath, overwrite: true);
                });

                return relativePath.Replace('\\', '/');
            }
            catch (ArgumentException ex)
            {
                throw new FileUploadException($"Dosya doğrulama hatası: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new FileUploadException($"Dosya yükleme sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        public async Task DeleteFileAsync(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            try
            {
                string fullPath = GetFullPath(relativePath);
                if (File.Exists(fullPath))
                {
                    await Task.Run(() =>
                    {
                        File.Delete(fullPath);
                    });
                }
            }
            catch (Exception ex)
            {
                throw new FileUploadException($"Dosya silme sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        public bool FileExists(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return false;

            string fullPath = GetFullPath(relativePath);
            return File.Exists(fullPath);
        }

        public string GetFullPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                throw new ArgumentException("Göreli yol boş olamaz.");

            return Path.Combine(_uploadBasePath, relativePath.Replace('/', Path.DirectorySeparatorChar));
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(_uploadBasePath))
            {
                Directory.CreateDirectory(_uploadBasePath);
            }
        }

        private string GenerateUniqueFileName(int? userId, string extension)
        {
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string guid = Guid.NewGuid().ToString("N")[..8];
            string prefix = userId.HasValue ? $"user_{userId}_" : "avatar_";

            return $"{prefix}{timestamp}_{guid}{extension}";
        }
    }
}

