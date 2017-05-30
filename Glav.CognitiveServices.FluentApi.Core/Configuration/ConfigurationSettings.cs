using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class ConfigurationSettings
    {
        private Dictionary<ApiActionCategory, string> _apiKeys = new Dictionary<ApiActionCategory, string>();
        private List<IDiagnosticTraceLogger> _registeredDiagnosticLoggers = new List<IDiagnosticTraceLogger>();
        private IDiagnosticTraceLogger _diagnosticLogger;
        private LoggingLevel _logLevel = LoggingLevel.None;

        protected ConfigurationSettings()
        {

        }

        public ConfigurationSettings(ApiActionCategory apiCategory, string apiKey, LocationKeyIdentifier locationKey,
                    ApiServiceUriCollectionBase serviceUris)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("APIKey cannot be empty");
            }
            LocationKey = locationKey;
            _apiKeys.Add(apiCategory, apiKey);
            ServiceUris = serviceUris;
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, _logLevel);
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            _apiKeys = settings.ApiKeys;
            this.LocationKey = settings.LocationKey;
            this.ServiceUris = settings.ServiceUris;
            this.LogLevel = settings.LogLevel;
            this.RegisteredDiagnosticTraceLoggers = settings.RegisteredDiagnosticTraceLoggers;
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, _logLevel);
        }

        public void RegisterDiagnosticLogger(IDiagnosticTraceLogger logger)
        {
            _registeredDiagnosticLoggers.Add(logger);
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers,_logLevel);
        }

        public LoggingLevel LogLevel
        {
            get => _logLevel; set => _logLevel = value;
        }
        public IDiagnosticTraceLogger DiagnosticLogger
        {
            get
            {
                return _diagnosticLogger;
            }
        }
        public IEnumerable<IDiagnosticTraceLogger> RegisteredDiagnosticTraceLoggers
        {
            get
            {
                return _registeredDiagnosticLoggers;
            }
            set => _registeredDiagnosticLoggers = value.ToList();
        }
        public Dictionary<ApiActionCategory, string> ApiKeys => _apiKeys;
        public LocationKeyIdentifier LocationKey { get; protected set; }
        public ApiServiceUriCollectionBase ServiceUris { get; protected set; }
        public string BaseUrl
        {
            get
            {
                return string.Format(ApiServiceUriCollectionBase.BASE_URL_TEMPLATE, LocationKey.ToTextLocation());
            }
        }
    }
}
