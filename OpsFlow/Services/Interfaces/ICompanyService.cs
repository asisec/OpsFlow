using OpsFlow.Core.Models;

namespace OpsFlow.Services.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Task<List<Company>> GetAllCompaniesAsync();
        Company? GetCompanyById(int id);
    }
}


