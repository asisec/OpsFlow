using OpsFlow.Core.Models;

namespace OpsFlow.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void RegisterUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User Authenticate(string email, string password);
        bool UserExists(string email);
        void ResetPassword(string email, string newPassword);
    }
}