using OpsFlow.Core.Enums;

namespace OpsFlow.UI.Forms.Notifications
{
    public class InformationNotification : BaseNotificationForm
    {
        public InformationNotification(string title, string message, Form? owner = null)
            : base(title, message, NotificationType.Information, owner)
        {
        }
    }
}