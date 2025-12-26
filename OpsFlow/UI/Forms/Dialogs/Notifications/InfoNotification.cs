using System.Drawing;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public class InfoNotification : BaseNotificationForm
    {
        public InfoNotification(string title, string message, Form? owner = null)
            : base(title, message, Color.FromArgb(52, 152, 219), SystemIcons.Information, owner)
        {
        }
    }
}