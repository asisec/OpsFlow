using OpsFlow.Core.Models;

namespace OpsFlow.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Task<List<Department>> GetAllDepartmentsAsync();
        Department? GetDepartmentById(int id);
    }
}