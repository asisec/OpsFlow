using OpsFlow.Core.Enums;

namespace OpsFlow.UI.Forms.Notifications
{
    public class SuccessNotification : BaseNotificationForm
    {
        public SuccessNotification(string title, string message, Form? owner = null)
            : base(title, message, NotificationType.Success, owner)
        {
        }
    }
}