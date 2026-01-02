using System.Text.RegularExpressions;

namespace OpsFlow.Services.Helpers
{
    public static class FileValidationHelper
    {
        private static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };
        private const long MaxFileSizeBytes = 5 * 1024 * 1024;
        private const int MaxFileNameLength = 255;

        public static bool IsValidImageFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return false;

            if (!File.Exists(filePath))
                return false;

            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            return AllowedImageExtensions.Contains(extension);
        }

        public static bool IsValidFileSize(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            var fileInfo = new FileInfo(filePath);
            return fileInfo.Length > 0 && fileInfo.Length <= MaxFileSizeBytes;
        }

        public static bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            if (fileName.Length > MaxFileNameLength)
                return false;

            string invalidChars = new string(Path.GetInvalidFileNameChars());
            if (fileName.IndexOfAny(invalidChars.ToCharArray()) >= 0)
                return false;

            return true;
        }

        public static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            string extension = Path.GetExtension(fileName);
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            string sanitized = Regex.Replace(nameWithoutExtension, @"[^a-zA-Z0-9_-]", "_");
            sanitized = sanitized.Trim('_');

            if (string.IsNullOrWhiteSpace(sanitized))
                sanitized = "file";

            if (sanitized.Length > MaxFileNameLength - extension.Length)
                sanitized = sanitized.Substring(0, MaxFileNameLength - extension.Length);

            return sanitized + extension;
        }

        public static void ValidateFileForUpload(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Dosya yolu boş olamaz.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Dosya bulunamadı.", filePath);

            if (!IsValidImageFile(filePath))
                throw new ArgumentException("Geçersiz dosya tipi. Sadece JPG, JPEG, PNG ve BMP dosyaları kabul edilir.");

            if (!IsValidFileSize(filePath))
                throw new ArgumentException($"Dosya boyutu çok büyük. Maksimum dosya boyutu: {MaxFileSizeBytes / (1024 * 1024)} MB.");
        }
    }
}

