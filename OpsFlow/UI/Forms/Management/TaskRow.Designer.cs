namespace OpsFlow.UI.Forms.Management;

partial class TaskRow
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        txtTaskName = new Guna.UI2.WinForms.Guna2HtmlLabel();
        PictureBox = new Guna.UI2.WinForms.Guna2CirclePictureBox();
        txtPersonName = new Guna.UI2.WinForms.Guna2HtmlLabel();
        txtDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
        btnPriority = new Guna.UI2.WinForms.Guna2Button();
        btnSituation = new Guna.UI2.WinForms.Guna2Button();
        ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
        SuspendLayout();
        // 
        // txtTaskName
        // 
        txtTaskName.BackColor = Color.Transparent;
        txtTaskName.Font = new Font("Poppins", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        txtTaskName.ForeColor = Color.White;
        txtTaskName.Location = new Point(20, 19);
        txtTaskName.Name = "txtTaskName";
        txtTaskName.Size = new Size(89, 32);
        txtTaskName.TabIndex = 2;
        txtTaskName.Text = "Görev Adı";
        // 
        // PictureBox
        // 
        PictureBox.FillColor = Color.Black;
        PictureBox.ImageRotate = 0F;
        PictureBox.Location = new Point(253, 3);
        PictureBox.Name = "PictureBox";
        PictureBox.ShadowDecoration.CustomizableEdges = customizableEdges1;
        PictureBox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        PictureBox.Size = new Size(64, 64);
        PictureBox.TabIndex = 3;
        PictureBox.TabStop = false;
        // 
        // txtPersonName
        // 
        txtPersonName.BackColor = Color.Transparent;
        txtPersonName.Font = new Font("Poppins", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        txtPersonName.ForeColor = Color.White;
        txtPersonName.Location = new Point(323, 19);
        txtPersonName.Name = "txtPersonName";
        txtPersonName.Size = new Size(111, 32);
        txtPersonName.TabIndex = 4;
        txtPersonName.Text = "Personel Adı";
        // 
        // txtDate
        // 
        txtDate.BackColor = Color.Transparent;
        txtDate.Font = new Font("Poppins", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
        txtDate.ForeColor = Color.White;
        txtDate.Location = new Point(607, 19);
        txtDate.Name = "txtDate";
        txtDate.Size = new Size(94, 32);
        txtDate.TabIndex = 5;
        txtDate.Text = "01.03.2005";
        // 
        // btnPriority
        // 
        btnPriority.BorderRadius = 5;
        btnPriority.CustomizableEdges = customizableEdges2;
        btnPriority.DisabledState.BorderColor = Color.DarkGray;
        btnPriority.DisabledState.CustomBorderColor = Color.DarkGray;
        btnPriority.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnPriority.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnPriority.Enabled = false;
        btnPriority.FillColor = Color.FromArgb(229, 57, 53);
        btnPriority.Font = new Font("Poppins", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnPriority.ForeColor = Color.White;
        btnPriority.Location = new Point(897, 19);
        btnPriority.Name = "btnPriority";
        btnPriority.ShadowDecoration.CustomizableEdges = customizableEdges3;
        btnPriority.Size = new Size(109, 30);
        btnPriority.TabIndex = 6;
        btnPriority.Text = "Yüksek";
        // 
        // btnSituation
        // 
        btnSituation.BorderRadius = 5;
        btnSituation.CustomizableEdges = customizableEdges4;
        btnSituation.DisabledState.BorderColor = Color.DarkGray;
        btnSituation.DisabledState.CustomBorderColor = Color.DarkGray;
        btnSituation.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnSituation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnSituation.Enabled = false;
        btnSituation.FillColor = Color.FromArgb(108, 92, 231);
        btnSituation.Font = new Font("Poppins", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnSituation.ForeColor = Color.White;
        btnSituation.Location = new Point(1193, 21);
        btnSituation.Name = "btnSituation";
        btnSituation.ShadowDecoration.CustomizableEdges = customizableEdges5;
        btnSituation.Size = new Size(109, 30);
        btnSituation.TabIndex = 7;
        btnSituation.Text = "Aktif";
        // 
        // TaskRow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(16, 18, 24);
        Controls.Add(btnSituation);
        Controls.Add(btnPriority);
        Controls.Add(txtDate);
        Controls.Add(txtPersonName);
        Controls.Add(PictureBox);
        Controls.Add(txtTaskName);
        Name = "TaskRow";
        Size = new Size(1382, 70);
        ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Guna.UI2.WinForms.Guna2HtmlLabel txtTaskName;
    private Guna.UI2.WinForms.Guna2CirclePictureBox PictureBox;
    private Guna.UI2.WinForms.Guna2HtmlLabel txtPersonName;
    private Guna.UI2.WinForms.Guna2HtmlLabel txtDate;
    private Guna.UI2.WinForms.Guna2Button btnPriority;
    private Guna.UI2.WinForms.Guna2Button btnSituation;
}
