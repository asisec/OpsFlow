using OpsFlow.Core.Models;
using OpsFlow.Data.Context;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public UserRegistrationService(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task RegisterPersonelAsync(User user, int roleId, int? companyId, int? departmentId = null)
        {
            user.RoleId = roleId;
            user.CompanyId = companyId;
            user.DepartmentId = departmentId;
            user.IsActive = true;
            user.CreatedAt = DateTime.UtcNow;

            await Task.Run(() => _userService.RegisterUser(user));
        }
    }
}