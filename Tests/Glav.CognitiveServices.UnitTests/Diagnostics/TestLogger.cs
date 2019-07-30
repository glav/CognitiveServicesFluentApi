using Glav.CognitiveServices.FluentApi.Core;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.UnitTests.Diagnostics
{
    public class TestLogger : IDiagnosticLogger
    {
        public int NumberOfLogErrorMessages { get; private set; }

        public int NumberOfLogErrorExceptions { get; private set; }
        public int NumberOfLogInfoMessages { get; private set; }
        public int NumberOfLogWarningMessages { get; private set; }

        public Task LogErrorAsync(string message, string topic = null)
        {
            NumberOfLogErrorMessages++;
            return Task.FromResult(0);
        }

        public Task LogErrorAsync(Exception ex, string topic = null)
        {
            NumberOfLogErrorExceptions++;
            return Task.FromResult(0);
        }

        public Task LogInfoAsync(string message, string topic = null)
        {
            NumberOfLogInfoMessages++;
            return Task.FromResult(0);
        }

        public Task LogWarningAsync(string message, string topic = null)
        {
            NumberOfLogWarningMessages++;
            return Task.FromResult(0);
        }

        public void SetLogLevel(LoggingLevel logLevel)
        {
            
        }
    }
}
