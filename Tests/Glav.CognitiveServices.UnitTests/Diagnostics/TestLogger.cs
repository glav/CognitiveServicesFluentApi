using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.CognitiveServices.UnitTests.Diagnostics
{
    public class TestLogger : IDiagnosticLogger
    {
        public int NumberOfLogErrorMessages { get; private set; }

        public int NumberOfLogErrorExceptions { get; private set; }
        public int NumberOfLogInfoMessages { get; private set; }
        public int NumberOfLogWarningMessages { get; private set; }

        public void LogError(string message, string topic = null)
        {
            NumberOfLogErrorMessages++;
        }

        public void LogError(Exception ex, string topic = null)
        {
            NumberOfLogErrorExceptions++;
        }

        public void LogInfo(string message, string topic = null)
        {
            NumberOfLogInfoMessages++;
        }

        public void LogWarning(string message, string topic = null)
        {
            NumberOfLogWarningMessages++;
        }
    }
}
