using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DatabaseContext
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options), IDatabaseContext
    {
        public DbSet<Scorer> Scorers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public bool EnsureCreated()
        {
            return base.Database.EnsureCreated();
        }

    }
}
