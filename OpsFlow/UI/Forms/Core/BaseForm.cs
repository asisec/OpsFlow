using System.ComponentModel;

using Guna.UI2.WinForms;

namespace OpsFlow.UI.Forms.Core;

public class BaseForm : Form
{
    private IContainer? components;
    private Guna2BorderlessForm? borderlessForm;
    private Guna2ShadowForm? shadowForm;
    private Guna2DragControl? dragControl;

    public Guna2Panel? HeaderPanel;

    protected Guna2ControlBox? CloseButton;
    protected Guna2ControlBox? MaximizeButton;
    protected Guna2ControlBox? MinimizeButton;

    public BaseForm()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            InitializeDesigntime();
            return;
        }

        InitializeComponent();
        InitializeBaseUI();
        InitializeGunaComponents();
    }

    private void InitializeDesigntime()
    {
        components = new Container();
        AutoScaleMode = AutoScaleMode.Font;
        FormBorderStyle = FormBorderStyle.Sizable;
    }

    private void InitializeComponent()
    {
        components = new Container();
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 251);
        DoubleBuffered = true;
    }

    private void InitializeBaseUI()
    {
        HeaderPanel = new Guna2Panel
        {
            Dock = DockStyle.Top,
            Height = 40,
            FillColor = Color.Transparent,
            Padding = new Padding(0)
        };

        InitializeControlBox(ref MinimizeButton, Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox);
        InitializeControlBox(ref MaximizeButton, Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox);
        InitializeControlBox(ref CloseButton, Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox);

        if (CloseButton != null)
        {
            CloseButton.HoverState.FillColor = Color.FromArgb(232, 17, 35);
            CloseButton.HoverState.IconColor = Color.White;
        }

        Controls.Add(HeaderPanel);
    }

    private void InitializeControlBox(ref Guna2ControlBox? btn, Guna.UI2.WinForms.Enums.ControlBoxType type)
    {
        btn = new Guna2ControlBox
        {
            Dock = DockStyle.Right,
            Width = 50,
            FillColor = Color.Transparent,
            IconColor = Color.FromArgb(160, 160, 160),
            ControlBoxType = type,
            Cursor = Cursors.Hand,
            TabStop = false,
            Animated = true
        };

        btn.HoverState.FillColor = Color.FromArgb(40, 44, 55);
        btn.HoverState.IconColor = Color.White;

        HeaderPanel?.Controls.Add(btn);
    }

    private void InitializeGunaComponents()
    {
        if (components == null) return;

        borderlessForm = new Guna2BorderlessForm(components)
        {
            ContainerControl = this,
            DockIndicatorTransparencyValue = 0.6,
            TransparentWhileDrag = true,
            BorderRadius = 0,
            HasFormShadow = false
        };

        shadowForm = new Guna2ShadowForm(components)
        {
            TargetForm = this
        };

        dragControl = new Guna2DragControl(components)
        {
            TargetControl = HeaderPanel
        };
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        ApplyWindowStateLogic();
    }

    private void ApplyWindowStateLogic()
    {
        var currentFormName = GetType().Name;

        var excludedTypes = new List<string>
        {
            "LoginForm",
            "VerificationForm",
            "ResetPasswordForm",
            "ForgotPasswordForm",
            "SplashScreenForm"
        };

        if (excludedTypes.Contains(currentFormName))
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            if (MaximizeButton != null) MaximizeButton.Enabled = false;
        }
        else
        {
            MaximizedBounds = Screen.GetWorkingArea(this);
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