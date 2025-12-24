using OpsFlow.UI.Forms;
using System;
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

            Application.Run(new LoginForm());
        }
    }
}