namespace OpsFlow.UI.Forms.Management;

partial class ProfileControl
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        PictureBox = new Guna.UI2.WinForms.Guna2CirclePictureBox();
        btnAddPhoto = new Guna.UI2.WinForms.Guna2Button();
        txtName = new Guna.UI2.WinForms.Guna2TextBox();
        txtSurname = new Guna.UI2.WinForms.Guna2TextBox();
        label3 = new Label();
        label1 = new Label();
        txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
        label2 = new Label();
        txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
        label4 = new Label();
        ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
        SuspendLayout();
        // 
        // PictureBox
        // 
        PictureBox.FillColor = Color.Black;
        PictureBox.ImageRotate = 0F;
        PictureBox.Location = new Point(322, 26);
        PictureBox.Name = "PictureBox";
        PictureBox.ShadowDecoration.CustomizableEdges = customizableEdges12;
        PictureBox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        PictureBox.Size = new Size(256, 256);
        PictureBox.TabIndex = 1;
        PictureBox.TabStop = false;
        // 
        // btnAddPhoto
        // 
        btnAddPhoto.BorderColor = Color.FromArgb(45, 55, 72);
        btnAddPhoto.BorderRadius = 10;
        btnAddPhoto.BorderThickness = 2;
        btnAddPhoto.CustomizableEdges = customizableEdges13;
        btnAddPhoto.DisabledState.BorderColor = Color.DarkGray;
        btnAddPhoto.DisabledState.CustomBorderColor = Color.DarkGray;
        btnAddPhoto.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnAddPhoto.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnAddPhoto.FillColor = Color.FromArgb(142, 68, 173);
        btnAddPhoto.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
        btnAddPhoto.ForeColor = Color.White;
        btnAddPhoto.Location = new Point(360, 299);
        btnAddPhoto.Name = "btnAddPhoto";
        btnAddPhoto.ShadowDecoration.CustomizableEdges = customizableEdges14;
        btnAddPhoto.Size = new Size(180, 43);
        btnAddPhoto.TabIndex = 27;
        btnAddPhoto.Text = "Fotoğrafı Değiştir";
        // 
        // txtName
        // 
        txtName.BorderColor = Color.WhiteSmoke;
        txtName.BorderRadius = 10;
        txtName.BorderThickness = 2;
        txtName.CustomizableEdges = customizableEdges15;
        txtName.DefaultText = "";
        txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        txtName.FillColor = Color.FromArgb(26, 31, 46);
        txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        txtName.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
        txtName.ForeColor = Color.White;
        txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        txtName.Location = new Point(230, 385);
        txtName.Margin = new Padding(3, 5, 3, 5);
        txtName.Name = "txtName";
        txtName.PlaceholderText = "";
        txtName.SelectedText = "";
        txtName.ShadowDecoration.CustomizableEdges = customizableEdges16;
        txtName.Size = new Size(189, 41);
        txtName.TabIndex = 28;
        txtName.TextChanged += txtName_TextChanged;
        // 
        // txtSurname
        // 
        txtSurname.BorderColor = Color.WhiteSmoke;
        txtSurname.BorderRadius = 10;
        txtSurname.BorderThickness = 2;
        txtSurname.CustomizableEdges = customizableEdges17;
        txtSurname.DefaultText = "";
        txtSurname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        txtSurname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        txtSurname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        txtSurname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        txtSurname.FillColor = Color.FromArgb(26, 31, 46);
        txtSurname.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        txtSurname.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
        txtSurname.ForeColor = Color.White;
        txtSurname.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        txtSurname.Location = new Point(482, 385);
        txtSurname.Margin = new Padding(3, 5, 3, 5);
        txtSurname.Name = "txtSurname";
        txtSurname.PlaceholderText = "";
        txtSurname.SelectedText = "";
        txtSurname.ShadowDecoration.CustomizableEdges = customizableEdges18;
        txtSurname.Size = new Size(189, 41);
        txtSurname.TabIndex = 29;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
        label3.ForeColor = Color.White;
        label3.Location = new Point(241, 358);
        label3.Name = "label3";
        label3.Size = new Size(34, 26);
        label3.TabIndex = 30;
        label3.Text = "Ad";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
        label1.ForeColor = Color.White;
        label1.Location = new Point(491, 358);
        label1.Name = "label1";
        label1.Size = new Size(65, 26);
        label1.TabIndex = 31;
        label1.Text = "Soyad";
        // 
        // txtEmail
        // 
        txtEmail.BorderColor = Color.WhiteSmoke;
        txtEmail.BorderRadius = 10;
        txtEmail.BorderThickness = 2;
        txtEmail.CustomizableEdges = customizableEdges19;
        txtEmail.DefaultText = "";
        txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        txtEmail.FillColor = Color.FromArgb(26, 31, 46);
        txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        txtEmail.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
        txtEmail.ForeColor = Color.White;
        txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        txtEmail.Location = new Point(269, 464);
        txtEmail.Margin = new Padding(3, 5, 3, 5);
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "";
        txtEmail.SelectedText = "";
        txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges20;
        txtEmail.Size = new Size(346, 41);
        txtEmail.TabIndex = 32;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
        label2.ForeColor = Color.White;
        label2.Location = new Point(280, 436);
        label2.Name = "label2";
        label2.Size = new Size(80, 26);
        label2.TabIndex = 33;
        label2.Text = "E-posta";
        // 
        // txtPhone
        // 
        txtPhone.BorderColor = Color.WhiteSmoke;
        txtPhone.BorderRadius = 10;
        txtPhone.BorderThickness = 2;
        txtPhone.CustomizableEdges = customizableEdges21;
        txtPhone.DefaultText = "";
        txtPhone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
        txtPhone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
        txtPhone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
        txtPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
        txtPhone.FillColor = Color.FromArgb(26, 31, 46);
        txtPhone.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
        txtPhone.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
        txtPhone.ForeColor = Color.White;
        txtPhone.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
        txtPhone.Location = new Point(269, 546);
        txtPhone.Margin = new Padding(3, 5, 3, 5);
        txtPhone.Name = "txtPhone";
        txtPhone.PlaceholderText = "";
        txtPhone.SelectedText = "";
        txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges22;
        txtPhone.Size = new Size(346, 41);
        txtPhone.TabIndex = 34;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Poppins Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
        label4.ForeColor = Color.White;
        label4.Location = new Point(280, 515);
        label4.Name = "label4";
        label4.Size = new Size(102, 26);
        label4.TabIndex = 35;
        label4.Text = "Telefon No";
        // 
        // ProfileControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(16, 18, 24);
        Controls.Add(label4);
        Controls.Add(txtPhone);
        Controls.Add(label2);
        Controls.Add(txtEmail);
        Controls.Add(label1);
        Controls.Add(label3);
        Controls.Add(txtSurname);
        Controls.Add(txtName);
        Controls.Add(btnAddPhoto);
        Controls.Add(PictureBox);
        Name = "ProfileControl";
        Size = new Size(900, 700);
        ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Guna.UI2.WinForms.Guna2CirclePictureBox PictureBox;
    private Guna.UI2.WinForms.Guna2Button btnAddPhoto;
    private Guna.UI2.WinForms.Guna2TextBox txtName;
    private Guna.UI2.WinForms.Guna2TextBox txtSurname;
    private Label label3;
    private Label label1;
    private Guna.UI2.WinForms.Guna2TextBox txtEmail;
    private Label label2;
    private Guna.UI2.WinForms.Guna2TextBox txtPhone;
    private Label label4;
}
