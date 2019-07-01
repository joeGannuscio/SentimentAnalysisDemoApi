using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisDemoApi.Services;
using SentimentAnalysisDemoApi.Models;
using Microsoft.AspNetCore.Cors;

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
        [EnableCors("MyPolicy")]
        public string PredictSentiment([FromBody] InputModel inputText)
        {
            return _predictionService.Predict(inputText.Input);
        }
    }
}