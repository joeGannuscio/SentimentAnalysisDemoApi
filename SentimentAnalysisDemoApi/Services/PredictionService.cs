using Microsoft.ML;
using SentimentAnalysisDemoApi.Models;
using System;

namespace SentimentAnalysisDemoApi.Services
{
    public class PredictionService : IPredictionService
    {

        private PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;

        public PredictionService()
        {
            var mlContext = new MLContext();
            var loadedModel = mlContext.Model.Load(@"TrainedModel\SentimentAnalysisDemoModel.zip", out var modelSchema);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(loadedModel);
        }

        public string Predict(string inputText)
        {
            var predictionInput = new SentimentData { Text = inputText };
            var predictionValue = _predictionEngine.Predict(predictionInput);
            return Convert.ToBoolean(predictionValue.Prediction) ? "Negative" : "Positive";
        }
    }
}
