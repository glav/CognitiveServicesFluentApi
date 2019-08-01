using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public class DiagnosticProxy : IDiagnosticLogger
    {
        private readonly List<IDiagnosticLogger> _loggers;
        private LoggingLevel _logLevel;

        public DiagnosticProxy(IEnumerable<IDiagnosticLogger> loggers, LoggingLevel logLevel)
        {
            _loggers = loggers != null ? loggers.ToList() : new List<IDiagnosticLogger>();
            _logLevel = logLevel;
        }

        public void SetLogLevel(LoggingLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public async Task LogErrorAsync(string message, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.ErrorsOnly)
            {
                foreach (var logger in _loggers)
                {
                    await logger.LogErrorAsync(message, topic);
                }
            }
        }

        public async Task LogErrorAsync(Exception ex, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.ErrorsOnly)
            {
                foreach (var logger in _loggers)
                {
                    await logger.LogErrorAsync(ex, topic);
                }
            }
        }

        public async Task LogInfoAsync(string message, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.Everything)
            {
                foreach (var logger in _loggers)
                {
                    await logger.LogInfoAsync(message, topic);
                }
            }
        }

        public async Task LogWarningAsync(string message, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.WarningsAndErrors)
            {
                foreach (var logger in _loggers)
                {
                    await logger.LogWarningAsync(message, topic);
                }
            }
        }

 
    }
}
