using OpsFlow.Core.Enums;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public class WarningNotification : BaseNotificationForm
    {
        public WarningNotification(string title, string message, Form? owner = null)
            : base(title, message, NotificationType.Warning, owner)
        {
        }
    }
}