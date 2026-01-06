namespace OpsFlow.UI.Forms.Management;

public partial class TaskListForm : Form
{
    public TaskListForm()
    {
        InitializeComponent();
    }

    private void btnNewTask_Click(object sender, EventArgs e)
    {
        if (this.FindForm() is Form anaForm)
        {
            Form dimmer = new Form();
            dimmer.FormBorderStyle = FormBorderStyle.None;
            dimmer.BackColor = Color.Black;
            dimmer.Opacity = 0.70d;
            dimmer.ShowInTaskbar = false;
            dimmer.StartPosition = FormStartPosition.Manual;
            dimmer.Location = anaForm.PointToScreen(Point.Empty);
            dimmer.Size = anaForm.Size;
            using (AddTaskForm popup = new AddTaskForm())
            {
                popup.StartPosition = FormStartPosition.CenterScreen;

                dimmer.Show(anaForm);
                popup.ShowDialog(dimmer);
                dimmer.Close();
            }
        }
    }

    private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void TaskListForm_Load(object sender, EventArgs e)
    {
        cmbDept.Text = "Departman";
        cmbDept.StartIndex = -1;
        cmbStatus.Text = "Aktif, beklemede ve geciken";
        cmbStatus.StartIndex = -1;
        cmbPriority.Text = "Yüksek, orta ve düşük";
        cmbPriority.StartIndex = -1;
    }
}