namespace Glav.CognitiveServices.FluentApi.Face.Domain.ApiResponses
{
    public class FaceRectangle
    {
        public double left { get; set; }
        public double top { get; set; }
        public double width { get; set; }
        public double height { get; set; }

        public override string ToString()
        {
            return $"{left},{top},{width},{height}";
        }
    }

}
