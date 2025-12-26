using OpsFlow.Core.Config;
using OpsFlow.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace OpsFlow.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        public EmailService()
        {
            var host = Environment.GetEnvironmentVariable("SMTP_HOST");
            var portValue = Environment.GetEnvironmentVariable("SMTP_PORT");
            var email = Environment.GetEnvironmentVariable("SMTP_EMAIL");
            var password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");

            if (!int.TryParse(portValue, out int port)) port = 587;

            _settings = new SmtpSettings
            {
                Host = host ?? "smtp.gmail.com",
                Port = port,
                Email = email ?? "",
                Password = password ?? ""
            };
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_settings.Host, _settings.Port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_settings.Email, _settings.Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_settings.Email, "OpsFlow Security"),
                    Subject = subject,
                    Body = GetHtmlTemplate(body),
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);
                await client.SendMailAsync(mailMessage);
            }
        }

        private string GetHtmlTemplate(string code)
        {
            return $@"
    <!DOCTYPE html>
    <html lang='tr'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <style>
            body {{ margin: 0; padding: 0; background-color: #17181E; font-family: 'Segoe UI', Arial, sans-serif; color: #e4e4e7; }}
            .email-wrapper {{ width: 100%; background-color: #17181E; padding: 40px 0; }}
            .container {{ width: 95%; max-width: 480px; margin: 0 auto; background: #17181E; border-radius: 16px; border: 1px solid rgba(255, 255, 255, 0.1); overflow: hidden; }}
            .logo-header {{ padding: 24px; text-align: center; border-bottom: 1px solid rgba(255, 255, 255, 0.1); background: rgba(0, 0, 0, 0.2); }}
            .logo-image {{ height: 35px; width: auto; vertical-align: middle; }}
            .content {{ padding: 40px 30px; text-align: center; }}
            h1 {{ font-size: 22px; font-weight: 600; color: #ffffff; margin: 0 0 10px 0; }}
            .subtitle {{ font-size: 14px; color: #9ca3af; margin-bottom: 35px; }}
            .code-card {{ background: #4F30BC; border-radius: 12px; padding: 30px; margin: 0 auto 35px auto; display: inline-block; min-width: 240px; }}
            .code-text {{ font-size: 44px; font-weight: 800; color: #ffffff; letter-spacing: 12px; font-family: 'Courier New', monospace; margin: 0; line-height: 1; }}
            .info-box {{ text-align: left; padding: 16px; background: rgba(0, 0, 0, 0.3); border-radius: 10px; border-left: 3px solid #4F30BC; margin-bottom: 15px; }}
            .info-box strong {{ display: block; font-size: 13px; color: #fff; margin-bottom: 4px; }}
            .info-box p {{ font-size: 12px; color: #9ca3af; margin: 0; line-height: 1.5; }}
            .footer {{ text-align: center; padding: 20px; border-top: 1px solid rgba(255, 255, 255, 0.1); }}
            .footer-text {{ font-size: 11px; color: #555; margin: 0; }}
            .signature {{ color: #00d4ff; text-decoration: none; font-weight: 600; }}
        </style>
    </head>
    <body>
        <div class='email-wrapper'>
            <div class='container'>
                <div class='logo-header'>
                    <img src='https://raw.githubusercontent.com/asisec/OpsFlow/refs/heads/master/OpsFlow/Resources/Images/Logo.png' alt='OpsFlow' class='logo-image'>
                </div>
                <div class='content'>
                    <h1>Güvenlik Doğrulaması</h1>
                    <p class='subtitle'>İşleminizi tamamlamak için kullanacağınız tek kullanımlık kod:</p>

                    <div class='code-card'>
                        <p class='code-text'>{code}</p>
                    </div>

                    <div class='info-box'>
                        <strong>⏰ Geçerlilik Süresi</strong>
                        <p>Bu kod güvenlik gereği 3 dakika boyunca geçerlidir. Süre dolduğunda yeni kod talep etmelisiniz.</p>
                    </div>

                    <div class='info-box'>
                        <strong>🔒 Güvenlik Uyarısı</strong>
                        <p>Hesap güvenliğiniz için bu kodu kimseyle paylaşmayın.</p>
                    </div>
                </div>
                <div class='footer'>
                    <p class='footer-text'>© 2025 <span class='signature'>OpsFlow System</span></p>
                </div>
            </div>
        </div>
    </body>
    </html>";
        }
    }
}