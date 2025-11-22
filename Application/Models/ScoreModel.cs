namespace Application.Models
{
    public class ScoreModel(string fullName, int score)
    {
        public string FullName { get; set; } = fullName;
        public int Score { get; set; } = score;
    }
}
