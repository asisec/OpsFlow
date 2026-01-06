using Microsoft.EntityFrameworkCore;

using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Data.Context;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                return _context.Departments
                    .AsNoTracking()
                    .OrderBy(d => d.DepartmentName)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Departmanlar alınırken bir hata oluştu.", ex);
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                return await _context.Departments
                    .AsNoTracking()
                    .OrderBy(d => d.DepartmentName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Departmanlar alınırken bir hata oluştu.", ex);
            }
        }

        public Department? GetDepartmentById(int id)
        {
            try
            {
                return _context.Departments
                    .AsNoTracking()
                    .FirstOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException($"Departman sorgulanırken bir hata oluştu: {id}", ex);
            }
        }
    }
}