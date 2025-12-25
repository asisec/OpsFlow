using System.Drawing;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public class SuccessNotification : BaseNotificationForm
    {
        public SuccessNotification(string title, string message)
            : base(title, message, Color.FromArgb(39, 174, 96), SystemIcons.Information)
        {
        }
    }
}