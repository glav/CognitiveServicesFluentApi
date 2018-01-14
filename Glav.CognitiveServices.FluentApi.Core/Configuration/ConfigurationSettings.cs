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
        private Dictionary<ApiActionCategory, string> _apiKeys = new Dictionary<ApiActionCategory, string>();
        private List<IDiagnosticLogger> _registeredDiagnosticLoggers = new List<IDiagnosticLogger>();
        private IDiagnosticLogger _diagnosticLogger;
        private LoggingLevel _logLevel = LoggingLevel.None;

        public ConfigurationSettings(ApiActionCategory apiCategory, string apiKey, LocationKeyIdentifier locationKey,
                    ApiServiceUriCollectionBase serviceUris)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new CognitiveServicesArgumentException("APIKey cannot be empty");
            }
            LocationKey = locationKey;
            _apiKeys.Add(apiCategory, apiKey);
            ServiceUris = serviceUris;
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, _logLevel);
            ScoringEngine = new DefaultScoreEvaluationEngine(new DefaultScoreLevels());
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            _apiKeys = settings.ApiKeys;
            this.LocationKey = settings.LocationKey;
            this.ServiceUris = settings.ServiceUris;
            this.LogLevel = settings.LogLevel;
            this.ScoringEngine = settings.ScoringEngine;
            this.RegisteredDiagnosticTraceLoggers = settings.RegisteredDiagnosticTraceLoggers;
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, _logLevel);
            ScoringEngine = new DefaultScoreEvaluationEngine(new DefaultScoreLevels());
        }

        public void RegisterDiagnosticLogger(IDiagnosticLogger logger)
        {
            _registeredDiagnosticLoggers.Add(logger);
            _diagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers,_logLevel);
        }

        public void SetScoringEngine(IScoreEvaluationEngine scoringEngine)
        {
            if (scoringEngine == null)
            {
                throw new CognitiveServicesArgumentException("ScoringEngine cannot be NULL");
            }

            this.ScoringEngine = scoringEngine;
        }

        public LoggingLevel LogLevel
        {
            get => _logLevel; set => _logLevel = value;
        }
        public IDiagnosticLogger DiagnosticLogger => _diagnosticLogger;

        public IEnumerable<IDiagnosticLogger> RegisteredDiagnosticTraceLoggers
        {
            get => _registeredDiagnosticLoggers;
            set => _registeredDiagnosticLoggers = value.ToList();
        }
        public Dictionary<ApiActionCategory, string> ApiKeys => _apiKeys;
        public LocationKeyIdentifier LocationKey { get; protected set; }
        public ApiServiceUriCollectionBase ServiceUris { get; protected set; }
        public string BaseUrl =>  string.Format(ApiServiceUriCollectionBase.BASE_URL_TEMPLATE, LocationKey.ToTextLocation());

        public IScoreEvaluationEngine ScoringEngine { get; protected set; }
    }
}
