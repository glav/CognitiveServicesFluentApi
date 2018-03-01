using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    [Flags]
    public enum ImageAnalysisVisualFeatures
    {
        Default = 0,   // Specify no features explicitly and just ask for a default analysis
        Categories = 1,//categorizes image content according to a taxonomy defined in documentation.
        Tags = 2,// - tags the image with a detailed list of words related to the image content.
        Description = 4,// - describes the image content with a complete English sentence.
        Faces = 8,// - detects if faces are present. If present, generate coordinates, gender and age.
        ImageType = 16,// - detects if image is clipart or a line drawing.
        Color = 32,// - determines the accent color, dominant color, and whether an image is black&white.
        Adult = 64
    }
}
