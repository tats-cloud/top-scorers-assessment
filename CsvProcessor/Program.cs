using CsvProcessor;
using Data;
using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        DatabaseInitializer.InitializeDatabase();

        var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite($"Data Source={DatabaseInitializer.DbPath}").Options;

        using DatabaseContext concreteDbContext = new(options);
        IDatabaseContext dbContext = concreteDbContext;

        var processor = new DataProcessor(dbContext);

        dbContext.EnsureCreated();

        processor.RunDataImport();
    }
}
