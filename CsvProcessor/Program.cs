using CsvProcessor;
using Data.DatabaseContext;

class Program
{
    static void Main()
    {
        using DatabaseContext concreteDbContext = new();
        IDatabaseContext dbContext = concreteDbContext;

        var processor = new DataProcessor(dbContext);

        processor.RunDataImport();
    }
}
