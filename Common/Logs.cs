using Serilog;

namespace GenAI_ImageGenerator.Common
{
    public static class Logs
    {
        public static void LogToFile(Exception ex, LogType logType)
        {
            string logFile = "";

            if (logType == LogType.Error)
                logFile = "errors/errors.txt";
            else if (logType == LogType.Warning)
                logFile = "warnings/warnings.txt";

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File($"logs/{logFile}", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            switch (logType)
            {
                case LogType.Error:
                    Log.Fatal(ex, ex.Message);
                    break;
                case LogType.Warning:
                    Log.Warning(ex, ex.Message);
                    break;
                default:
                    Log.Information(ex, ex.Message);
                    break;
            }

            Log.CloseAndFlush();
        }
    }
}
