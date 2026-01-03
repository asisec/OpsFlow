using OpsFlow.Core.Models;

namespace OpsFlow.Services.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Task<List<Company>> GetAllCompaniesAsync();
        Company? GetCompanyById(int id);
        void RegisterCompany(Company company);
        Task RegisterCompanyAsync(Company company);
    }
}


