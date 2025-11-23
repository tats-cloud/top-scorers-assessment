using Application.Services;
using Data;
using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ScorerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            DatabaseInitialiser.InitializeDatabase();
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite($"Data Source={DatabaseInitialiser.DbPath}"));

            builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
            builder.Services.AddScoped<IScoresService, ScoresService>();

            var app = builder.Build();

            DatabaseInitialiser.EnsureDbCreated(app.Services);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}