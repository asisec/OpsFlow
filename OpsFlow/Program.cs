using DotNetEnv;
using OpsFlow.Services.Implementations;
using OpsFlow.Services.Interfaces;

namespace OpsFlow
{
    internal static class Program
    {
        public static IDatabaseConnectionService Database { get; private set; }

        [STAThread]
        static void Main()
        {
            var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");

            Env.Load(envPath);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            Database = new DatabaseConnectionService();

            ApplicationConfiguration.Initialize();
            Application.Run(new UI.Forms.ResetPasswordForm());
        }
    }
}
