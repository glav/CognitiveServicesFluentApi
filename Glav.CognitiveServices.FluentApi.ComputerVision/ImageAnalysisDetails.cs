using System;

namespace Glav.CognitiveServices.FluentApi.ComputerVision
{
    [Flags]
    public enum ImageAnalysisDetails
    {
        Default = 0,   // Specify no features explicitly and just ask for a default analysis
        Celebrities = 1,// - identifies celebrities if detected in the image.
        Landmarks = 2// - identifies landmarks if detected in the image.    
    }
}
