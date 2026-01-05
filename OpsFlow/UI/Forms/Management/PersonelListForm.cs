using OpsFlow.Core.Enums;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Core.Services;
using OpsFlow.Services.Implementations;
using OpsFlow.UI.Forms.Core;
using OpsFlow.UI.Forms.Dialogs.Notifications;

namespace OpsFlow.UI.Forms.Management;

public partial class PersonelListForm : BaseForm
{
    private List<User> _allUsers = new List<User>();
    private List<User> _filteredUsers = new List<User>();
    private int _currentPage = 0;
    private const int PageSize = 6;
    private bool _isLoading = false;
    private System.Windows.Forms.Timer? _scrollTimer;
    private System.Windows.Forms.Timer? _searchTimer;

    public PersonelListForm()
    {
        InitializeComponent();
        if (this.HeaderPanel != null) this.HeaderPanel.SendToBack();
        
        cmbFilterDept.DropDownStyle = ComboBoxStyle.DropDown;
        cmbFilterRole.DropDownStyle = ComboBoxStyle.DropDown;
        cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDown;

        SetLoadingState();

        if (flpPersonelContainer != null)
        {
            flpPersonelContainer.AutoScroll = true;
            flpPersonelContainer.WrapContents = true;
            flpPersonelContainer.FlowDirection = FlowDirection.LeftToRight;
            flpPersonelContainer.BackColor = Color.FromArgb(17, 19, 25);
            
            SetModernScrollbarStyle();
            
            _scrollTimer = new System.Windows.Forms.Timer();
            _scrollTimer.Interval = 200;
            _scrollTimer.Tick += ScrollTimer_Tick;
            _scrollTimer.Start();
        }

        if (txtSearch != null)
        {
            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 100;
            _searchTimer.Tick += SearchTimer_Tick;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearch.Leave += TxtSearch_Leave;
        }

        cmbFilterDept.SelectedIndexChanged += CmbFilterDept_SelectedIndexChanged;
        cmbFilterRole.SelectedIndexChanged += CmbFilterRole_SelectedIndexChanged;
        cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;

        this.Load += PersonelListForm_Load;
    }

    private void SetLoadingState()
    {
        txtPersonel.Text = "Yükleniyor...";
        txtActivePersonel.Text = "Yükleniyor...";
        txtDep.Text = "Yükleniyor...";
    }

    private void SetModernScrollbarStyle()
    {
        if (flpPersonelContainer == null) return;

        try
        {
            flpPersonelContainer.HorizontalScroll.Enabled = false;
            flpPersonelContainer.HorizontalScroll.Visible = false;
            flpPersonelContainer.AutoScrollMargin = new Size(0, 0);
            flpPersonelContainer.AutoScrollMinSize = new Size(0, 0);
        }
        catch
        {
        }
    }

    private async void PersonelListForm_Load(object? sender, EventArgs e)
    {
        if (flpPersonelContainer != null)
        {
            flpPersonelContainer.WrapContents = true;
            flpPersonelContainer.FlowDirection = FlowDirection.LeftToRight;
        }
        await LoadFilterComboBoxesAsync();
        await LoadStatisticsAsync();
    }

