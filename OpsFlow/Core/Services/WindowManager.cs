using OpsFlow.UI.Forms.Core;

namespace OpsFlow.Core.Services
{
    public static class WindowManager
    {
        private static readonly ApplicationContext _context = new ApplicationContext();

        public static void Run<T>() where T : Form, new()
        {
            var form = new T();
            _context.MainForm = form;
            Application.Run(_context);
        }

        public static async void Switch<T>(Form currentForm, params object[]? args) where T : BaseForm
        {
            bool hasNotification = Application.OpenForms.Cast<Form>()
                .Any(f => f.GetType().BaseType?.Name == "BaseNotificationForm");

            if (hasNotification)
            {
                await Task.Delay(1200);
            }

            T nextForm;

            if (args != null && args.Length > 0)
                nextForm = (T)Activator.CreateInstance(typeof(T), args)!;
            else
                nextForm = (T)Activator.CreateInstance(typeof(T))!;

            nextForm.Show();
            _context.MainForm = nextForm;

            currentForm.Hide();
            currentForm.Close();
            currentForm.Dispose();
        }

        public static void Exit()
        {
            Application.Exit();
        }
    }
}