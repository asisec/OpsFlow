namespace OpsFlow.Core.Config
{
    public sealed class DatabaseSettings
    {
        public required string Host { get; set; } = string.Empty;
        public required int Port { get; init; }
        public required string Database { get; set; } = string.Empty;
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;

        public string ConnectionString =>
            $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
    }
}