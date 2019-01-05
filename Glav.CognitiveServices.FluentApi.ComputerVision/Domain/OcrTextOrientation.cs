using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public enum OcrTextOrientation
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class OcrTextrientationExtensions
    {
        public static OcrTextOrientation ParseOrientation(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            var normalised = value.ToLowerInvariant();
            switch (normalised)
            {
                case "up":
                    return OcrTextOrientation.Up;
                case "down":
                    return OcrTextOrientation.Down;
                case "left":
                    return OcrTextOrientation.Left;
                case "right":
                    return OcrTextOrientation.Right;
            }
            throw new NotSupportedException($"Orientation value of [{value}] not suppored");
        }
    }
}
