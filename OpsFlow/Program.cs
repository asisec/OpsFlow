using OpsFlow.Core.Services;
using OpsFlow.UI.Forms.Onboarding;
using OpsFlow.UI.Forms.Management;

namespace OpsFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DotNetEnv.Env.Load();
            ApplicationConfiguration.Initialize();
            WindowManager.Run<AddPersonelForm>();
        }
    }
}