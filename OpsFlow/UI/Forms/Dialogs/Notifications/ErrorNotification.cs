using System.Drawing;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public class ErrorNotification : BaseNotificationForm
    {
        public ErrorNotification(string title, string message, Form? owner = null)
            : base(title, message, Color.FromArgb(231, 76, 60), SystemIcons.Error, owner)
        {
        }
    }
}