using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class CashflowDbContext : DbContext
    {
        public CashflowDbContext(DbContextOptions<CashflowDbContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.User.User> User {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
