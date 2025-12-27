using OpsFlow.Core.Enums;
using System.Windows.Forms;

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