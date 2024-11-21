using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class SentimentAnalysisService
    {
        public string AnalyzeSentiment(string text)
        {
            var words = text.ToLower().Split(' ');
            var positiveWords = new[] { "good", "great", "excellent", "amazing", "love", "like" };
            var negativeWords = new[] { "bad", "poor", "terrible", "hate", "dislike" };

            int positiveCount = words.Count(w => positiveWords.Contains(w));
            int negativeCount = words.Count(w => negativeWords.Contains(w));

            if (positiveCount > negativeCount)
                return "Positive";
            else if (negativeCount > positiveCount)
                return "Negative";
            else
                return "Neutral";
        }
    }
}