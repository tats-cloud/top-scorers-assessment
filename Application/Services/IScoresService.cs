using Application.Models;

namespace Application.Services
{
    public interface IScoresService
    {
        public Task<int> CreateScoreAsync(CreateScoreModel score, CancellationToken cancellationToken);
        public Task<IndividualScoreModel> GetIndividualScore(int scoreId, CancellationToken cancellationToken);
        public Task<IEnumerable<ScoreModel>> GetTopScores(CancellationToken cancellationToken);
    }
}
