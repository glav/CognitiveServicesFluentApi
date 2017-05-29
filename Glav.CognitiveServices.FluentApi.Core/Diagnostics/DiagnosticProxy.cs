using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public class DiagnosticProxy : IDiagnosticTraceLogger
    {
        private readonly List<IDiagnosticTraceLogger> _loggers;
        private readonly LoggingLevel _logLevel;

        public DiagnosticProxy(IEnumerable<IDiagnosticTraceLogger> loggers, LoggingLevel logLevel)
        {
            _loggers = loggers != null ? loggers.ToList() : new List<IDiagnosticTraceLogger>();
            _logLevel = logLevel;
        }

        public void LogError(string message, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.ErrorsOnly)
            {
                _loggers.ForEach(l => l.LogError(message, topic));
            }
        }

        public void LogError(Exception ex, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.ErrorsOnly)
            {
                _loggers.ForEach(l => l.LogError(ex, topic));
            }
        }

        public void LogInfo(string message, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.ErrorsOnly)
            {
                _loggers.ForEach(l => l.LogInfo(message, topic));
            }
        }

        public void LogWarning(string message, string topic = null)
        {
            if ((int)_logLevel >= (int)LoggingLevel.WarningsAndErrors)
            {
                _loggers.ForEach(l => l.LogWarning(message, topic));
            }
        }
    }
}
