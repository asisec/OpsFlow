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
            HeaderPanel.SuspendLayout();
            SuspendLayout();

            HeaderPanel.ShadowDecoration.CustomizableEdges = customizableEdges1;
            HeaderPanel.Size = new Size(1382, 40);

            CloseButton.HoverState.FillColor = Color.FromArgb(232, 17, 35);
            CloseButton.HoverState.IconColor = Color.White;
            CloseButton.Location = new Point(1332, 0);
            CloseButton.ShadowDecoration.CustomizableEdges = customizableEdges2;

            MaximizeButton.HoverState.FillColor = Color.FromArgb(40, 44, 55);
            MaximizeButton.HoverState.IconColor = Color.White;
            MaximizeButton.Location = new Point(1282, 0);
            MaximizeButton.ShadowDecoration.CustomizableEdges = customizableEdges3;

            MinimizeButton.HoverState.FillColor = Color.FromArgb(40, 44, 55);
            MinimizeButton.HoverState.IconColor = Color.White;
            MinimizeButton.Location = new Point(1232, 0);
            MinimizeButton.ShadowDecoration.CustomizableEdges = customizableEdges4;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 46);
            ClientSize = new Size(1382, 791);
            Name = "MainForm";
            Text = "OpsFlow Dashboard";
            HeaderPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}