using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.ComputerVision.Domain.ApiResponses
{
    public class CategoriesResponseItem
    {
        public string name { get; set; }
        public double score { get; set; }

        public CategoriesDetailResponseItem detail { get; set; }
    }

    public class CategoriesDetailCelebritiesResponseItem : NameConfidenceResponseItem
    {
        public FaceRectangleResponseItem faceRectangle { get; set; }
    }

    public class CategoriesDetailResponseItem
    {
        public CategoriesDetailCelebritiesResponseItem[] celebrities { get; set; }
        public NameConfidenceResponseItem[] landmarks { get; set; }
    }


}
