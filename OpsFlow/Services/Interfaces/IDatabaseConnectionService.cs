using OpsFlow.Data.Context;

namespace OpsFlow.Services.Interfaces
{
    public interface IDatabaseConnectionService
    {
        AppDbContext CreateContext();
    }
}