using Microsoft.EntityFrameworkCore;

using OpsFlow.Core.Config;
using OpsFlow.Data.Context;

namespace OpsFlow.Data.Config
{
    public static class DbContextConfigurator
    {
        public static DbContextOptions<AppDbContext> Configure(DatabaseSettings settings)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(settings.ConnectionString);
            return optionsBuilder.Options;
        }
    }
}