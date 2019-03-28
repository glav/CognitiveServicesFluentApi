using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public interface IDiagnosticLogger
    {
        Task LogInfoAsync(string message, string topic = null);
        Task LogWarningAsync(string message, string topic = null);
        Task LogErrorAsync(string message, string topic = null);
        Task LogErrorAsync(Exception ex, string topic = null);

        void SetLogLevel(LoggingLevel logLevel);
    }
}
