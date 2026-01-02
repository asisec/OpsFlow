namespace OpsFlow.UI.Forms.Management;

partial class PersonelCard
{
    /// <summary> 
    ///Gerekli tasarımcı değişkeni.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    ///Kullanılan tüm kaynakları temizleyin.
    /// </summary>
    ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Bileşen Tasarımcısı üretimi kod

    /// <summary> 
    /// Tasarımcı desteği için gerekli metot - bu metodun 
    ///içeriğini kod düzenleyici ile değiştirmeyin.
    /// </summary>
    private void InitializeComponent()
    {
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        PictureBox = new Guna.UI2.WinForms.Guna2CirclePictureBox();
        lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
        btnRoleBadge = new Guna.UI2.WinForms.Guna2Button();
        lblRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
        btnProfile = new Guna.UI2.WinForms.Guna2Button();
        lblTask = new Guna.UI2.WinForms.Guna2HtmlLabel();
        guna2Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
        SuspendLayout();
        // 
        // guna2Panel1
        // 
        guna2Panel1.BorderRadius = 15;
        guna2Panel1.Controls.Add(lblTask);
        guna2Panel1.Controls.Add(btnProfile);
        guna2Panel1.Controls.Add(lblRole);
        guna2Panel1.Controls.Add(btnRoleBadge);
        guna2Panel1.Controls.Add(lblName);
        guna2Panel1.Controls.Add(PictureBox);
        guna2Panel1.CustomizableEdges = customizableEdges13;
        guna2Panel1.FillColor = Color.FromArgb(26, 31, 46);
        guna2Panel1.Location = new Point(0, 0);
        guna2Panel1.Name = "guna2Panel1";
        guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges14;
        guna2Panel1.Size = new Size(321, 184);
        guna2Panel1.TabIndex = 0;
        // 
        // PictureBox
        // 
        PictureBox.FillColor = Color.Black;
        PictureBox.ImageRotate = 0F;
        PictureBox.Location = new Point(3, 3);
        PictureBox.Name = "PictureBox";
        PictureBox.ShadowDecoration.CustomizableEdges = customizableEdges12;
        PictureBox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        PictureBox.Size = new Size(93, 93);
        PictureBox.TabIndex = 0;
        PictureBox.TabStop = false;
        // 
        // lblName
        // 
        lblName.BackColor = Color.Transparent;
        lblName.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        lblName.ForeColor = Color.White;
        lblName.Location = new Point(102, 18);
        lblName.Name = "lblName";
        lblName.Size = new Size(65, 38);
        lblName.TabIndex = 1;
        lblName.Text = "Name";
        // 
        // btnRoleBadge
        // 
        btnRoleBadge.BorderRadius = 10;
        btnRoleBadge.CustomizableEdges = customizableEdges10;
        btnRoleBadge.DisabledState.BorderColor = Color.DarkGray;
        btnRoleBadge.DisabledState.CustomBorderColor = Color.DarkGray;
        btnRoleBadge.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnRoleBadge.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnRoleBadge.FillColor = Color.FromArgb(108, 92, 231);
        btnRoleBadge.Font = new Font("Poppins", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnRoleBadge.ForeColor = Color.White;
        btnRoleBadge.Location = new Point(102, 62);
        btnRoleBadge.Name = "btnRoleBadge";
        btnRoleBadge.ShadowDecoration.CustomizableEdges = customizableEdges11;
        btnRoleBadge.Size = new Size(109, 30);
        btnRoleBadge.TabIndex = 2;
        btnRoleBadge.Text = "Role";
        // 
        // lblRole
        // 
        lblRole.BackColor = Color.Transparent;
        lblRole.Font = new Font("Poppins", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
        lblRole.ForeColor = Color.White;
        lblRole.Location = new Point(102, 98);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(30, 25);
        lblRole.TabIndex = 3;
        lblRole.Text = "Role";
        // 
        // btnProfile
        // 
        btnProfile.BackColor = Color.Transparent;
        btnProfile.BorderColor = Color.FromArgb(69, 90, 100);
        btnProfile.BorderRadius = 8;
        btnProfile.BorderThickness = 1;
        btnProfile.CustomizableEdges = customizableEdges8;
        btnProfile.DisabledState.BorderColor = Color.DarkGray;
        btnProfile.DisabledState.CustomBorderColor = Color.DarkGray;
        btnProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnProfile.FillColor = Color.FromArgb(48, 48, 61);
        btnProfile.Font = new Font("Poppins", 6F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnProfile.ForeColor = Color.White;
        btnProfile.Location = new Point(201, 140);
        btnProfile.Name = "btnProfile";
        btnProfile.ShadowDecoration.CustomizableEdges = customizableEdges9;
        btnProfile.Size = new Size(117, 41);
        btnProfile.TabIndex = 4;
        btnProfile.Text = "Profili Görüntüle";
        // 
        // lblTask
        // 
        lblTask.BackColor = Color.Transparent;
        lblTask.ForeColor = Color.White;
        lblTask.Location = new Point(246, 112);
        lblTask.Name = "lblTask";
        lblTask.Size = new Size(32, 22);
        lblTask.TabIndex = 5;
        lblTask.Text = "Task";
        // 
        // PersonelCard
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Transparent;
        Controls.Add(guna2Panel1);
        Name = "PersonelCard";
        Size = new Size(323, 185);
        guna2Panel1.ResumeLayout(false);
        guna2Panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    private Guna.UI2.WinForms.Guna2CirclePictureBox PictureBox;
    private Guna.UI2.WinForms.Guna2Button btnRoleBadge;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblRole;
    private Guna.UI2.WinForms.Guna2Button btnProfile;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblTask;
}
