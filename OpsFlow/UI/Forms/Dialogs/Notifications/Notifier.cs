using OpsFlow.Core.Enums;
using OpsFlow.UI.Forms.Notifications;
using System.Linq;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Dialogs
{
    public static class Notifier
    {
        private static BaseNotificationForm? _currentNotification;

        public static void Show(string title, string message, NotificationType type)
        {
            if (_currentNotification != null && !_currentNotification.IsDisposed)
            {
                _currentNotification.Close();
                _currentNotification.Dispose();
            }

            Form? activeOwner = Application.OpenForms.Cast<Form>()
                .LastOrDefault(f => f.Visible && f.WindowState != FormWindowState.Minimized);

            BaseNotificationForm notification = type switch
            {
                NotificationType.Success => new SuccessNotification(title, message, activeOwner),
                NotificationType.Error => new ErrorNotification(title, message, activeOwner),
                NotificationType.Warning => new WarningNotification(title, message, activeOwner),
                NotificationType.Info => new InfoNotification(title, message, activeOwner),
                _ => new InfoNotification(title, message, activeOwner)
            };

            _currentNotification = notification;

            if (activeOwner != null && !activeOwner.IsDisposed)
            {
                notification.Show(activeOwner);
            }
            else
            {
                notification.TopMost = true;
                notification.Show();
            }
        }
    }
}