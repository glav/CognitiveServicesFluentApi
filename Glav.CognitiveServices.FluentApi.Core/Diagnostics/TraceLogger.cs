using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Glav.CognitiveServices.FluentApi.Core.Diagnostics
{
    public class TraceLogger : IDiagnosticTrace
    {
        public TraceLogger()
        {
        }

        public void Log(string topic, string message, DiagnosticMessageType messageType)
        {
            var msg = FormLogMessage(topic, message, messageType);
            WriteToOutput(msg);
        }

        public void LogError(string topic, string message)
        {
            var msg = FormLogMessage(topic, message, DiagnosticMessageType.Error);
            WriteToOutput(msg);
        }

        public void LogError(string topic, Exception ex)
        {
            var exceptionDetails = ExtractDetailsFromException(ex);
            var msg = FormLogMessage(topic, exceptionDetails, DiagnosticMessageType.Error);
            WriteToOutput(msg);
        }

        private string ExtractDetailsFromException(Exception ex)
        {
            var builder = new StringBuilder();
            var aggregateEx = ex as AggregateException;
            if (aggregateEx != null)
            {
                if (aggregateEx.InnerExceptions != null)
                {
                    foreach (var inEx in aggregateEx.InnerExceptions)
                    {
                        AddExceptionDetailsToBuffer(builder, inEx);
                    }
                } else if (aggregateEx.InnerException != null)
                {
                    AddExceptionDetailsToBuffer(builder, aggregateEx.InnerException);
                }
            } else
            {
                var baseEx = ex.GetBaseException();
                builder.AppendFormat(" {0} - {1} - StackTrace: {2}", baseEx.Source, baseEx.Message, baseEx.StackTrace);
            }
            return builder.ToString();
        }

        private void AddExceptionDetailsToBuffer(StringBuilder buffer, Exception ex)
        {
            buffer.AppendFormat(" {0} - {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
        }

        private string FormLogMessage(string topic, string message, DiagnosticMessageType messageType)
        {
            return $"{DateTimeDescriptor()} <{messageType.ToString()}> #{topic}# - {message}";
        }

        private string DateTimeDescriptor()
        {
            return $"[{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.nnnn")} UTC]";
        }

        private void WriteToOutput(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
