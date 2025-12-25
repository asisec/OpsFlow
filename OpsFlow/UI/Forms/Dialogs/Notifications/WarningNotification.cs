using System.Drawing;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public class WarningNotification : BaseNotificationForm
    {
        public WarningNotification(string title, string message)
            : base(title, message, Color.FromArgb(243, 156, 18), SystemIcons.Warning)
        {
        }
    }
}