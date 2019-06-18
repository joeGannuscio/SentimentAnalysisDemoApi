namespace SentimentAnalysisDemoApi.Services
{
    interface IPredictionService
    {
        string Predict(string inputText);
    }
}
