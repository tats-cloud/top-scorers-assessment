using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DatabaseContext
{
    public interface IDatabaseContext
    {
        DbSet<Scorer> Scorers { get; set; }

        bool EnsureCreated();
        int SaveChanges();
    }
}
