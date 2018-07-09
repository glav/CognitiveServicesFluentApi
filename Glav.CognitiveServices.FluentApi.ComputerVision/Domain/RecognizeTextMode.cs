using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain
{
    public enum RecognizeTextMode
    {
        Handwritten,
        Printed
    }

    public static class RecognizeTextModeExtensions
    {
        public static string ToUrlQueryArgument(this RecognizeTextMode mode)
        {
            return mode == RecognizeTextMode.Handwritten ? "Handwritten" : "Printed";
        }
    }
}
