using OpsFlow.UI.Forms;

namespace OpsFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
            //biter injallah
        }
    }
}