using Data.DatabaseContext;

namespace Application.Services
{
    public class ScoresService(IDatabaseContext databaseContext)
    {
        private readonly IDatabaseContext databaseContext = databaseContext;
    }
}
