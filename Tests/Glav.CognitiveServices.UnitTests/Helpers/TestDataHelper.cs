using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Glav.CognitiveServices.UnitTests.Helpers
{
    public class TestDataHelper
    {
        public string GetFileDataEmbeddedInAssembly(string filename)
        {
            var asm = this.GetType().GetTypeInfo().Assembly;
            using (var stream = asm.GetManifestResourceStream($"Glav.CognitiveServices.UnitTests.TestData.{filename}"))
            {
                using (var sr = new System.IO.StreamReader(stream))
                {
                     var testData = sr.ReadToEnd();
                    return testData;
                }
            }
        }
    }
}
