using OpsFlow.Core.Enums;
using System.Windows.Forms;

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