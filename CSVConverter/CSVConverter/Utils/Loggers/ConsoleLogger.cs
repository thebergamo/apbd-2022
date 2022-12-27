using System;
namespace CSVConverter.Utils
{
	public class ConsoleLogger : Logger
	{
		public ConsoleLogger()
		{
		}

        public void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{level} {message}");
        }
    }
}

