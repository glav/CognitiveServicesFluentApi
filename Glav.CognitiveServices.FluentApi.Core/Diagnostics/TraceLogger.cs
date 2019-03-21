using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public class TraceLogger : DiagnosticLoggerBase
    {

        public override void WriteToOutput(string msg)
        {
            System.Diagnostics.Trace.WriteLine(msg);
        }

    }
}
