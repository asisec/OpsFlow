using DotNetEnv;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;
using OpsFlow.Core.Exceptions;
using Guna.UI2.WinForms;

namespace OpsFlow
{
    internal static class Program
    {
        public static IDatabaseConnectionService Database { get; private set; }

        [STAThread]
        static void Main()
        {
            try
            {
                var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                if (File.Exists(envPath))
                    Env.Load(envPath);

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

                Database = new DatabaseConnectionService();

                ApplicationConfiguration.Initialize();
                Application.Run(new UI.Forms.LoginForm());
            }
            catch (InvalidConfigurationException ex)
            {
                MessageBox.Show(
                    $"Config hatası: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (DatabaseConnectionException ex)
            {
                MessageBox.Show(
                    $"DB bağlantı hatası: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Bilinmeyen hata: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
