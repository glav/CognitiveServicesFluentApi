using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    //public enum ApiActionType
    //{
    //    TextAnalyticsLanguages,
    //    TextAnalyticsSentiment,
    //    TextAnalyticsKeyphrases,
    //    TextAnalyticsOperationStatus,
    //    ComputerVisionImageAnalysis,
    //    ComputerVisionOcrAnalysis,
    //    ComputerVisionRecognizeText,
    //    FaceDetection,
    //    FaceLargePersonGroupCreate,
    //    FaceLargePersonGroupGet
    //}

    public abstract class ApiActionDefinition
    {
        public ApiActionDefinition()
        {

        }
        protected ApiActionDefinition(HttpMethod httpMethod, string apiCategory)//, ApiActionType actionType)
        {
            Method = httpMethod;
            Category = apiCategory;
            //ActionType = actionType;
        }
        public HttpMethod Method { get; private set; }
        public string Category { get; private set; }
        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public override bool Equals(object obj)
        {
            var definition = obj as ApiActionDefinition;
            return definition != null &&
                   EqualityComparer<HttpMethod>.Default.Equals(Method, definition.Method) &&
                   Category == definition.Category &&
                   obj.GetType().Name == definition.GetType().Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -343711391;
            hashCode = hashCode * -1521134295 + EqualityComparer<HttpMethod>.Default.GetHashCode(Method);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Category);
            return hashCode;
        }

        public static bool operator ==(ApiActionDefinition definition1, ApiActionDefinition definition2)
        {
            return EqualityComparer<ApiActionDefinition>.Default.Equals(definition1, definition2);
        }

        public static bool operator !=(ApiActionDefinition definition1, ApiActionDefinition definition2)
        {
            return !(definition1 == definition2);
        }
        //public ApiActionType ActionType { get; private set; }

    }


}
