using OpsFlow.Core.Enums;
using OpsFlow.UI.Forms.Notifications;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Dialogs
{
    public static class Notifier
    {
        public static void Show(string title, string message, NotificationType type)
        {
            BaseNotificationForm notification = type switch
            {
                NotificationType.Success => new SuccessNotification(title, message),
                NotificationType.Error => new ErrorNotification(title, message),
                NotificationType.Warning => new WarningNotification(title, message),
                NotificationType.Info => new InfoNotification(title, message),
                _ => new InfoNotification(title, message)
            };

            notification.Show();
        }

        public static void Show(string title, string message, NotificationType type, Form? owner)
        {
            Show(title, message, type);
        }
    }
}