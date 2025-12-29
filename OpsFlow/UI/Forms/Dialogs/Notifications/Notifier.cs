using OpsFlow.Core.Enums;
using OpsFlow.UI.Forms.Notifications;

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
                .Where(f => f.Visible && f.WindowState != FormWindowState.Minimized)
                .OrderByDescending(f => f.TopMost)
                .ThenBy(f => f.TabIndex)
                .LastOrDefault();

            BaseNotificationForm notification = type switch
            {
                NotificationType.Success => new SuccessNotification(title, message, activeOwner),
                NotificationType.Error => new ErrorNotification(title, message, activeOwner),
                NotificationType.Warning => new WarningNotification(title, message, activeOwner),
                NotificationType.Information => new InformationNotification(title, message, activeOwner),
                _ => new InformationNotification(title, message, activeOwner)
            };

            _currentNotification = notification;

            if (activeOwner != null && !activeOwner.IsDisposed)
            {
                notification.Show(activeOwner);
                notification.BringToFront();
            }
            else
            {
                notification.TopMost = true;
                notification.Show();
            }
        }
    }
}