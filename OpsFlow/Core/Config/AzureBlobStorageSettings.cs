namespace OpsFlow.Core.Config
{
    public sealed class AzureBlobStorageSettings
    {
        public required string ConnectionString { get; set; } = string.Empty;
        public required string ContainerName { get; set; } = "avatars";
        public string? BaseUrl { get; set; }
    }
}

