using Application.Exceptions;
using Application.Models;
using Data.DatabaseContext;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ScoresService(IDatabaseContext dbContext) : IScoresService
    {
        private readonly IDatabaseContext dbContext = dbContext;

        public async Task<int> CreateScoreAsync(CreateScoreModel score, CancellationToken cancellationToken)
        {
            var newScore = new Scorer
            {
                FirstName = score.FirstName,
                SecondName = score.SecondName,
                Score = score.Score,
            };

            await dbContext.Scorers.AddAsync(newScore, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return newScore.Id;
        }

        public async Task<IndividualScoreModel> GetIndividualScore(int scoreId, CancellationToken cancellationToken)
        {
            var score = await dbContext.Scorers
                .Where(s => s.Id == scoreId)
                .Select(s => new IndividualScoreModel(s.Id, s.Score))
                .FirstOrDefaultAsync(cancellationToken);

            if (score == default)
            {
                throw new ScoreNotFoundException($"Score with Id {scoreId} could not be found");
            }

            return score;
        }

        public async Task<ScoreModel> GetTopScores(CancellationToken cancellationToken)
        {
            var anyScores = await dbContext.Scorers.AnyAsync(cancellationToken);

            if (!anyScores)
            {
                return new ScoreModel(new List<string>(), -1);
            }

            var maxScore = await dbContext.Scorers.MaxAsync(i => i.Score, cancellationToken);

            var topScorerNames = await dbContext.Scorers
                .Where(s => s.Score == maxScore)
                .Select(s => s.FirstName + " " + s.SecondName)
                .OrderBy(s => s)
                .ToListAsync(cancellationToken);

            return new ScoreModel(topScorerNames, maxScore);
        }
    }
}
