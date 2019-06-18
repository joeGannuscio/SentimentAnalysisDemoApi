namespace SentimentAnalysisDemoApi.Services
{
    public interface IPredictionService
    {
        string Predict(string inputText);
    }
}
