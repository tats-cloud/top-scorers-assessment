using Microsoft.Data.Sqlite;

namespace Data
{
    public static class DatabaseInitializer
    {
        public static string? DbPath { get; private set; }

        public static void InitializeDatabase()
        {
            string solutionFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

            string databaseFolder = Path.Combine(solutionFolder, "Database");
            Directory.CreateDirectory(databaseFolder);

            DbPath = Path.Combine(databaseFolder, "TestData.db");

            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.Open();

            Console.WriteLine($"Database ready at: {DbPath}");
        }
    }

}
