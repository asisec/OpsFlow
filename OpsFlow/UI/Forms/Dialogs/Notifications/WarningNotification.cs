using OpsFlow.Core.Enums;

namespace OpsFlow.UI.Forms.Dialogs.Notifications
{
    public class WarningNotification : BaseNotificationForm
    {
        public WarningNotification(string title, string message, Form? owner = null)
            : base(title, message, NotificationType.Warning, owner)
        {
        }
    }
}