namespace OpsFlow.UI.Forms.Management;

public partial class AddTaskForm : Form
{
    public AddTaskForm()
    {
        InitializeComponent();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}