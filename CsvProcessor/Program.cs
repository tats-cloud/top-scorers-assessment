using CsvProcessor;
using Data;
using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        DatabaseInitialiser.InitializeDatabase();

        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlite($"Data Source={DatabaseInitialiser.DbPath}")
            .Options;

        using DatabaseContext dbContext = new(options);
        dbContext.EnsureCreated();

        var processor = new DataProcessor(dbContext);

        processor.RunDataImport();
    }
}
