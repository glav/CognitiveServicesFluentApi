namespace Glav.CognitiveServices.FluentApi.Luis.Domain.ApiResponses
{
    public class LuisAppInstanceDataItem
    {
        public string type { get; set; }
        public string text { get; set; }
        public string startIndex { get; set; }
        public int length { get; set; }
        public double score { get; set; }
        public int modelTypeId { get; set; }
        public string modelType { get; set; }
        public string[] recognitionSources { get; set; }
    }


}