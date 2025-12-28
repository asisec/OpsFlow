using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace OpsFlow.UI.Forms.Core
{
    public class BaseForm : Form
    {
        private IContainer? components;
        private Guna2BorderlessForm? borderlessForm;
        private Guna2ShadowForm? shadowForm;

        public BaseForm()
        {
            this.components = new Container();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeGunaComponents();
        }

        private void InitializeGunaComponents()
        {
            if (this.components == null) return;

            this.borderlessForm = new Guna2BorderlessForm(this.components);
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.DockIndicatorTransparencyValue = 0.6;
            this.borderlessForm.TransparentWhileDrag = true;
            this.borderlessForm.BorderRadius = 10;
            this.borderlessForm.ShadowColor = System.Drawing.Color.DimGray;

            this.shadowForm = new Guna2ShadowForm(this.components);
            this.shadowForm.TargetForm = this;
        }

        protected override void OnLoad(EventArgs e)
        {
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
                typeof(CompanyRegisterForm)
            };

            if (excludedTypes.Contains(this.GetType()))
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                if (this.borderlessForm != null)
                {
                    this.borderlessForm.BorderRadius = 0;
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