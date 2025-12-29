using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace OpsFlow.UI.Forms.Core
{
    public class BaseForm : Form
    {
        private IContainer? components;

        private Guna2BorderlessForm? borderlessForm;
        private Guna2ShadowForm? shadowForm;
        private Guna2DragControl? dragControl;

        protected Guna2Panel? HeaderPanel;
        protected Guna2ControlBox? CloseButton;
        protected Guna2ControlBox? MaximizeButton;
        protected Guna2ControlBox? MinimizeButton;

        public BaseForm()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                InitializeComponentDummy();
                return;
            }

            this.components = new Container();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeBaseUI();
            InitializeGunaComponents();
        }

        private void InitializeComponentDummy()
        {
            this.components = new Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void InitializeBaseUI()
        {
            this.HeaderPanel = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 35,
                FillColor = Color.Transparent,
                Padding = new Padding(0)
            };
            this.Controls.Add(this.HeaderPanel);

            this.MinimizeButton = new Guna2ControlBox
            {
                Dock = DockStyle.Right,
                Width = 45,
                FillColor = Color.Transparent,
                IconColor = Color.FromArgb(160, 160, 160),
                ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            this.MinimizeButton.HoverState.FillColor = Color.FromArgb(40, 40, 40);
            this.MinimizeButton.HoverState.IconColor = Color.White;
            this.HeaderPanel.Controls.Add(this.MinimizeButton);

            this.MaximizeButton = new Guna2ControlBox
            {
                Dock = DockStyle.Right,
                Width = 45,
                FillColor = Color.Transparent,
                IconColor = Color.FromArgb(160, 160, 160),
                ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            this.MaximizeButton.HoverState.FillColor = Color.FromArgb(40, 40, 40);
            this.MaximizeButton.HoverState.IconColor = Color.White;
            this.HeaderPanel.Controls.Add(this.MaximizeButton);

            this.CloseButton = new Guna2ControlBox
            {
                Dock = DockStyle.Right,
                Width = 45,
                FillColor = Color.Transparent,
                IconColor = Color.FromArgb(160, 160, 160),
                ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            this.CloseButton.HoverState.FillColor = Color.FromArgb(232, 17, 35);
            this.CloseButton.HoverState.IconColor = Color.White;
            this.HeaderPanel.Controls.Add(this.CloseButton);
        }

        private void InitializeGunaComponents()
        {
            if (this.components == null) return;

            this.borderlessForm = new Guna2BorderlessForm(this.components);
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.DockIndicatorTransparencyValue = 0.6;
            this.borderlessForm.TransparentWhileDrag = true;
            this.borderlessForm.BorderRadius = 0;
            this.borderlessForm.ShadowColor = Color.DimGray;
            this.borderlessForm.HasFormShadow = false;

            this.shadowForm = new Guna2ShadowForm(this.components);
            this.shadowForm.TargetForm = this;

            this.dragControl = new Guna2DragControl(this.components);
            this.dragControl.TargetControl = this.HeaderPanel;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                base.OnLoad(e);
                return;
            }

            base.OnLoad(e);
            ApplyWindowStateLogic();
        }

        private void ApplyWindowStateLogic()
        {
            var excludedTypes = new List<Type>
            {
                typeof(LoginForm),
                typeof(VerificationForm),
                typeof(ResetPasswordForm),
                typeof(ForgotPasswordForm),
                typeof(SplashScreenForm),
                typeof(CompanyRegisterForm),
                typeof(AddPersonelForm)
            };

            if (this.GetType() == typeof(SplashScreenForm))
            {
                if (this.HeaderPanel != null) this.HeaderPanel.Visible = false;
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (excludedTypes.Contains(this.GetType()))
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;

                if (this.MaximizeButton != null)
                {
                    this.MaximizeButton.Enabled = false;
                    this.MaximizeButton.IconColor = Color.FromArgb(35, 35, 35);
                }
            }
            else
            {
                this.MaximizedBounds = Screen.GetWorkingArea(this);
                this.WindowState = FormWindowState.Maximized;

                if (this.borderlessForm != null)
                {
                    this.borderlessForm.BorderRadius = 0;
                }

                if (this.MaximizeButton != null)
                {
                    this.MaximizeButton.Enabled = true;
                    this.MaximizeButton.IconColor = Color.FromArgb(160, 160, 160);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}