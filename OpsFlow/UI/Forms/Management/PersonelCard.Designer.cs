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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelCard));
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
        pictureBox2 = new PictureBox();
        pictureBox1 = new PictureBox();
        lblTask = new Guna.UI2.WinForms.Guna2HtmlLabel();
        btnViewProfile = new Guna.UI2.WinForms.Guna2Button();
        btnRoleBadge = new Guna.UI2.WinForms.Guna2Button();
        lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
        PictureBox = new Guna.UI2.WinForms.Guna2CirclePictureBox();
        lblRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
        guna2Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
        SuspendLayout();
        // 
        // guna2Panel1
        // 
        guna2Panel1.BorderRadius = 15;
        guna2Panel1.Controls.Add(pictureBox2);
        guna2Panel1.Controls.Add(pictureBox1);
        guna2Panel1.Controls.Add(lblTask);
        guna2Panel1.Controls.Add(btnViewProfile);
        guna2Panel1.Controls.Add(lblRole);
        guna2Panel1.Controls.Add(btnRoleBadge);
        guna2Panel1.Controls.Add(lblName);
        guna2Panel1.Controls.Add(PictureBox);
        guna2Panel1.CustomizableEdges = customizableEdges6;
        guna2Panel1.FillColor = Color.FromArgb(26, 31, 46);
        guna2Panel1.Location = new Point(0, 0);
        guna2Panel1.Name = "guna2Panel1";
        guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges7;
        guna2Panel1.Size = new Size(321, 184);
        guna2Panel1.TabIndex = 0;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
        pictureBox2.Location = new Point(19, 148);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(30, 33);
        pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
        pictureBox2.TabIndex = 6;
        pictureBox2.TabStop = false;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(55, 148);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(31, 33);
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;
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
        // btnViewProfile
        // 
        btnViewProfile.BackColor = Color.Transparent;
        btnViewProfile.BorderColor = Color.FromArgb(69, 90, 100);
        btnViewProfile.BorderRadius = 8;
        btnViewProfile.BorderThickness = 1;
        btnViewProfile.CustomizableEdges = customizableEdges1;
        btnViewProfile.DisabledState.BorderColor = Color.DarkGray;
        btnViewProfile.DisabledState.CustomBorderColor = Color.DarkGray;
        btnViewProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnViewProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnViewProfile.FillColor = Color.FromArgb(48, 48, 61);
        btnViewProfile.Font = new Font("Poppins", 6F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnViewProfile.ForeColor = Color.White;
        btnViewProfile.Location = new Point(201, 140);
        btnViewProfile.Name = "btnViewProfile";
        btnViewProfile.ShadowDecoration.CustomizableEdges = customizableEdges2;
        btnViewProfile.Size = new Size(117, 41);
        btnViewProfile.TabIndex = 4;
        btnViewProfile.Text = "Profili Görüntüle";
        btnViewProfile.Click += btnViewProfile_Click;
        // 
        // btnRoleBadge
        // 
        btnRoleBadge.BorderRadius = 10;
        btnRoleBadge.CustomizableEdges = customizableEdges3;
        btnRoleBadge.DisabledState.BorderColor = Color.DarkGray;
        btnRoleBadge.DisabledState.CustomBorderColor = Color.DarkGray;
        btnRoleBadge.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnRoleBadge.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnRoleBadge.FillColor = Color.FromArgb(108, 92, 231);
        btnRoleBadge.Font = new Font("Poppins", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnRoleBadge.ForeColor = Color.White;
        btnRoleBadge.Location = new Point(102, 62);
        btnRoleBadge.Name = "btnRoleBadge";
        btnRoleBadge.ShadowDecoration.CustomizableEdges = customizableEdges4;
        btnRoleBadge.Size = new Size(109, 30);
        btnRoleBadge.TabIndex = 2;
        btnRoleBadge.Text = "Role";
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
        // PictureBox
        // 
        PictureBox.FillColor = Color.Black;
        PictureBox.ImageRotate = 0F;
        PictureBox.Location = new Point(3, 3);
        PictureBox.Name = "PictureBox";
        PictureBox.ShadowDecoration.CustomizableEdges = customizableEdges5;
        PictureBox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        PictureBox.Size = new Size(93, 93);
        PictureBox.TabIndex = 0;
        PictureBox.TabStop = false;
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
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    private Guna.UI2.WinForms.Guna2CirclePictureBox PictureBox;
    private Guna.UI2.WinForms.Guna2Button btnRoleBadge;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
    private Guna.UI2.WinForms.Guna2Button btnViewProfile;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblTask;
    private PictureBox pictureBox2;
    private PictureBox pictureBox1;
    private Guna.UI2.WinForms.Guna2HtmlLabel lblRole;
}
