using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DatabaseContext
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Scorer> Scorers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public bool EnsureCreated()
        {
            return base.Database.EnsureCreated();
        }

    }
}
