
namespace Glav.CognitiveServices.FluentApi.TextAnalytic.Domain.ApiResponses
{
    public sealed class LanguagesResultResponseItem
    {
        public long id { get; set; }
        public DetectedLanguage detectedLanguage { get; set; }

    }

    public sealed class DetectedLanguage
    {
        public string name { get; set; }
        public string iso6391name { get; set; }
        public double confidenceScore { get; set; }
    }

}
