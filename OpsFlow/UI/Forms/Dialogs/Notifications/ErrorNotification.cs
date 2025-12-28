using OpsFlow.Core.Enums;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public class ErrorNotification : BaseNotificationForm
    {
        public ErrorNotification(string title, string message, Form? owner = null)
            : base(title, message, NotificationType.Error, owner)
        {
        }
    }
}