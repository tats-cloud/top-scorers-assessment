using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DatabaseInitialiser
    {
        public static string? DbPath { get; private set; }

        public static void InitializeDatabase()
        {
            string environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configuration.GetConnectionString("SqliteDb")
                                  ?? throw new InvalidOperationException("Connection string 'SqliteDb' not found in any configuration file.");

            string absoluteFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, connectionString));
            string databaseFolder = Path.GetDirectoryName(absoluteFilePath)
                                    ?? throw new InvalidOperationException("Could not determine database directory.");
            Directory.CreateDirectory(databaseFolder);

            DbPath = absoluteFilePath;

            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.Open();

            Console.WriteLine($"Database ready at: {DbPath}");
        }

        public static void EnsureDbCreated(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext.DatabaseContext>();
            context.EnsureCreated();
        }
    }

}
