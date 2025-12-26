using System.Threading.Tasks;

namespace OpsFlow.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}