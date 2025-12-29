using Microsoft.EntityFrameworkCore;

using OpsFlow.Core.Models;

namespace OpsFlow.Data.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<IndividualCustomer> IndividualCustomers => Set<IndividualCustomer>();
    }
}