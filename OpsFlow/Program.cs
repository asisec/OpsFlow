using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpsFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DotNetEnv.Env.Load();

            ApplicationConfiguration.Initialize();

            Task.Run(() =>
            {
                try
                {
                    var service = new DatabaseConnectionService();
                    using (var context = service.CreateContext())
                    {
                        context.Database.CanConnect();
                    }
                }
                catch
                {
                }
            });

            Application.Run(new LoginForm());
        }
    }
}