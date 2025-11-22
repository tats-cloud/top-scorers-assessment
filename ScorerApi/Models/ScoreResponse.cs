using Application.Models;

namespace ScorerApi.Models
{
    public class ScoreResponse(string fullName, int score)
    {
        public string FullName { get; set; } = fullName;
        public int Score { get; set; } = score;

        public static ScoreResponse FromApplicationModel(ScoreModel scoreModel)
        {
            return new ScoreResponse(scoreModel.FullName, scoreModel.Score);
        }
    }
}
