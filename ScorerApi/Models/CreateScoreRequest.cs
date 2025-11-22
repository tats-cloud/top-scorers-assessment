using Application.Models;

namespace ScorerApi.Models
{
    public class CreateScoreRequest(string firstName, string secondName, int score)
    {
        public string FirstName { get; set; } = firstName;
        public string SecondName { get; set; } = secondName;
        public int Score { get; set; } = score;

        public CreateScoreModel ToApplicationModel()
        {
            return new CreateScoreModel(FirstName, SecondName, Score);
        }
    }
}
