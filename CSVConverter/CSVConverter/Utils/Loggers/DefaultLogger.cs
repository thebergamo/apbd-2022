using System;
namespace CSVConverter.Utils
{
	public class DefaultLogger : Logger
	{
		private List<Logger> Loggers { get; }

		private static DefaultLogger? _Instance = null;

		public static DefaultLogger Instance
		{
			get {
				if (_Instance == null)
				{
					throw new Exception("Cannot get instance before Loggers are initialized. Please Initialize Loggers first.");
				}

				return _Instance;
			}
		}

		public static void InitializeLoggers(List<Logger> loggers)
		{
            _Instance = new DefaultLogger(loggers);
		}

		private DefaultLogger(List<Logger> loggers)
		{
			Loggers = loggers;
		}

        public void Log(LogLevel level, string message)
        {
            foreach (var logger in Loggers)
			{
				logger.Log(level, message);
			}
        }

    }
}

