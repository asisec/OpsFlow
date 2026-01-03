namespace OpsFlow.UI.Forms.Management;

partial class LogoutForm
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        btnConfirmLogout = new Guna.UI2.WinForms.Guna2Button();
        btnCancel = new Guna.UI2.WinForms.Guna2Button();
        SuspendLayout();
        // 
        // guna2HtmlLabel1
        // 
        guna2HtmlLabel1.BackColor = Color.Transparent;
        guna2HtmlLabel1.Font = new Font("Poppins", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
        guna2HtmlLabel1.ForeColor = Color.White;
        guna2HtmlLabel1.Location = new Point(303, 56);
        guna2HtmlLabel1.Name = "guna2HtmlLabel1";
        guna2HtmlLabel1.Size = new Size(195, 72);
        guna2HtmlLabel1.TabIndex = 3;
        guna2HtmlLabel1.Text = "Çıkış Yap";
        // 
        // guna2HtmlLabel9
        // 
        guna2HtmlLabel9.BackColor = Color.Transparent;
        guna2HtmlLabel9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        guna2HtmlLabel9.ForeColor = Color.White;
        guna2HtmlLabel9.Location = new Point(143, 139);
        guna2HtmlLabel9.Name = "guna2HtmlLabel9";
        guna2HtmlLabel9.Size = new Size(514, 27);
        guna2HtmlLabel9.TabIndex = 30;
        guna2HtmlLabel9.Text = "Hesabınızdan çıkış yapmak istediğinize emin misiniz?";
        guna2HtmlLabel9.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // btnConfirmLogout
        // 
        btnConfirmLogout.BorderRadius = 12;
        btnConfirmLogout.CustomizableEdges = customizableEdges1;
        btnConfirmLogout.DisabledState.BorderColor = Color.DarkGray;
        btnConfirmLogout.DisabledState.CustomBorderColor = Color.DarkGray;
        btnConfirmLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnConfirmLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnConfirmLogout.FillColor = Color.FromArgb(211, 95, 95);
        btnConfirmLogout.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnConfirmLogout.ForeColor = Color.White;
        btnConfirmLogout.Location = new Point(143, 257);
        btnConfirmLogout.Name = "btnConfirmLogout";
        btnConfirmLogout.ShadowDecoration.CustomizableEdges = customizableEdges2;
        btnConfirmLogout.Size = new Size(221, 64);
        btnConfirmLogout.TabIndex = 31;
        btnConfirmLogout.Text = "Çıkış Yap";
        btnConfirmLogout.Click += btnConfirmLogout_Click;
        // 
        // btnCancel
        // 
        btnCancel.BorderRadius = 12;
        btnCancel.CustomizableEdges = customizableEdges3;
        btnCancel.DisabledState.BorderColor = Color.DarkGray;
        btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
        btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnCancel.FillColor = Color.FromArgb(149, 165, 166);
        btnCancel.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(436, 257);
        btnCancel.Name = "btnCancel";
        btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
        btnCancel.Size = new Size(221, 64);
        btnCancel.TabIndex = 32;
        btnCancel.Text = "İptal";
        btnCancel.Click += btnCancel_Click;
        // 
        // LogoutForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(26, 31, 46);
        ClientSize = new Size(800, 376);
        Controls.Add(btnCancel);
        Controls.Add(btnConfirmLogout);
        Controls.Add(guna2HtmlLabel9);
        Controls.Add(guna2HtmlLabel1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "LogoutForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LogoutForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
    private Guna.UI2.WinForms.Guna2Button btnConfirmLogout;
    private Guna.UI2.WinForms.Guna2Button btnCancel;
}