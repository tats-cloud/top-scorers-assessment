using Application.Services;
using Microsoft.AspNetCore.Mvc;
using ScorerApi.Models;

namespace ScorerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoresController(IScoresService scoresService) : ControllerBase
    {
        private readonly IScoresService scoresService = scoresService;

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateScore([FromBody] CreateScoreRequest scoreRequest, CancellationToken cancellationToken)
        {
            var response = await scoresService.CreateScoreAsync(scoreRequest.ToApplicationModel(), cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        [Route("individual-score/{scoreId}")]
        public async Task<IActionResult> GetIndividualScore(int scoreId, CancellationToken cancellationToken)
        {
            var individualScore = await scoresService.GetIndividualScore(scoreId, cancellationToken);

            var response = IndividualScoreResponse.FromApplicationModel(individualScore);

            return Ok(response);
        }

        [HttpGet]
        [Route("top-scores")]
        public async Task<IActionResult> GetTopScores(CancellationToken cancellationToken)
        {
            var scores = await scoresService.GetTopScores(cancellationToken);

            var response = scores.Select(ScoreResponse.FromApplicationModel).ToList();

            return Ok(response);
        }
    }
}
