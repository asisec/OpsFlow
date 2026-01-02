namespace OpsFlow.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadProfilePhotoAsync(string filePath, int? userId = null);
        Task DeleteFileAsync(string relativePath);
        bool FileExists(string relativePath);
        string GetFullPath(string relativePath);
    }
}

