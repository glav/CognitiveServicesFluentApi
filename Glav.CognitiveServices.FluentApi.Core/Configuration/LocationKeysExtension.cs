using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public static class LocationKeysExtension
    {
        private static Dictionary<LocationKeyIdentifier, string> _locationKeyText = new Dictionary<LocationKeyIdentifier, string>();
        static LocationKeysExtension()
        {
            _locationKeyText.Add(LocationKeyIdentifier.EastUs2, "eastus2");
            _locationKeyText.Add(LocationKeyIdentifier.SouthEastAsia, "southeastasia");
            _locationKeyText.Add(LocationKeyIdentifier.WestCentralUs, "westcentralus");
            _locationKeyText.Add(LocationKeyIdentifier.WestEurope, "westeurope");
            _locationKeyText.Add(LocationKeyIdentifier.WestUs, "westus");
        }

        public static string ToTextLocation(this LocationKeyIdentifier locationKey)
        {
            return _locationKeyText[locationKey];
        }
    }
}
