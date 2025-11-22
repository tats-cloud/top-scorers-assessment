namespace Application.Models
{
    public class ScoreModel(List<string> fullNames, int score)
    {
        public List<string> FullNames { get; set; } = fullNames;
        public int Score { get; set; } = score;
    }
}
