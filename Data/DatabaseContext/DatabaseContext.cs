using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DatabaseContext
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Scorer> Scorers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=scores.db");
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
