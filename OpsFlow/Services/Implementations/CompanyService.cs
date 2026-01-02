using Microsoft.EntityFrameworkCore;
using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Data.Context;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public List<Company> GetAllCompanies()
        {
            try
            {
                return _context.Companies
                    .AsNoTracking()
                    .OrderBy(c => c.CompanyName)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Şirketler alınırken bir hata oluştu.", ex);
            }
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            try
            {
                return await _context.Companies
                    .AsNoTracking()
                    .OrderBy(c => c.CompanyName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Şirketler alınırken bir hata oluştu.", ex);
            }
        }

        public Company? GetCompanyById(int id)
        {
            try
            {
                return _context.Companies
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException($"Şirket sorgulanırken bir hata oluştu: {id}", ex);
            }
        }
    }
}


