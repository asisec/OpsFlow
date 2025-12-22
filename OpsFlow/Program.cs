using OpsFlow.UI.Forms;
using DotNetEnv;

namespace OpsFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Env.Load();
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm()); 
        }
    }
}