using Microsoft.EntityFrameworkCore;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Data.Context;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAllRoles()
        {
            try
            {
                return _context.Roles
                    .AsNoTracking()
                    .OrderBy(r => r.RoleName)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Roller alınırken bir hata oluştu.", ex);
            }
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            try
            {
                return await _context.Roles
                    .AsNoTracking()
                    .OrderBy(r => r.RoleName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Roller alınırken bir hata oluştu.", ex);
            }
        }

        public Role? GetRoleById(int id)
        {
            try
            {
                return _context.Roles
                    .AsNoTracking()
                    .FirstOrDefault(r => r.Id == id);
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException($"Rol sorgulanırken bir hata oluştu: {id}", ex);
            }
        }
    }
}


