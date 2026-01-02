using OpsFlow.Core.Models;

namespace OpsFlow.Services.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Task<List<Role>> GetAllRolesAsync();
        Role? GetRoleById(int id);
    }
}


