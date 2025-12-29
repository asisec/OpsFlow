using OpsFlow.UI.Forms;

namespace OpsFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DotNetEnv.Env.Load();

            ApplicationConfiguration.Initialize();

            Application.Run(new SplashScreenForm());
        }
    }
}