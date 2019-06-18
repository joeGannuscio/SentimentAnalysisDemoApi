using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisDemoApi.Services;

namespace SentimentAnalysisDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly IPredictionService _predictionService;

        public PredictionController(IPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [HttpPost]
        public string PredictSentiment([FromBody] string inputText)
        {
            return _predictionService.Predict(inputText);
        }
    }
}