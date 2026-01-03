using OpsFlow.Core.Models;

namespace OpsFlow.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        Task RegisterPersonelAsync(User user, int roleId, int? companyId, int? departmentId = null);
    }
}