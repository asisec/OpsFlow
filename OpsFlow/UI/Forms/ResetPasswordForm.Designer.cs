namespace OpsFlow.UI.Forms
{
    partial class ResetPasswordForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPasswordForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            btnSavePassword = new Guna.UI2.WinForms.Guna2Button();
            lnkBackToLogin = new LinkLabel();
            pnlSuccessToast = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnCloseError = new Guna.UI2.WinForms.Guna2Button();
            lblSuccessTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblSuccessMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            tmrAutoClose = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            pnlSuccessToast.SuspendLayout();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(24, 48);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(238, 75);
            guna2PictureBox1.TabIndex = 4;
            guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 28.2F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(399, 165);
            label1.Name = "label1";
            label1.Size = new Size(406, 54);
            label1.TabIndex = 5;
            label1.Text = "Yeni Şifre Oluştur";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11F);
            label2.ForeColor = Color.FromArgb(156, 163, 175);
            label2.Location = new Point(419, 240);
            label2.Name = "label2";
            label2.Size = new Size(359, 24);
            label2.TabIndex = 6;
            label2.Text = "Yeni girilen şifre en az 8 karakter olmalıdır.";
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(45, 50, 62);
            txtPassword.BorderRadius = 18;
            txtPassword.BorderThickness = 4;
            txtPassword.CustomizableEdges = customizableEdges3;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(26, 29, 38);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Poppins", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(397, 285);
            txtPassword.Margin = new Padding(6, 12, 6, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Yeni Şifre";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(411, 61);
            txtPassword.TabIndex = 7;
            txtPassword.TextOffset = new Point(6, 0);
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderColor = Color.FromArgb(45, 50, 62);
            guna2TextBox1.BorderRadius = 18;
            guna2TextBox1.BorderThickness = 4;
            guna2TextBox1.CustomizableEdges = customizableEdges5;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FillColor = Color.FromArgb(26, 29, 38);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Poppins", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(399, 367);
            guna2TextBox1.Margin = new Padding(6, 12, 6, 12);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '*';
            guna2TextBox1.PlaceholderText = "Yeni Şifre (Tekrar)";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox1.Size = new Size(411, 61);
            guna2TextBox1.TabIndex = 8;
            guna2TextBox1.TextOffset = new Point(6, 0);
            // 
            // btnSavePassword
            // 
            btnSavePassword.BorderRadius = 13;
            btnSavePassword.Cursor = Cursors.Hand;
            btnSavePassword.CustomizableEdges = customizableEdges7;
            btnSavePassword.DisabledState.BorderColor = Color.DarkGray;
            btnSavePassword.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSavePassword.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSavePassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSavePassword.FillColor = Color.FromArgb(108, 64, 200);
            btnSavePassword.Font = new Font("Poppins", 15F, FontStyle.Bold);
            btnSavePassword.ForeColor = Color.White;
            btnSavePassword.HoverState.FillColor = Color.FromArgb(125, 85, 214);
            btnSavePassword.Location = new Point(371, 449);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSavePassword.Size = new Size(459, 61);
            btnSavePassword.TabIndex = 9;
            btnSavePassword.Text = "Şifreyi Kaydet";
            btnSavePassword.Click += btnSavePassword_Click;
            // 
            // lnkBackToLogin
            // 
            lnkBackToLogin.ActiveLinkColor = Color.FromArgb(108, 64, 200);
            lnkBackToLogin.AutoSize = true;
            lnkBackToLogin.Font = new Font("Microsoft Sans Serif", 11F);
            lnkBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkBackToLogin.LinkColor = Color.White;
            lnkBackToLogin.Location = new Point(524, 531);
            lnkBackToLogin.Name = "lnkBackToLogin";
            lnkBackToLogin.Size = new Size(162, 24);
            lnkBackToLogin.TabIndex = 10;
            lnkBackToLogin.TabStop = true;
            lnkBackToLogin.Text = "Giriş ekranına dön";
            // 
            // pnlSuccessToast
            // 
            pnlSuccessToast.BorderRadius = 12;
            pnlSuccessToast.Controls.Add(btnCloseError);
            pnlSuccessToast.Controls.Add(lblSuccessTitle);
            pnlSuccessToast.Controls.Add(lblSuccessMessage);
            pnlSuccessToast.CustomizableEdges = customizableEdges11;
            pnlSuccessToast.FillColor = Color.FromArgb(54, 209, 220);
            pnlSuccessToast.FillColor2 = Color.FromArgb(54, 209, 220);
            pnlSuccessToast.Location = new Point(871, 137);
            pnlSuccessToast.Name = "pnlSuccessToast";
            customizableEdges12.BottomRight = false;
            customizableEdges12.TopRight = false;
            pnlSuccessToast.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlSuccessToast.Size = new Size(327, 68);
            pnlSuccessToast.TabIndex = 13;
            pnlSuccessToast.Visible = false;
            // 
            // btnCloseError
            // 
            btnCloseError.BackColor = Color.Transparent;
            btnCloseError.BorderColor = Color.Transparent;
            btnCloseError.CustomizableEdges = customizableEdges9;
            btnCloseError.DisabledState.BorderColor = Color.DarkGray;
            btnCloseError.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCloseError.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCloseError.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCloseError.FillColor = Color.FromArgb(54, 190, 220);
            btnCloseError.Font = new Font("Segoe UI", 9F);
            btnCloseError.ForeColor = Color.White;
            btnCloseError.Location = new Point(279, 3);
            btnCloseError.Name = "btnCloseError";
            btnCloseError.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnCloseError.Size = new Size(35, 30);
            btnCloseError.TabIndex = 12;
            btnCloseError.Text = "X";
            btnCloseError.Click += btnCloseError_Click;
            // 
            // lblSuccessTitle
            // 
            lblSuccessTitle.BackColor = Color.Transparent;
            lblSuccessTitle.Font = new Font("Poppins Medium", 9.2F, FontStyle.Bold);
            lblSuccessTitle.ForeColor = Color.White;
            lblSuccessTitle.Location = new Point(10, 5);
            lblSuccessTitle.Name = "lblSuccessTitle";
            lblSuccessTitle.Size = new Size(91, 28);
            lblSuccessTitle.TabIndex = 9;
            lblSuccessTitle.Text = "Hatalı Kod";
            // 
            // lblSuccessMessage
            // 
            lblSuccessMessage.BackColor = Color.Transparent;
            lblSuccessMessage.ForeColor = Color.FromArgb(224, 224, 224);
            lblSuccessMessage.Location = new Point(10, 36);
            lblSuccessMessage.Name = "lblSuccessMessage";
            lblSuccessMessage.Size = new Size(312, 22);
            lblSuccessMessage.TabIndex = 10;
            lblSuccessMessage.Text = "Lütfen E-mail'inize gelen kodu tekrar deneyiniz";
            // 
            // tmrAutoClose
            // 
            tmrAutoClose.Interval = 3000;
            tmrAutoClose.Tick += tmrAutoClose_Tick;
            // 
            // ResetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 19, 25);
            ClientSize = new Size(1200, 720);
            Controls.Add(pnlSuccessToast);
            Controls.Add(lnkBackToLogin);
            Controls.Add(btnSavePassword);
            Controls.Add(guna2TextBox1);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2PictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResetPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ResetPasswordForm";
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            pnlSuccessToast.ResumeLayout(false);
            pnlSuccessToast.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Button btnSavePassword;
        private LinkLabel lnkBackToLogin;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlSuccessToast;
        private Guna.UI2.WinForms.Guna2Button btnCloseError;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSuccessTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSuccessMessage;
        private System.Windows.Forms.Timer tmrAutoClose;
    }
}