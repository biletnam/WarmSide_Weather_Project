using System;
using Serilog;

namespace LoggingService.WCFService
{
    public class WCFLogger : IWCFLogger
    {
        public bool Log(string message)
        {
            var logToConsole = new LoggerConfiguration().WriteTo.LiterateConsole(Serilog.Events.LogEventLevel.Information).CreateLogger();
            var logToFile = new LoggerConfiguration().ReadFrom.AppSettings().WriteTo.File("").CreateLogger();
            logToConsole.Information(message);
            logToFile.Information(message);
            return false;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
