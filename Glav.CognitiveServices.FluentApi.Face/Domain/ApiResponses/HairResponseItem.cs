namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class HairResponseItem
    {
        public double bald { get; set; }
        public HairColorResponseItem[] hairColor { get; set; }
        public bool invisible { get; set; }
    }

}
