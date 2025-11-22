using Application.Models;

namespace ScorerApi.Models
{
    public class ScoreResponse(List<string> fullNames, int score)
    {
        public List<string> FullNames { get; set; } = fullNames;
        public int Score { get; set; } = score;

        public static ScoreResponse FromApplicationModel(ScoreModel scoreModel)
        {
            return new ScoreResponse(scoreModel.FullNames, scoreModel.Score);
        }
    }
}
