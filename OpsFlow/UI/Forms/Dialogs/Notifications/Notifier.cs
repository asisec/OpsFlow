using OpsFlow.Core.Enums;
using OpsFlow.UI.Forms.Notifications;
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

            Form? activeOwner = Form.ActiveForm;

            if (activeOwner != null && !activeOwner.Visible)
            {
                activeOwner = null;
            }

            BaseNotificationForm notification = type switch
            {
                NotificationType.Success => new SuccessNotification(title, message, activeOwner),
                NotificationType.Error => new ErrorNotification(title, message, activeOwner),
                NotificationType.Warning => new WarningNotification(title, message, activeOwner),
                NotificationType.Info => new InfoNotification(title, message, activeOwner),
                _ => new InfoNotification(title, message, activeOwner)
            };

            _currentNotification = notification;
            notification.Show();
        }
    }
}