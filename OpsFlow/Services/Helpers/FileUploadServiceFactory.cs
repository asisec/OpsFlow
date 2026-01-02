using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Helpers
{
    public static class FileUploadServiceFactory
    {
        public static IFileUploadService Create()
        {
            var useAzure = Environment.GetEnvironmentVariable("USE_AZURE_STORAGE");
            
            if (!string.IsNullOrWhiteSpace(useAzure) && 
                bool.TryParse(useAzure, out bool useAzureStorage) && 
                useAzureStorage)
            {
                return new AzureBlobStorageService();
            }

            return new FileUploadService();
        }
    }
}

