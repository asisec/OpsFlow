using Microsoft.EntityFrameworkCore;
using Npgsql;
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

        public void RegisterCompany(Company company)
        {
            if (company == null)
                throw new ValidationException("Şirket bilgisi boş olamaz.");

            if (string.IsNullOrWhiteSpace(company.CompanyName))
                throw new ValidationException("Şirket adı boş olamaz.");

            try
            {
                bool companyExists = _context.Companies.Any(c => c.CompanyName == company.CompanyName);
                if (companyExists)
                {
                    throw new BusinessException("Bu şirket adı sistemde zaten kayıtlı.");
                }

                if (!string.IsNullOrWhiteSpace(company.TaxNumber))
                {
                    bool taxNumberExists = _context.Companies.Any(c => c.TaxNumber == company.TaxNumber);
                    if (taxNumberExists)
                    {
                        throw new BusinessException("Bu vergi numarası sistemde zaten kayıtlı.");
                    }
                }

                if (company.CreatedAt == default)
                {
                    company.CreatedAt = DateTime.UtcNow;
                }

                _context.Companies.Add(company);
                _context.SaveChanges();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                string errorDetail = "Veritabanı güncelleme hatası oluştu.";
                if (dbEx.InnerException != null)
                {
                    if (dbEx.InnerException is Npgsql.PostgresException pgEx)
                    {
                        errorDetail = $"Veritabanı hatası: {pgEx.MessageText}";
                        if (!string.IsNullOrEmpty(pgEx.Detail))
                        {
                            errorDetail += $"\nDetay: {pgEx.Detail}";
                        }
                    }
                    else
                    {
                        errorDetail = $"Veritabanı hatası: {dbEx.InnerException.Message}";
                    }
                }
                throw new DatabaseQueryException(errorDetail, dbEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Şirket kaydı sırasında veritabanı hatası oluştu.", ex);
            }
        }

        public async Task RegisterCompanyAsync(Company company)
        {
            await Task.Run(() => RegisterCompany(company));
        }
    }
}


