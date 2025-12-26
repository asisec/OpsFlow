using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OpsFlow.UI.Forms.Notifications
{
    public abstract class BaseNotificationForm : Form
    {
        protected Guna2BorderlessForm BorderlessForm = null!;
        protected Guna2GradientPanel MainPanel = null!;
        protected Guna2Panel IconCirclePanel = null!;
        protected Guna2PictureBox IconPictureBox = null!;
        protected Label TitleLabel = null!;
        protected Label MessageLabel = null!;
        protected Guna2Button CloseButton = null!;

        private readonly System.Windows.Forms.Timer _animationTimer;
        private readonly Color _darkBackgroundColor = Color.FromArgb(32, 32, 32);
        private bool _isClosing = false;
        private System.ComponentModel.IContainer? components = null;

        protected override bool ShowWithoutActivation => true;

        protected BaseNotificationForm(string title, string message, Color themeColor, Icon icon, Form? owner)
        {
            InitializeUI(themeColor);

            TitleLabel.Text = title;
            MessageLabel.Text = message;
            IconPictureBox.Image = icon.ToBitmap();

            int minHeight = 85;
            int paddingBottom = 20;
            int requiredHeight = MessageLabel.Location.Y + MessageLabel.Height + paddingBottom;

            if (requiredHeight > minHeight)
            {
                this.Height = requiredHeight;
            }

            if (owner != null && !owner.IsDisposed)
            {
                this.Owner = owner;
            }

            this.Load += (s, e) => SetPosition(owner);

            BindClickEvent(this);

            _animationTimer = new System.Windows.Forms.Timer { Interval = 10 };
            _animationTimer.Tick += HandleAnimationTick;
            _animationTimer.Start();
        }

        private void BindClickEvent(Control control)
        {
            control.Click += (s, e) => InitiateClose();
            foreach (Control child in control.Controls)
            {
                BindClickEvent(child);
            }
        }

        private void InitializeUI(Color themeColor)
        {
            this.components = new System.ComponentModel.Container();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(450, 85);
            this.ShowInTaskbar = false;
            this.TopMost = false;
            this.BackColor = _darkBackgroundColor;
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 0;
            this.Cursor = Cursors.Hand;
            this.ShowIcon = false;

            BorderlessForm = new Guna2BorderlessForm(this.components)
            {
                ContainerControl = this,
                BorderRadius = 12,
                ShadowColor = Color.Black
            };

            MainPanel = new Guna2GradientPanel
            {
                Dock = DockStyle.Fill,
                BorderRadius = 12,
                GradientMode = LinearGradientMode.Horizontal
            };
            MainPanel.FillColor = Color.FromArgb(65, themeColor);
            MainPanel.FillColor2 = _darkBackgroundColor;
            this.Controls.Add(MainPanel);

            IconCirclePanel = new Guna2Panel
            {
                Size = new Size(46, 46),
                Location = new Point(18, 19),
                BorderRadius = 23,
                FillColor = themeColor
            };
            IconCirclePanel.ShadowDecoration.Enabled = true;
            IconCirclePanel.ShadowDecoration.BorderRadius = 23;
            IconCirclePanel.ShadowDecoration.Depth = 15;
            IconCirclePanel.ShadowDecoration.Color = themeColor;
            IconCirclePanel.ShadowDecoration.Shadow = new Padding(0, 0, 8, 8);
            MainPanel.Controls.Add(IconCirclePanel);

            IconPictureBox = new Guna2PictureBox
            {
                Size = new Size(26, 26),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };
            IconCirclePanel.Controls.Add(IconPictureBox);

            TitleLabel = new Label
            {
                Location = new Point(78, 18),
                Size = new Size(270, 24),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            MainPanel.Controls.Add(TitleLabel);

            MessageLabel = new Label
            {
                Location = new Point(78, 44),
                AutoSize = true,
                MaximumSize = new Size(340, 0),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 200, 200),
                BackColor = Color.Transparent
            };
            MainPanel.Controls.Add(MessageLabel);

            CloseButton = new Guna2Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(30, 30),
                Location = new Point(412, 8),
                BorderRadius = 15,
                Text = "×",
                Font = new Font("Arial", 16, FontStyle.Regular),
                TextOffset = new Point(1, -2),
                FillColor = Color.Transparent,
                ForeColor = Color.FromArgb(150, 150, 150),
                Cursor = Cursors.Hand
            };
            CloseButton.HoverState.FillColor = Color.FromArgb(50, 255, 255, 255);
            CloseButton.HoverState.ForeColor = Color.White;
            CloseButton.Click += (s, e) => InitiateClose();
            MainPanel.Controls.Add(CloseButton);

            var autoCloseTimer = new System.Windows.Forms.Timer { Interval = 4000 };
            autoCloseTimer.Tick += (s, e) => { autoCloseTimer.Stop(); InitiateClose(); };
            autoCloseTimer.Start();
        }

        private void SetPosition(Form? owner)
        {
            this.StartPosition = FormStartPosition.Manual;

            if (owner != null && !owner.IsDisposed && owner.Visible && owner.WindowState != FormWindowState.Minimized)
            {
                int x = owner.Location.X + owner.Width - this.Width - 20;
                int y = owner.Location.Y + owner.Height - this.Height - 20;
                this.Location = new Point(x, y);
            }
            else
            {
                var screen = Screen.FromPoint(Cursor.Position);
                this.Location = new Point(screen.WorkingArea.Right - this.Width - 20, screen.WorkingArea.Bottom - this.Height - 20);
            }
        }

        private void InitiateClose()
        {
            if (_isClosing) return;
            _isClosing = true;
            _animationTimer.Start();
        }

        private void HandleAnimationTick(object? sender, EventArgs e)
        {
            if (_isClosing)
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.15;
                else
                {
                    _animationTimer.Stop();
                    this.Close();
                }
            }
            else
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.15;
                else
                    _animationTimer.Stop();
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