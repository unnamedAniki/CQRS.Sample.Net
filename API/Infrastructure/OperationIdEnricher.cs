using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;
using System;
using Serilog;
using Serilog.Configuration;

namespace Sample.API.Infrastructure
{
    // From https://oleh-zheleznyak.blogspot.com/2019/08/serilog-with-application-insights.html
    public class OperationIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var activity = Activity.Current;

            if (activity is null) return;

            logEvent.AddPropertyIfAbsent(new LogEventProperty("Operation Id", new ScalarValue(activity.Id)));
            logEvent.AddPropertyIfAbsent(new LogEventProperty("Parent Id", new ScalarValue(activity.ParentId)));
        }
    }

    public static class LoggingExtensions
    {
        public static LoggerConfiguration WithOperationId(this LoggerEnrichmentConfiguration enrichConfiguration)
        {
            if (enrichConfiguration is null) throw new ArgumentNullException(nameof(enrichConfiguration));

            return enrichConfiguration.With<OperationIdEnricher>();
        }
    }
}
