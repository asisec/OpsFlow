namespace OpsFlow.UI.Forms.Management;

partial class PersonelListForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelListForm));
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
        txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
        btnAddNewMember = new Guna.UI2.WinForms.Guna2Button();
        cmbFilterStatus = new Guna.UI2.WinForms.Guna2ComboBox();
        guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
        txtDep = new Guna.UI2.WinForms.Guna2HtmlLabel();
        guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        cmbFilterRole = new Guna.UI2.WinForms.Guna2ComboBox();
        guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
        txtActivePersonel = new Guna.UI2.WinForms.Guna2HtmlLabel();
        guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        cmbFilterDept = new Guna.UI2.WinForms.Guna2ComboBox();
        guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        txtPersonel = new Guna.UI2.WinForms.Guna2HtmlLabel();
        guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        flpPersonelContainer = new FlowLayoutPanel();
        pnlHeader.SuspendLayout();
        guna2Panel3.SuspendLayout();
        guna2Panel2.SuspendLayout();
        guna2Panel1.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.Controls.Add(txtSearch);
        pnlHeader.Controls.Add(btnAddNewMember);
        pnlHeader.Controls.Add(cmbFilterStatus);
        pnlHeader.Controls.Add(guna2Panel3);
        pnlHeader.Controls.Add(cmbFilterRole);
        pnlHeader.Controls.Add(guna2Panel2);
        pnlHeader.Controls.Add(cmbFilterDept);
        pnlHeader.Controls.Add(guna2Panel1);
        pnlHeader.CustomizableEdges = customizableEdges17;
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges18;
        pnlHeader.Size = new Size(1382, 297);
        pnlHeader.TabIndex = 0;
        pnlHeader.Paint += pnlHeader_Paint;
        // 
        // txtSearch
        // 
        txtSearch.BorderColor = Color.DarkGray;
        txtSearch.BorderRadius = 10;
        txtSearch.CustomizableEdges = customizableEdges1;
        txtSearch.DefaultText = "Personel ara...";
        txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        txtSearch.FillColor = Color.FromArgb(42, 45, 62);
        txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        txtSearch.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
        txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        txtSearch.IconLeft = (Image)resources.GetObject("txtSearch.IconLeft");
        txtSearch.IconLeftOffset = new Point(10, 0);
        txtSearch.Location = new Point(1049, 220);
        txtSearch.Margin = new Padding(3, 5, 3, 5);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "";
        txtSearch.SelectedText = "";
        txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
        txtSearch.Size = new Size(227, 52);
        txtSearch.TabIndex = 39;
        // 
        // btnAddNewMember
        // 
        btnAddNewMember.BorderRadius = 12;
        btnAddNewMember.CustomizableEdges = customizableEdges3;
        btnAddNewMember.DisabledState.BorderColor = Color.DarkGray;
        btnAddNewMember.DisabledState.CustomBorderColor = Color.DarkGray;
        btnAddNewMember.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnAddNewMember.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnAddNewMember.FillColor = Color.FromArgb(46, 74, 98);
        btnAddNewMember.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnAddNewMember.ForeColor = Color.White;
        btnAddNewMember.Location = new Point(1049, 69);
        btnAddNewMember.Name = "btnAddNewMember";
        btnAddNewMember.ShadowDecoration.CustomizableEdges = customizableEdges4;
        btnAddNewMember.Size = new Size(193, 64);
        btnAddNewMember.TabIndex = 15;
        btnAddNewMember.Text = "+  Yeni Üye Ekle";
        btnAddNewMember.Click += btnAddNewMember_Click;
        // 
        // cmbFilterStatus
        // 
        cmbFilterStatus.BackColor = Color.Transparent;
        cmbFilterStatus.BorderColor = Color.FromArgb(45, 55, 72);
        cmbFilterStatus.BorderRadius = 10;
        cmbFilterStatus.BorderThickness = 2;
        cmbFilterStatus.CustomizableEdges = customizableEdges5;
        cmbFilterStatus.DrawMode = DrawMode.OwnerDrawFixed;
        cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbFilterStatus.FillColor = Color.FromArgb(26, 31, 46);
        cmbFilterStatus.FocusedColor = Color.FromArgb(94, 148, 255);
        cmbFilterStatus.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        cmbFilterStatus.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
        cmbFilterStatus.ForeColor = Color.White;
        cmbFilterStatus.ItemHeight = 30;
        cmbFilterStatus.Location = new Point(640, 255);
        cmbFilterStatus.Name = "cmbFilterStatus";
        cmbFilterStatus.ShadowDecoration.CustomizableEdges = customizableEdges6;
        cmbFilterStatus.Size = new Size(230, 36);
        cmbFilterStatus.TabIndex = 38;
        // 
        // guna2Panel3
        // 
        guna2Panel3.BorderRadius = 15;
        guna2Panel3.Controls.Add(txtDep);
        guna2Panel3.Controls.Add(guna2HtmlLabel4);
        guna2Panel3.CustomizableEdges = customizableEdges7;
        guna2Panel3.FillColor = Color.FromArgb(26, 31, 46);
        guna2Panel3.Location = new Point(721, 37);
        guna2Panel3.Name = "guna2Panel3";
        guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges8;
        guna2Panel3.Size = new Size(260, 194);
        guna2Panel3.TabIndex = 2;
        // 
        // txtDep
        // 
        txtDep.BackColor = Color.Transparent;
        txtDep.Font = new Font("Poppins", 28.2F, FontStyle.Bold);
        txtDep.ForeColor = Color.White;
        txtDep.Location = new Point(8, 12);
        txtDep.Name = "txtDep";
        txtDep.Size = new Size(34, 84);
        txtDep.TabIndex = 2;
        txtDep.Text = "0";
        // 
        // guna2HtmlLabel4
        // 
        guna2HtmlLabel4.BackColor = Color.Transparent;
        guna2HtmlLabel4.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        guna2HtmlLabel4.ForeColor = Color.White;
        guna2HtmlLabel4.Location = new Point(3, 153);
        guna2HtmlLabel4.Name = "guna2HtmlLabel4";
        guna2HtmlLabel4.Size = new Size(121, 38);
        guna2HtmlLabel4.TabIndex = 0;
        guna2HtmlLabel4.Text = "Depertman";
        // 
        // cmbFilterRole
        // 
        cmbFilterRole.BackColor = Color.Transparent;
        cmbFilterRole.BorderColor = Color.FromArgb(45, 55, 72);
        cmbFilterRole.BorderRadius = 10;
        cmbFilterRole.BorderThickness = 2;
        cmbFilterRole.CustomizableEdges = customizableEdges9;
        cmbFilterRole.DrawMode = DrawMode.OwnerDrawFixed;
        cmbFilterRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbFilterRole.FillColor = Color.FromArgb(26, 31, 46);
        cmbFilterRole.FocusedColor = Color.FromArgb(94, 148, 255);
        cmbFilterRole.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        cmbFilterRole.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
        cmbFilterRole.ForeColor = Color.White;
        cmbFilterRole.ItemHeight = 30;
        cmbFilterRole.Location = new Point(345, 255);
        cmbFilterRole.Name = "cmbFilterRole";
        cmbFilterRole.ShadowDecoration.CustomizableEdges = customizableEdges10;
        cmbFilterRole.Size = new Size(230, 36);
        cmbFilterRole.TabIndex = 37;
        // 
        // guna2Panel2
        // 
        guna2Panel2.BorderRadius = 15;
        guna2Panel2.Controls.Add(txtActivePersonel);
        guna2Panel2.Controls.Add(guna2HtmlLabel3);
        guna2Panel2.CustomizableEdges = customizableEdges11;
        guna2Panel2.FillColor = Color.FromArgb(26, 31, 46);
        guna2Panel2.Location = new Point(387, 37);
        guna2Panel2.Name = "guna2Panel2";
        guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges12;
        guna2Panel2.Size = new Size(275, 194);
        guna2Panel2.TabIndex = 1;
        // 
        // txtActivePersonel
        // 
        txtActivePersonel.BackColor = Color.Transparent;
        txtActivePersonel.Font = new Font("Poppins", 28.2F, FontStyle.Bold);
        txtActivePersonel.ForeColor = Color.White;
        txtActivePersonel.Location = new Point(8, 12);
        txtActivePersonel.Name = "txtActivePersonel";
        txtActivePersonel.Size = new Size(34, 84);
        txtActivePersonel.TabIndex = 2;
        txtActivePersonel.Text = "0";
        // 
        // guna2HtmlLabel3
        // 
        guna2HtmlLabel3.BackColor = Color.Transparent;
        guna2HtmlLabel3.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        guna2HtmlLabel3.ForeColor = Color.White;
        guna2HtmlLabel3.Location = new Point(3, 153);
        guna2HtmlLabel3.Name = "guna2HtmlLabel3";
        guna2HtmlLabel3.Size = new Size(143, 38);
        guna2HtmlLabel3.TabIndex = 0;
        guna2HtmlLabel3.Text = "Aktif Personel";
        guna2HtmlLabel3.Click += guna2HtmlLabel3_Click;
        // 
        // cmbFilterDept
        // 
        cmbFilterDept.BackColor = Color.Transparent;
        cmbFilterDept.BorderColor = Color.FromArgb(45, 55, 72);
        cmbFilterDept.BorderRadius = 10;
        cmbFilterDept.BorderThickness = 2;
        cmbFilterDept.CustomizableEdges = customizableEdges13;
        cmbFilterDept.DrawMode = DrawMode.OwnerDrawFixed;
        cmbFilterDept.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbFilterDept.FillColor = Color.FromArgb(26, 31, 46);
        cmbFilterDept.FocusedColor = Color.FromArgb(94, 148, 255);
        cmbFilterDept.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        cmbFilterDept.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
        cmbFilterDept.ForeColor = Color.White;
        cmbFilterDept.ItemHeight = 30;
        cmbFilterDept.Location = new Point(50, 255);
        cmbFilterDept.Name = "cmbFilterDept";
        cmbFilterDept.ShadowDecoration.CustomizableEdges = customizableEdges14;
        cmbFilterDept.Size = new Size(230, 36);
        cmbFilterDept.TabIndex = 36;
        // 
        // guna2Panel1
        // 
        guna2Panel1.BorderRadius = 15;
        guna2Panel1.Controls.Add(txtPersonel);
        guna2Panel1.Controls.Add(guna2HtmlLabel2);
        guna2Panel1.CustomizableEdges = customizableEdges15;
        guna2Panel1.FillColor = Color.FromArgb(26, 31, 46);
        guna2Panel1.Location = new Point(53, 37);
        guna2Panel1.Name = "guna2Panel1";
        guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges16;
        guna2Panel1.Size = new Size(275, 194);
        guna2Panel1.TabIndex = 0;
        // 
        // txtPersonel
        // 
        txtPersonel.BackColor = Color.Transparent;
        txtPersonel.Font = new Font("Poppins", 28.2F, FontStyle.Bold);
        txtPersonel.ForeColor = Color.White;
        txtPersonel.Location = new Point(8, 12);
        txtPersonel.Name = "txtPersonel";
        txtPersonel.Size = new Size(34, 84);
        txtPersonel.TabIndex = 1;
        txtPersonel.Text = "0";
        // 
        // guna2HtmlLabel2
        // 
        guna2HtmlLabel2.BackColor = Color.Transparent;
        guna2HtmlLabel2.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        guna2HtmlLabel2.ForeColor = Color.White;
        guna2HtmlLabel2.Location = new Point(3, 153);
        guna2HtmlLabel2.Name = "guna2HtmlLabel2";
        guna2HtmlLabel2.Size = new Size(175, 38);
        guna2HtmlLabel2.TabIndex = 0;
        guna2HtmlLabel2.Text = "Toplam Personel";
        // 
        // flpPersonelContainer
        // 
        flpPersonelContainer.AutoScroll = true;
        flpPersonelContainer.Dock = DockStyle.Fill;
        flpPersonelContainer.Location = new Point(0, 297);
        flpPersonelContainer.Name = "flpPersonelContainer";
        flpPersonelContainer.Padding = new Padding(20, 10, 0, 0);
        flpPersonelContainer.Size = new Size(1382, 494);
        flpPersonelContainer.TabIndex = 1;
        // 
        // PersonelListForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(17, 19, 25);
        ClientSize = new Size(1382, 791);
        Controls.Add(flpPersonelContainer);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.None;
        Name = "PersonelListForm";
        Text = "PersonelListForm";
        pnlHeader.ResumeLayout(false);
        guna2Panel3.ResumeLayout(false);
        guna2Panel3.PerformLayout();
        guna2Panel2.ResumeLayout(false);
        guna2Panel2.PerformLayout();
        guna2Panel1.ResumeLayout(false);
        guna2Panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Guna.UI2.WinForms.Guna2Panel pnlHeader;
    private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
    private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
    private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    private Guna.UI2.WinForms.Guna2HtmlLabel txtDep;
    private Guna.UI2.WinForms.Guna2HtmlLabel txtActivePersonel;
    private Guna.UI2.WinForms.Guna2HtmlLabel txtPersonel;
    private Guna.UI2.WinForms.Guna2ComboBox cmbFilterDept;
    private Guna.UI2.WinForms.Guna2ComboBox cmbFilterRole;
    private Guna.UI2.WinForms.Guna2ComboBox cmbFilterStatus;
    private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    private Guna.UI2.WinForms.Guna2Button btnAddNewMember;
    private FlowLayoutPanel flpPersonelContainer;
}