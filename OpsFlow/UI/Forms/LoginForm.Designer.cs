namespace OpsFlow.UI.Forms
{
    partial class LoginForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            label1 = new Label();
            txtEposta = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            lnkForgotText = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges9;
            guna2ControlBox1.FillColor = Color.FromArgb(139, 152, 166);
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(1142, 1);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2ControlBox1.Size = new Size(56, 36);
            guna2ControlBox1.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges7;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(24, 48);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2PictureBox1.Size = new Size(238, 75);
            guna2PictureBox1.TabIndex = 1;
            guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(445, 159);
            label1.Name = "label1";
            label1.Size = new Size(264, 82);
            label1.TabIndex = 2;
            label1.Text = "Giriş Yap.";
            // 
            // txtEposta
            // 
            txtEposta.BorderColor = Color.FromArgb(45, 50, 62);
            txtEposta.BorderRadius = 18;
            txtEposta.BorderThickness = 4;
            txtEposta.CustomizableEdges = customizableEdges5;
            txtEposta.DefaultText = "";
            txtEposta.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEposta.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEposta.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEposta.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEposta.FillColor = Color.FromArgb(26, 29, 38);
            txtEposta.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEposta.Font = new Font("Poppins", 13F);
            txtEposta.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEposta.Location = new Point(361, 270);
            txtEposta.Margin = new Padding(8, 14, 8, 14);
            txtEposta.Name = "txtEposta";
            txtEposta.Padding = new Padding(46, 0, 0, 0);
            txtEposta.PlaceholderText = "E-mail";
            txtEposta.SelectedText = "";
            txtEposta.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEposta.Size = new Size(411, 61);
            txtEposta.TabIndex = 3;
            txtEposta.TextOffset = new Point(6, 0);
            txtEposta.TextChanged += txtEposta_TextChanged;
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
            txtPassword.Location = new Point(361, 357);
            txtPassword.Margin = new Padding(6, 12, 6, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Şifre";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPassword.Size = new Size(411, 61);
            txtPassword.TabIndex = 4;
            txtPassword.TextOffset = new Point(6, 0);
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 13;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(108, 64, 200);
            btnLogin.Font = new Font("Poppins", 15F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverState.FillColor = Color.FromArgb(125, 85, 214);
            btnLogin.Location = new Point(333, 448);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(459, 61);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Giriş Yap";
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkForgotText
            // 
            lnkForgotText.ActiveLinkColor = Color.FromArgb(108, 64, 200);
            lnkForgotText.AutoSize = true;
            lnkForgotText.Font = new Font("Poppins", 11F);
            lnkForgotText.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkForgotText.LinkColor = Color.White;
            lnkForgotText.Location = new Point(467, 554);
            lnkForgotText.Name = "lnkForgotText";
            lnkForgotText.Size = new Size(178, 34);
            lnkForgotText.TabIndex = 6;
            lnkForgotText.TabStop = true;
            lnkForgotText.Text = "Şifremi unuttum?";
            lnkForgotText.LinkClicked += lnkForgotText_LinkClicked;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 19, 25);
            ClientSize = new Size(1200, 720);
            Controls.Add(lnkForgotText);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEposta);
            Controls.Add(label1);
            Controls.Add(guna2PictureBox1);
            Controls.Add(guna2ControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtEposta;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private LinkLabel lnkForgotText;
    }
}