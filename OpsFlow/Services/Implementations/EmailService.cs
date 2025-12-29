using System.Net;
using System.Net.Mail;
using OpsFlow.Core.Config;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Interfaces;

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

            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new Exception("SMTP configuration is missing in .env file.");
            }

            if (!int.TryParse(portValue, out int port)) port = 587;

            _settings = new SmtpSettings
            {
                Host = host,
                Port = port,
                Email = email,
                Password = password
            };
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            if (_settings == null) throw new Exception("Email settings are not initialized.");

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
                    Body = EmailTemplateHelper.GetVerificationTemplate(body),
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}