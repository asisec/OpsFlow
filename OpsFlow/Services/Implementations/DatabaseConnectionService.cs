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
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var portValue = Environment.GetEnvironmentVariable("DB_PORT");
            var database = Environment.GetEnvironmentVariable("DB_DATABASE");
            var username = Environment.GetEnvironmentVariable("DB_USERNAME");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (string.IsNullOrWhiteSpace(host))
                throw new ConfigurationException("DB_HOST env değeri boş veya tanımsız.");

            if (string.IsNullOrWhiteSpace(portValue))
                throw new ConfigurationException("DB_PORT env değeri boş veya tanımsız.");

            if (!int.TryParse(portValue, out int port))
                throw new ValidationException($"DB_PORT sayısal değil: {portValue}");

            if (string.IsNullOrWhiteSpace(database))
                throw new ConfigurationException("DB_DATABASE env değeri boş veya tanımsız.");

            if (string.IsNullOrWhiteSpace(username))
                throw new ConfigurationException("DB_USERNAME env değeri boş veya tanımsız.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ConfigurationException("DB_PASSWORD env değeri boş veya tanımsız.");

            _settings = new DatabaseSettings
            {
                Host = host,
                Port = port,
                Database = database,
                Username = username,
                Password = password
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
                    $"Veritabanı bağlantısı kurulamadı: {ex.Message}"
                );
            }
        }
    }
}