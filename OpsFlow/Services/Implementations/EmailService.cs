using OpsFlow.Core.Config;
using OpsFlow.Services.Interfaces;
using System;
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

            if (string.IsNullOrWhiteSpace(host))
                throw new Exception("SMTP_HOST env değeri eksik.");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("SMTP_EMAIL env değeri eksik.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("SMTP_PASSWORD env değeri eksik.");

            if (!int.TryParse(portValue, out int port))
                port = 587;

            _settings = new SmtpSettings
            {
                Host = host,
                Port = port,
                Email = email,
                Password = password
            };
        }

        public void SendEmail(string to, string subject, string body)
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
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(to);

                client.Send(mailMessage);
            }
        }
    }
}