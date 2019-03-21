using Glav.CognitiveServices.FluentApi.Core.Contracts;
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
        private List<IDiagnosticLogger> _registeredDiagnosticLoggers = new List<IDiagnosticLogger>();
        private LoggingLevel _logLevel = LoggingLevel.ErrorsOnly;

        public ConfigurationSettings(string apiCategory, string apiKey, LocationKeyIdentifier locationKey,
                    ApiServiceUriCollectionBase serviceUris)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new CognitiveServicesArgumentException("APIKey cannot be empty");
            }
            this.MaxNumberOfRequestRetries = ApiConstants.DefaultMaxNumberOfRequestRetries;
            this.ApiCategory = apiCategory;
            this.LocationKey = locationKey;
            this.ApiKeys = new Dictionary<string, string>(1);
            this.ApiKeys.Add(apiCategory, apiKey);
            this.ServiceUris = serviceUris;
            this.DiagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, LogLevel);
            this.GlobalScoringEngine = new DefaultScoreEvaluationEngine(new DefaultScoreLevels());
        }

        public ConfigurationSettings(ConfigurationSettings settings)
        {
            this.ApiKeys = settings.ApiKeys;
            this.LocationKey = settings.LocationKey;
            this.ServiceUris = settings.ServiceUris;
            this.MaxNumberOfRequestRetries = settings.MaxNumberOfRequestRetries;
            this.LogLevel = settings.LogLevel;
            this.GlobalScoringEngine = settings.GlobalScoringEngine;
            this.RegisteredDiagnosticLoggers = settings.RegisteredDiagnosticLoggers;
            this.DiagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, LogLevel);
        }

        public void RegisterDiagnosticLogger(IDiagnosticLogger logger)
        {
            _registeredDiagnosticLoggers.Add(logger);
            DiagnosticLogger = new DiagnosticProxy(_registeredDiagnosticLoggers, LogLevel);
        }

        public int MaxNumberOfRequestRetries { get; private set; }
        public string ApiCategory { get; private set; }
        public void SetScoringEngine(IScoreEvaluationEngine scoringEngine)
        {
            this.GlobalScoringEngine = scoringEngine ?? throw new CognitiveServicesArgumentException("ScoringEngine cannot be NULL");
        }

        public void SetMaxRequestRetries(int maxRetries)
        {
            if (maxRetries > 0)
            {
                this.MaxNumberOfRequestRetries = maxRetries;
            }
        }


        public LoggingLevel LogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; this.DiagnosticLogger.SetLogLevel(_logLevel); }
        }
        public IDiagnosticLogger DiagnosticLogger { get; private set; }

        public IEnumerable<IDiagnosticLogger> RegisteredDiagnosticLoggers
        {
            get => _registeredDiagnosticLoggers;
            set => _registeredDiagnosticLoggers = value.ToList();
        }
        public Dictionary<string, string> ApiKeys { get; private set; }
        public LocationKeyIdentifier LocationKey { get; protected set; }
        public ApiServiceUriCollectionBase ServiceUris { get; protected set; }
        public string BaseUrl =>
            LocationKey != LocationKeyIdentifier.Global
                ? string.Format(ApiServiceUriCollectionBase.BASE_URL_TEMPLATE, $"{LocationKey.ToTextLocation()}.")
                : string.Format(ApiServiceUriCollectionBase.BASE_URL_TEMPLATE, string.Empty);

        public IScoreEvaluationEngine GlobalScoringEngine { get; protected set; }

        /// <summary>
        /// Constructs a complete absolute API Endpoint URL based on the API region, type and query parameters.
        /// </summary>
        /// <param name="actionItem"></param>
        /// <returns></returns>
        public string GetAbsoluteUrlForApiAction(IActionDataItem actionItem)
        {
            try
            {
                var svcConfig = ServiceUris.GetServiceConfig(actionItem.ApiDefintition);
                var queryParms = actionItem.ToUrlQueryParameters();
                var endUriFragment = actionItem.ToEndUriFragment();
                var url = string.Format("{0}{1}{2}{3}",
                        BaseUrl,
                        svcConfig.ServiceUri,
                        string.IsNullOrWhiteSpace(endUriFragment) ? string.Empty : endUriFragment,
                        string.IsNullOrWhiteSpace(queryParms) ? string.Empty : $"?{queryParms}");

                return url;
            }
            catch (Exception ex)
            {
                DiagnosticLogger.LogError(ex, "GetAbsoluteUrl");
                throw;
            }

        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"LocationKey: {this.LocationKey}");
            builder.AppendLine($"MaxNumberOfRequestRetries: {this.MaxNumberOfRequestRetries}");
            builder.AppendLine($"LogLevel: {this.LogLevel}");
            builder.AppendLine($"GlobalScoringEngine: {this.GlobalScoringEngine}");
            builder.AppendLine($"RegisteredDiagnosticLoggers:");
            this.RegisteredDiagnosticLoggers.ToList().ForEach(d =>
            {
                builder.AppendLine($"  Logger: {d}");
            });

            return builder.ToString();
        }
    }
}
