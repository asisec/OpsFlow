using OpsFlow.Core.Enums;

namespace OpsFlow.UI.Forms.Dialogs.Notifications
{
    public class ErrorNotification : BaseNotificationForm
    {
        public ErrorNotification(string title, string message, Form? owner = null)
            : base(title, message, NotificationType.Error, owner)
        {
        }
    }
}