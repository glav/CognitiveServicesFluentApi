using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Configuration
{
    public abstract class ConfigurationSettings
    {
        private Dictionary<string, string> _apiKeys = new Dictionary<string, string>();
        private List<IDiagnosticLogger> _registeredDiagnosticLoggers = new List<IDiagnosticLogger>();
        private IDiagnosticLogger _diagnosticLogger;

        public ConfigurationSettings(string apiCategory, string apiKey, LocationKeyIdentifier locationKey,
                    ApiServiceUriCollectionBase serviceUris)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new CognitiveServicesArgumentException("APIKey cannot be empty");
            }
            this.ApiCategory = apiCategory;
            this.LocationKey = locationKey;
            _apiKeys.Add(apiCategory, apiKey);
            this.ServiceUris = serviceUris;
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, LogLevel);
            this.GlobalScoringEngine = new DefaultScoreEvaluationEngine(new DefaultScoreLevels());
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            _apiKeys = settings.ApiKeys;
            this.LocationKey = settings.LocationKey;
            this.ServiceUris = settings.ServiceUris;
            this.LogLevel = settings.LogLevel;
            this.GlobalScoringEngine = settings.GlobalScoringEngine;
            this.RegisteredDiagnosticTraceLoggers = settings.RegisteredDiagnosticTraceLoggers;
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, LogLevel);
        }

        public void RegisterDiagnosticLogger(IDiagnosticLogger logger)
        {
            _registeredDiagnosticLoggers.Add(logger);
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers,LogLevel);
        }

        public string ApiCategory { get; private set; }
        public void SetScoringEngine(IScoreEvaluationEngine scoringEngine)
        {
            this.GlobalScoringEngine = scoringEngine ?? throw new CognitiveServicesArgumentException("ScoringEngine cannot be NULL");
        }

        public LoggingLevel LogLevel { get; set; }
        public IDiagnosticLogger DiagnosticLogger => _diagnosticLogger;

        public IEnumerable<IDiagnosticLogger> RegisteredDiagnosticTraceLoggers
        {
            get => _registeredDiagnosticLoggers;
            set => _registeredDiagnosticLoggers = value.ToList();
        }
        public Dictionary<string, string> ApiKeys => _apiKeys;
        public LocationKeyIdentifier LocationKey { get; protected set; }
        public ApiServiceUriCollectionBase ServiceUris { get; protected set; }
        public string BaseUrl => 
            LocationKey != LocationKeyIdentifier.Global 
                ? string.Format(ApiServiceUriCollectionBase.BASE_URL_TEMPLATE, $"{LocationKey.ToTextLocation()}.") 
                : string.Format(ApiServiceUriCollectionBase.BASE_URL_TEMPLATE, string.Empty);

        public IScoreEvaluationEngine GlobalScoringEngine { get; protected set; }
    }
}
