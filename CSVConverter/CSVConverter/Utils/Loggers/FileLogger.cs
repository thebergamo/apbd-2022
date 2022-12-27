using System;
namespace CSVConverter.Utils
{
    

    public class FileLogger: Logger
    {
        private LogLevel ReportLogLevel;
        private string LogFile;

        public FileLogger(string logFile, LogLevel logLevel)
        {
            LogFile = logFile;
            ReportLogLevel = logLevel;

            File.WriteAllText(logFile, "");
        }

        public void Log(LogLevel level, string message)
        {
            if (ReportLogLevel == level)
            {
                File.AppendAllText(LogFile, $"{DateTime.Now.ToString("u").Replace(' ', 'T')} {level} {message}{Environment.NewLine}");
            }
        }
    }
}