    private async Task LoadFilterComboBoxesAsync()
    {
        try
        {
            using var roleContext = DatabaseManager.CreateContext();
            using var departmentContext = DatabaseManager.CreateContext();

            var roleService = new RoleService(roleContext);
            var departmentService = new DepartmentService(departmentContext);

            var rolesTask = roleService.GetAllRolesAsync();
            var departmentsTask = departmentService.GetAllDepartmentsAsync();

            await Task.WhenAll(rolesTask, departmentsTask);

            var roles = await rolesTask;
            var departments = await departmentsTask;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    LoadFilterComboBoxes(roles, departments);
                }));
            }
            else
            {
                LoadFilterComboBoxes(roles, departments);
            }
        }
        catch (DatabaseQueryException ex)
        {
            string errorMessage = ex.Message;
            if (ex.InnerException != null && !ex.Message.Contains(ex.InnerException.Message))
            {
                errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Veritabanı Hatası", errorMessage, NotificationType.Error);
                }));
            }
            else
            {
                Notifier.Show("Veritabanı Hatası", errorMessage, NotificationType.Error);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"Filtre verileri yüklenirken bir hata oluştu: {ex.Message}";
            if (ex.InnerException != null)
            {
                errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Hata", errorMessage, NotificationType.Error);
                }));
            }
            else
            {
                Notifier.Show("Hata", errorMessage, NotificationType.Error);
            }
        }
    }

    private void LoadFilterComboBoxes(List<Role> roles, List<Department> departments)
    {
        cmbFilterDept.BeginUpdate();
        cmbFilterDept.Items.Clear();
        cmbFilterDept.Items.Add("Departman");
        foreach (var department in departments)
            cmbFilterDept.Items.Add(department.DepartmentName);
        cmbFilterDept.Text = "Departman";
        cmbFilterDept.EndUpdate();

        cmbFilterRole.BeginUpdate();
        cmbFilterRole.Items.Clear();
        cmbFilterRole.Items.Add("Rol");
        foreach (var role in roles)
            cmbFilterRole.Items.Add(role.RoleName);
        cmbFilterRole.Text = "Rol";
        cmbFilterRole.EndUpdate();

        cmbFilterStatus.BeginUpdate();
        cmbFilterStatus.Items.Clear();
        cmbFilterStatus.Items.Add("Durum");
        cmbFilterStatus.Items.Add("Aktif");
        cmbFilterStatus.Items.Add("Pasif");
        cmbFilterStatus.Text = "Durum";
        cmbFilterStatus.EndUpdate();
    }

    private async Task LoadStatisticsAsync()
    {
        try
        {
            using var userContext = DatabaseManager.CreateContext();
            using var departmentContext = DatabaseManager.CreateContext();

            var userService = new UserService(userContext);
            var departmentService = new DepartmentService(departmentContext);

            var usersTask = Task.Run(() => userService.GetAllUsers());
            var departmentsTask = departmentService.GetAllDepartmentsAsync();

            await Task.WhenAll(usersTask, departmentsTask);

            var users = await usersTask;
            var departments = await departmentsTask;

            int totalPersonel = users.Count;
            int activePersonel = users.Count(u => u.IsActive);
            int totalDepartments = departments.Count;

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(async () =>
                {
                    await UpdateStatistics(totalPersonel, activePersonel, totalDepartments);
                    _allUsers = users;
                    _filteredUsers = users;
                    _currentPage = 0;
                    if (flpPersonelContainer != null)
                    {
                        flpPersonelContainer.Controls.Clear();
                    }
                    await LoadNextPage();
                }));
            }
            else
            {
                await UpdateStatistics(totalPersonel, activePersonel, totalDepartments);
                _allUsers = users;
                _filteredUsers = users;
                _currentPage = 0;
                if (flpPersonelContainer != null)
                {
                    flpPersonelContainer.Controls.Clear();
                }
                await LoadNextPage();
            }
        }
        catch (DatabaseQueryException ex)
        {
            string errorMessage = ex.Message;
            if (ex.InnerException != null && !ex.Message.Contains(ex.InnerException.Message))
            {
                errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Veritabanı Hatası", errorMessage, NotificationType.Error);
                }));
            }
            else
            {
                Notifier.Show("Veritabanı Hatası", errorMessage, NotificationType.Error);
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"İstatistikler yüklenirken bir hata oluştu: {ex.Message}";
            if (ex.InnerException != null)
            {
                errorMessage += $"\n\nDetay: {ex.InnerException.Message}";
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Notifier.Show("Hata", errorMessage, NotificationType.Error);
                }));
            }
            else
            {
                Notifier.Show("Hata", errorMessage, NotificationType.Error);
            }
        }
    }

    private async Task UpdateStatistics(int totalPersonel, int activePersonel, int totalDepartments)
    {
        await Task.Delay(300);

        txtPersonel.Text = totalPersonel.ToString();
        await Task.Delay(100);
        
        txtActivePersonel.Text = activePersonel.ToString();
        await Task.Delay(100);
        
        txtDep.Text = totalDepartments.ToString();
    }

    private void pnlHeader_Paint(object sender, PaintEventArgs e)
    {

    }

    private void guna2HtmlLabel3_Click(object sender, EventArgs e)
    {

    }

    private void ScrollTimer_Tick(object? sender, EventArgs e)
    {
        if (_isLoading || flpPersonelContainer == null)
            return;

        if (_currentPage * PageSize >= _filteredUsers.Count)
            return;

        try
        {
            int scrollTop = flpPersonelContainer.VerticalScroll.Value;
            int scrollMax = flpPersonelContainer.VerticalScroll.Maximum;
            int clientHeight = flpPersonelContainer.ClientSize.Height;

            if (scrollMax > 0 && scrollTop + clientHeight >= scrollMax - 100)
            {
                _ = LoadNextPage();
            }
        }
        catch
        {
        }
    }

    private async Task LoadNextPage()
    {
        if (_isLoading || flpPersonelContainer == null)
            return;

        int startIndex = _currentPage * PageSize;

        if (startIndex >= _filteredUsers.Count)
            return;

        int currentLoadedCount = flpPersonelContainer.Controls.Count;
        int expectedCount = startIndex + PageSize;
        
        if (currentLoadedCount >= expectedCount)
            return;

        _isLoading = true;

        try
        {
            var usersToLoad = _filteredUsers.Skip(startIndex).Take(PageSize).ToList();

            if (usersToLoad.Count == 0)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    flpPersonelContainer.SuspendLayout();
                    foreach (var user in usersToLoad)
                    {
                        var card = new PersonelCard();
                        card.SetUserData(user);
                        flpPersonelContainer.Controls.Add(card);
                    }
                    flpPersonelContainer.ResumeLayout(false);
                    flpPersonelContainer.PerformLayout();
                }));
            }
            else
            {
                flpPersonelContainer.SuspendLayout();
                foreach (var user in usersToLoad)
                {
                    var card = new PersonelCard();
                    card.SetUserData(user);
                    flpPersonelContainer.Controls.Add(card);
                }
                flpPersonelContainer.ResumeLayout(false);
                flpPersonelContainer.PerformLayout();
            }

            _currentPage++;
            await Task.Delay(50);
            
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    EnsureScrollbarVisible();
                }));
            }
            else
            {
                EnsureScrollbarVisible();
            }
        }
        finally
        {
            _isLoading = false;
        }
    }

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        if (_searchTimer != null && txtSearch != null)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }
    }

    private async void SearchTimer_Tick(object? sender, EventArgs e)
    {
        if (_searchTimer != null)
        {
            _searchTimer.Stop();
        }

        await ApplyFiltersAsync();
    }

    private void CmbFilterDept_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _ = ApplyFiltersAsync();
    }

    private void CmbFilterRole_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _ = ApplyFiltersAsync();
    }

    private void CmbFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _ = ApplyFiltersAsync();
    }

    private async Task ApplyFiltersAsync()
    {
        string searchText = txtSearch?.Text ?? string.Empty;
        searchText = searchText.Trim();

        string selectedDepartment = cmbFilterDept?.Text ?? "Departman";
        string selectedRole = cmbFilterRole?.Text ?? "Rol";
        string selectedStatus = cmbFilterStatus?.Text ?? "Durum";

        var filtered = _allUsers.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            filtered = filtered.Where(u => 
                (u.Name + " " + u.Surname).Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                u.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                u.Surname.Contains(searchText, StringComparison.OrdinalIgnoreCase));
        }

        if (selectedDepartment != "Departman" && !string.IsNullOrWhiteSpace(selectedDepartment))
        {
            filtered = filtered.Where(u => u.Department != null && u.Department.DepartmentName == selectedDepartment);
        }

        if (selectedRole != "Rol" && !string.IsNullOrWhiteSpace(selectedRole))
        {
            filtered = filtered.Where(u => u.Role != null && u.Role.RoleName == selectedRole);
        }

        if (selectedStatus != "Durum" && !string.IsNullOrWhiteSpace(selectedStatus))
        {
            bool isActive = selectedStatus == "Aktif";
            filtered = filtered.Where(u => u.IsActive == isActive);
        }

        _filteredUsers = filtered.ToList();

        _currentPage = 0;
        if (flpPersonelContainer != null)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    flpPersonelContainer.SuspendLayout();
                    flpPersonelContainer.Controls.Clear();
                    flpPersonelContainer.AutoScroll = true;
                    flpPersonelContainer.ResumeLayout(false);
                    flpPersonelContainer.PerformLayout();
                }));
            }
            else
            {
                flpPersonelContainer.SuspendLayout();
                flpPersonelContainer.Controls.Clear();
                flpPersonelContainer.AutoScroll = true;
                flpPersonelContainer.ResumeLayout(false);
                flpPersonelContainer.PerformLayout();
            }
        }
        await LoadNextPage();
        
        if (flpPersonelContainer != null)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    EnsureScrollbarVisible();
                }));
            }
            else
            {
                EnsureScrollbarVisible();
            }
        }
    }

    private void TxtSearch_Leave(object? sender, EventArgs e)
    {
        if (flpPersonelContainer != null)
        {
            EnsureScrollbarVisible();
        }
    }

    private void EnsureScrollbarVisible()
    {
        if (flpPersonelContainer == null)
            return;

        flpPersonelContainer.AutoScroll = true;
        flpPersonelContainer.HorizontalScroll.Enabled = false;
        flpPersonelContainer.HorizontalScroll.Visible = false;
        
        bool hasMoreContent = _currentPage * PageSize < _filteredUsers.Count;
        
        int contentHeight = 0;
        if (flpPersonelContainer.Controls.Count > 0)
        {
            int maxBottom = 0;
            foreach (Control control in flpPersonelContainer.Controls)
            {
                int bottom = control.Bottom + control.Margin.Bottom;
                if (bottom > maxBottom)
                    maxBottom = bottom;
            }
            contentHeight = maxBottom + flpPersonelContainer.Padding.Bottom;
        }
        
        int containerHeight = flpPersonelContainer.ClientSize.Height;
        bool contentExceedsContainer = contentHeight > containerHeight;
        
        if (flpPersonelContainer.Controls.Count > 0 && (contentExceedsContainer || hasMoreContent))
        {
            int requiredHeight = contentHeight;
            if (hasMoreContent)
            {
                int estimatedTotalItems = _filteredUsers.Count;
                int itemsPerRow = Math.Max(1, flpPersonelContainer.ClientSize.Width / (flpPersonelContainer.Controls.Count > 0 ? 
                    (flpPersonelContainer.Controls[0].Width + flpPersonelContainer.Controls[0].Margin.Left + flpPersonelContainer.Controls[0].Margin.Right) : 1));
                int estimatedRows = (int)Math.Ceiling((double)estimatedTotalItems / itemsPerRow);
                int estimatedHeight = estimatedRows * (flpPersonelContainer.Controls.Count > 0 ? 
                    (flpPersonelContainer.Controls[0].Height + flpPersonelContainer.Controls[0].Margin.Top + flpPersonelContainer.Controls[0].Margin.Bottom) : 100) 
                    + flpPersonelContainer.Padding.Top + flpPersonelContainer.Padding.Bottom;
                
                requiredHeight = Math.Max(requiredHeight, Math.Max(containerHeight + 1, estimatedHeight));
            }
            else
            {
                requiredHeight = Math.Max(requiredHeight, containerHeight + 1);
            }
            
            flpPersonelContainer.AutoScrollMinSize = new Size(0, requiredHeight);
        }
        else if (flpPersonelContainer.Controls.Count == 0)
        {
            flpPersonelContainer.AutoScrollMinSize = new Size(0, 0);
        }
        
        flpPersonelContainer.PerformLayout();
        flpPersonelContainer.Refresh();
        flpPersonelContainer.Invalidate();
        flpPersonelContainer.Update();
    }

    private void btnAddNewMember_Click(object sender, EventArgs e)
    {
        AddPersonelForm frm = new AddPersonelForm();
        frm.TopLevel = false;
        frm.FormBorderStyle = FormBorderStyle.None;
        frm.Dock = DockStyle.Fill;
        Panel? anaPanel = this.Parent as Panel;
        if (anaPanel != null)
        {
            anaPanel.Controls.Clear();
            anaPanel.Controls.Add(frm);
            frm.Show();
        }
    }
}