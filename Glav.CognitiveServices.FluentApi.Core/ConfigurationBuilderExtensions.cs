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

        /// <summary>
        /// Sets the global scoring engine to the default. This scoring engine is then propagated to all engine contexts unless a 
        /// different scoring engine is specified for that context
        /// </summary>
        /// <param name="configSettings"></param>
        /// <returns></returns>
        public static ConfigurationSettings UsingDefaultGlobalScoringEngineAndScoreLevels(this ConfigurationSettings configSettings)
        {
            configSettings.SetScoringEngine(new DefaultScoreEvaluationEngine(new DefaultScoreLevels()));
            return configSettings;
        }

        /// <summary>
        /// Sets the global scoring engine to a custom implementation. This scoring engine is then propagated to all engine contexts unless a 
        /// different scoring engine is specified for that context
        /// </summary>
        /// <param name="configSettings"></param>
        /// <param name="scoringEngine"></param>
        /// <returns></returns>
        public static ConfigurationSettings UsingCustomGlobalScoringEngine(this ConfigurationSettings configSettings, IScoreEvaluationEngine scoringEngine)
        {
            configSettings.SetScoringEngine(scoringEngine);
            return configSettings;
        }

        /// <summary>
        /// Sets the global scoring engine to the default engine but with custom score levels specified. This scoring engine is then 
        /// propagated to all engine contexts unless a different scoring engine is specified for that context
        /// </summary>
        /// <param name="configSettings"></param>
        /// <param name="scoreLevels"></param>
        /// <returns></returns>
        public static ConfigurationSettings UsingDefaultGlobalScoringEngineWithCustomScoreLevels(this ConfigurationSettings configSettings, IScoreLevelBoundsCollection scoreLevels)
        {
            configSettings.SetScoringEngine(new DefaultScoreEvaluationEngine(scoreLevels));
            return configSettings;
        }

    }
}
