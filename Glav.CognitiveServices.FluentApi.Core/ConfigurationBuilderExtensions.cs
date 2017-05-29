using Glav.CognitiveServices.FluentApi.Core.Communication;
using Glav.CognitiveServices.FluentApi.Core.Configuration;
using Glav.CognitiveServices.FluentApi.Core.Contracts;
using Glav.CognitiveServices.FluentApi.Core.Diagnostics;
using System.Threading.Tasks;

namespace Glav.CognitiveServices.FluentApi.Core
{
    public static class ConfigurationBuilderExtensions
    {
        public static CoreAnalysisSettings UsingHttpCommunication(this ConfigurationSettings configSettings)
        {
            configSettings.DiagnosticLogger.LogInfo("Communications", "Using HttpCommunication");

            return new CoreAnalysisSettings(configSettings, new HttpCommunicationEngine(configSettings));
        }

        public static CoreAnalysisSettings UsingCustomCommunication(this ConfigurationSettings configSettings, ICommunicationEngine communicationEngine)
        {
            configSettings.DiagnosticLogger.LogInfo("Communications", "Using custom communication");

            return new CoreAnalysisSettings(configSettings, communicationEngine);
        }

        public static ConfigurationSettings AddConsoleDiagnosticLogging(this ConfigurationSettings configSettings)
        {
            configSettings.RegisterDiagnosticLogger(new ConsoleLogger());
            return configSettings;
        }
        public static ConfigurationSettings AddCustomDiagnosticLogging(this ConfigurationSettings configSettings, IDiagnosticTraceLogger diagnosticLogger)
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
    }
}
