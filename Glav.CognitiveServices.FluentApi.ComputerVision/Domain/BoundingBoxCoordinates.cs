using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public class BoundingBoxCoordinates
    {
        public int XTopLeft { get; set; }
        public int YTopLeft { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static BoundingBoxCoordinates Parse(string boundingBoxData)
        {
            var coordinates = new BoundingBoxCoordinates();
            if (string.IsNullOrWhiteSpace(boundingBoxData))
            {
                return coordinates;
            }
            var components = boundingBoxData.Split(new char[] { ',' });
            if (components == null || components.Length != 4)
            {
                return coordinates;
            }
            coordinates.XTopLeft = SafeConvert(components[0]);
            coordinates.YTopLeft = SafeConvert(components[1]);
            coordinates.Width = SafeConvert(components[2]);
            coordinates.Height = SafeConvert(components[3]);
            return coordinates;
        }

        private static int SafeConvert(string value)
        {
            int number;
            if (int.TryParse(value,out number))
            {
                return number;
            }
            return 0;
        }
    }
}
