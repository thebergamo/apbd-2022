using System;
namespace CSVConverter.Utils
{
    public enum LogLevel
    {
        INFO,
        ERROR,
        DEBUG
    }

    public interface Logger
	{
        public void Error(string message)
        {
            Log(LogLevel.ERROR, message);
        }

        public void Info(string message)
        {
            Log(LogLevel.INFO, message);
        }

        public void Debug(string message)
        {
            Log(LogLevel.DEBUG, message);
        }

        public void Log(LogLevel level, string message) { }
	}
}