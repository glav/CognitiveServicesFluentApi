using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using Glav.CognitiveServices.FluentApi.Core.ScoreEvaluation;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class ConfigurationBuilderExtensions
    {
        public static CoreAnalysisSettings UsingHttpCommunication(this ConfigurationSettings configSettings)
        {
            configSettings.DiagnosticLogger.LogInfo("Using HttpCommunication","Communications");

            return new CoreAnalysisSettings(configSettings, new HttpCommunicationEngine(configSettings));
        }

        public static CoreAnalysisSettings UsingCustomCommunication(this ConfigurationSettings configSettings, ICommunicationEngine communicationEngine)
        {
            configSettings.DiagnosticLogger.LogInfo("Using custom communication","Communications");

            return new CoreAnalysisSettings(configSettings, communicationEngine);
        }

        public static ConfigurationSettings AddConsoleDiagnosticLogging(this ConfigurationSettings configSettings)
        {
            configSettings.RegisterDiagnosticLogger(new ConsoleLogger());
            return configSettings;
        }
        public static ConfigurationSettings AddCustomDiagnosticLogging(this ConfigurationSettings configSettings, IDiagnosticLogger diagnosticLogger)
        {
            configSettings.RegisterDiagnosticLogger(diagnosticLogger);
            return configSettings;
        }
        public static ConfigurationSettings AddDebugDiagnosticLogging(this ConfigurationSettings configSettings)
        {
            configSettings.RegisterDiagnosticLogger(new DebugLogger());
            return configSettings;
        }
        public static ConfigurationSettings SetDiagnosticLoggingLevel(this ConfigurationSettings configSettings, LoggingLevel logLevel)
        {
            configSettings.LogLevel = logLevel;
            return configSettings;
        }

        public static ConfigurationSettings UsingDefaultScoringEngineAndScoreLevels(this ConfigurationSettings configSettings)
        {
            configSettings.SetScoringEngine(new DefaultScoreEvaluationEngine(new DefaultScoreLevels()));
            return configSettings;
        }

        public static ConfigurationSettings UsingCustomScoringEngine(this ConfigurationSettings configSettings, IScoreEvaluationEngine scoringEngine)
        {
            configSettings.SetScoringEngine(scoringEngine);
            return configSettings;
        }

        public static ConfigurationSettings UsingDefaultScoringEngineWithCustomScoreLevels(this ConfigurationSettings configSettings, IScoreLevelBoundsCollection scoreLevels)
        {
            configSettings.SetScoringEngine(new DefaultScoreEvaluationEngine(scoreLevels));
            return configSettings;
        }

    }
}
