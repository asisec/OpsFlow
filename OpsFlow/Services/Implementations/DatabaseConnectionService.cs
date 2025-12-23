using OpsFlow.Core.Config;
using OpsFlow.Core.Exceptions;
using OpsFlow.Data.Config;
using OpsFlow.Data.Context;
using OpsFlow.Services.Interfaces;


namespace OpsFlow.Services.Implementations
{
    public sealed class DatabaseConnectionService : IDatabaseConnectionService
    {
        private readonly DatabaseSettings _settings;

        public DatabaseConnectionService()
        {
            _settings = new DatabaseSettings
            {
                Host = GetEnv("DB_HOST"),
                Port = int.Parse(GetEnv("DB_PORT")),
                Database = GetEnv("DB_DATABASE"),
                Username = GetEnv("DB_USERNAME"),
                Password = GetEnv("DB_PASSWORD")
            };
        }

        public AppDbContext CreateContext()
        {
            try
            {
                var options = DbContextConfigurator.Configure(_settings);
                return new AppDbContext(options);
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException(
                    "Veritabanı bağlantısı kurulamadı.", ex
                    );
            }
        }

        public static string GetEnv(string key)
        {
            var value = Environment.GetEnvironmentVariable(key);

            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidConfigurationException($"{key} environment değeri boş veya tanımsız");
            return value;
        }
    }
}
