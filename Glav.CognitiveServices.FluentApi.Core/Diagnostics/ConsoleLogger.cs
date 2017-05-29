using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public class ConsoleLogger : DiagnosticLoggerBase
    {

        public override void WriteToOutput(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
