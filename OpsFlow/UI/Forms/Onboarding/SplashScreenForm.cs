using Guna.UI2.WinForms;

using OpsFlow.Core.Services;
using OpsFlow.UI.Forms.Auth;
using OpsFlow.UI.Forms.Core;

namespace OpsFlow.UI.Forms.Onboarding
{
    public partial class SplashScreenForm : BaseForm
    {
        private Guna2ProgressBar _progressBar = null!;
        private Guna2HtmlLabel _lblStatus = null!;
        private Guna2PictureBox _pbLogo = null!;
        private Guna2ShadowForm _shadowForm = null!;
        private Guna2Elipse _elipse = null!;

        public SplashScreenForm()
        {
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(450, 480);
            this.BackColor = Color.FromArgb(15, 15, 20);
            this.StartPosition = FormStartPosition.CenterScreen;

            _elipse = new Guna2Elipse { TargetControl = this, BorderRadius = 25 };
            _shadowForm = new Guna2ShadowForm { TargetForm = this };

            _pbLogo = new Guna2PictureBox
            {
                Size = new Size(220, 220),
                Location = new Point((this.Width - 220) / 2, 60),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                UseTransparentBackground = true
            };
            LoadLogo();
            this.Controls.Add(_pbLogo);

            _lblStatus = new Guna2HtmlLabel
            {
                Text = "<div style='text-align:center; width:100%;'><span style='color: #6b7280; font-family: Segoe UI; font-size: 9pt;'>Başlatılıyor...</span></div>",
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(this.Width, 25),
                Location = new Point(0, 360)
            };
            this.Controls.Add(_lblStatus);

            _progressBar = new Guna2ProgressBar
            {
                Size = new Size(280, 4),
                Location = new Point((this.Width - 280) / 2, 400),
                FillColor = Color.FromArgb(30, 30, 35),
                ProgressColor = Color.FromArgb(124, 58, 237),
                ProgressColor2 = Color.FromArgb(139, 92, 246),
                BorderRadius = 2,
                Value = 0
            };
            this.Controls.Add(_progressBar);
        }

        private void LoadLogo()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = {
                    Path.Combine(baseDir, "Resources", "Images", "Logo.png"),
                    Path.Combine(baseDir, "..", "..", "..", "Resources", "Images", "Logo.png"),
                    Path.Combine(baseDir, "..", "..", "Resources", "Images", "Logo.png"),
                    "Resources/Images/Logo.png"
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        _pbLogo.Image = Image.FromFile(path);
                        return;
                    }
                }
            }
            catch { }
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await ExecuteBootstrapper();
        }

        private async Task ExecuteBootstrapper()
        {
            try
            {
                var bootstrapper = new AppBootstrapper(DatabaseManager.Instance);
                await bootstrapper.InitializeAsync((message, progress) =>
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            _ = UpdateStatus(message, progress);
                        }));
                    }
                    else
                    {
                        _ = UpdateStatus(message, progress);
                    }
                });

                WindowManager.Switch<LoginForm>(this);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null && !ex.Message.Contains(ex.InnerException.Message))
                {
                    errorMessage += $"\n{ex.InnerException.Message}";
                }

                _lblStatus.Text = $"<div style='text-align:center; width:100%; padding: 0 20px;'><span style='color: #ef4444; font-size: 9pt; line-height: 1.4;'>{errorMessage}</span></div>";
                _progressBar.ProgressColor = Color.FromArgb(239, 68, 68);
                _progressBar.ProgressColor2 = Color.FromArgb(239, 68, 68);
                await Task.Delay(5000);
                WindowManager.Exit();
            }
        }

        private async Task UpdateStatus(string message, int progressValue)
        {
            _lblStatus.Text = $"<div style='text-align:center; width:100%;'><span style='color: #6b7280;'>{message}</span></div>";
            int current = _progressBar.Value;
            while (current < progressValue)
            {
                current += 2;
                if (current > progressValue) current = progressValue;
                _progressBar.Value = current;
                await Task.Delay(10);
            }
        }

    }
}