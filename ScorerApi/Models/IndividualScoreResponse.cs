using Application.Models;

namespace ScorerApi.Models
{
    public class IndividualScoreResponse(int scoreId, int score)
    {
        public int ScoreId { get; set; } = scoreId;
        public int Score { get; set; } = score;

        public static IndividualScoreResponse FromApplicationModel(IndividualScoreModel individualScoreModel)
        {
            return new IndividualScoreResponse(individualScoreModel.ScoreId, individualScoreModel.Score);
        }
    }
}
