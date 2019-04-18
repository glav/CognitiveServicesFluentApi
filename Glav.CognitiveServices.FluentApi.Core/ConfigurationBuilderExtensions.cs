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
             return new CoreAnalysisSettings(configSettings, new HttpCommunicationEngine(configSettings));
        }

        public static CoreAnalysisSettings UsingCustomCommunication(this ConfigurationSettings configSettings, ICommunicationEngine communicationEngine)
        {
            return new CoreAnalysisSettings(configSettings, communicationEngine);
        }
        public static ConfigurationSettings AddConsoleDiagnosticLogging(this ConfigurationSettings configSettings)
        {
            configSettings.RegisterDiagnosticLogger(new ConsoleLogger());
            return configSettings;
        }

        /// <summary>
        /// Registers a custom diagnostic logger that implements the <see cref="IDiagnosticLogger"/> interface
        /// </summary>
        /// <param name="configSettings"></param>
        /// <param name="diagnosticLogger"></param>
        /// <returns></returns>
        public static ConfigurationSettings AddCustomDiagnosticLogging(this ConfigurationSettings configSettings, IDiagnosticLogger diagnosticLogger)
        {
            configSettings.RegisterDiagnosticLogger(diagnosticLogger);
            return configSettings;
        }

        /// <summary>
        /// Registers a System.Diagnostics.Debug diagnostic logger.
        /// </summary>
        /// <param name="configSettings"></param>
        /// <returns></returns>
        public static ConfigurationSettings AddDebugDiagnosticLogging(this ConfigurationSettings configSettings)
        {
            configSettings.RegisterDiagnosticLogger(new DebugLogger());
            return configSettings;
        }

        /// <summary>
        /// Registers a System.Diagnostics.Trace diagnostic logger.
        /// </summary>
        /// <param name="configSettings"></param>
        /// <returns></returns>
        public static ConfigurationSettings AddTraceDiagnosticLogging(this ConfigurationSettings configSettings)
        {
            configSettings.RegisterDiagnosticLogger(new TraceLogger());
            return configSettings;
        }

        /// <summary>
        /// Sets the level of diagnostic logging
        /// </summary>
        /// <param name="configSettings"></param>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public static ConfigurationSettings SetDiagnosticLoggingLevel(this ConfigurationSettings configSettings, LoggingLevel logLevel)
        {
            configSettings.LogLevel = logLevel;
            return configSettings;
        }

        /// <summary>
        /// Registers all the console and System.Diagnostics.Trace logging types. 
        /// This is NOT recommended for production since it registers multiple logging mechanisms.
        /// </summary>
        /// <remarks>DO NOT use this in production</remarks>
        /// <param name="configSettings"></param>
        /// <returns></returns>
        public static ConfigurationSettings AddConsoleAndTraceLogging(this ConfigurationSettings configSettings)
        {
            configSettings.AddConsoleDiagnosticLogging();
            configSettings.AddTraceDiagnosticLogging();
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

        /// <summary>
        /// Sets the maximum number of retries for any request issued if a Rate limit has been exceeded. The service will return how
        /// long to wait if the request rate has been exceeded however this number determines the number of times it will attempt to retry
        /// before abandoning the process.
        /// </summary>
        /// <param name="configSettings"></param>
        /// <param name="maxRetries"></param>
        /// <returns></returns>
        public static ConfigurationSettings UsingMaximumRequestRetries(this ConfigurationSettings configSettings, int maxRetries)
        {
            configSettings.SetMaxRequestRetries(maxRetries);
            return configSettings;
        }


    }
}
