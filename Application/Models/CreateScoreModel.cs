namespace Application.Models
{
    public class CreateScoreModel(string firstName, string secondName, int score)
    {
        public string FirstName { get; set; } = firstName;
        public string SecondName { get; set; } = secondName;
        public int Score { get; set; } = score;
    }
}
