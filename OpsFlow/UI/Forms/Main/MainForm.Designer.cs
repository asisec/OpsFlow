namespace OpsFlow.UI.Forms.Main
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();

            this.HeaderPanel.ShadowDecoration.CustomizableEdges = customizableEdges1;
            this.HeaderPanel.Size = new System.Drawing.Size(1382, 40);

            this.CloseButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.CloseButton.HoverState.IconColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(1332, 0);
            this.CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;

            this.MaximizeButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.MaximizeButton.HoverState.IconColor = System.Drawing.Color.White;
            this.MaximizeButton.Location = new System.Drawing.Point(1282, 0);
            this.MaximizeButton.ShadowDecoration.CustomizableEdges = customizableEdges3;

            this.MinimizeButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.MinimizeButton.HoverState.IconColor = System.Drawing.Color.White;
            this.MinimizeButton.Location = new System.Drawing.Point(1232, 0);
            this.MinimizeButton.ShadowDecoration.CustomizableEdges = customizableEdges4;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1382, 791);
            this.Name = "MainForm";
            this.Text = "OpsFlow Dashboard";
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}