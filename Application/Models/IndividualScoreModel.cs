namespace Application.Models
{
    public class IndividualScoreModel(int scoreId, int score)
    {
        public int ScoreId { get; set; } = scoreId;
        public int Score { get; set; } = score;
    }
}
