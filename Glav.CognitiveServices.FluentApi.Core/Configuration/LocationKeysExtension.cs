using System.Collections.Generic;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public static class LocationKeysExtension
    {
        private static Dictionary<LocationKeyIdentifier, string> _locationKeyText = new Dictionary<LocationKeyIdentifier, string>();
        static LocationKeysExtension()
        {
            _locationKeyText.Add(LocationKeyIdentifier.AustraliaEast, "australiaeast");
            _locationKeyText.Add(LocationKeyIdentifier.AustraliaSouthEast, "australiasoutheast");
            _locationKeyText.Add(LocationKeyIdentifier.BrazilSouth, "brazilsouth");
            _locationKeyText.Add(LocationKeyIdentifier.EastUs, "eastus");
            _locationKeyText.Add(LocationKeyIdentifier.EastUs2, "eastus2");
            _locationKeyText.Add(LocationKeyIdentifier.SouthEastAsia, "southeastasia");
            _locationKeyText.Add(LocationKeyIdentifier.WestUs, "westus");
            _locationKeyText.Add(LocationKeyIdentifier.WestUs2, "westus2");
            _locationKeyText.Add(LocationKeyIdentifier.SouthCentralUs, "southcentralus");
            _locationKeyText.Add(LocationKeyIdentifier.WestCentralUs, "westcentralus");
            _locationKeyText.Add(LocationKeyIdentifier.EastAsia, "eastasia");
            _locationKeyText.Add(LocationKeyIdentifier.NorthEurope, "northeurope");
            _locationKeyText.Add(LocationKeyIdentifier.WestEurope, "westeurope");
            _locationKeyText.Add(LocationKeyIdentifier.Global, string.Empty);
        }

        public static string ToTextLocation(this LocationKeyIdentifier locationKey)
        {
            return _locationKeyText[locationKey];
        }
    }
}
