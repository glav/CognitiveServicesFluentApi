using System.Reflection;

namespace Glav.CognitiveServices.IntegrationTests.Helpers
{
    public class TestDataHelper
    {
        public byte[] GetFileDataEmbeddedInAssembly(string filename)
        {
            var asm = this.GetType().GetTypeInfo().Assembly;
            using (var stream = asm.GetManifestResourceStream($"Glav.CognitiveServices.IntegrationTests.TestData.{filename}"))
            {
                using (var sr = new System.IO.BinaryReader(stream))
                    using (var mem = new System.IO.MemoryStream())
                {
                    sr.BaseStream.CopyTo(mem);
                    return mem.ToArray();
                }
            }
        }
    }
}
