using System;
using CSVConverter.Converters;

namespace CSVConverter.Utils
{
    public class Arguments
    {
        private static Logger logger = DefaultLogger.Instance;
        public string CsvPath { get; }
        public string DestPath { get; }
        public AvailableConverters Format { get;  }

        public static Arguments Parser(string[] args) {
            string csvPath = args.Length > 1 ? args[0] : @"data.csv";
            string destPath = args.Length > 2 ? args[1] : @"result.json";
            string rawFormat = args.Length > 3 ? args[2] : AvailableConverters.JSON.ToString();
            AvailableConverters format = AvailableConverters.JSON;

            if (!Enum.IsDefined(typeof(AvailableConverters), rawFormat.ToUpper()))
            {
                throw new ArgumentException($"{rawFormat} is not supported, please choose a supported format: {Enum.GetValues<AvailableConverters>()}");
            } else
            {
                Enum.TryParse(rawFormat, out format);
            }

            
            if (!File.Exists(csvPath))
            {
                throw new FileNotFoundException("Input csv file does not exist.");
            }

            if (File.Exists(destPath))
            {
                logger.Info("Destination file already exist and it's current value will overriden.");
            }

            return new Arguments(csvPath, destPath, format);
        }

        private Arguments(string csvPath, string destPath, AvailableConverters format)
        {
            CsvPath = csvPath;
            DestPath = destPath;
            Format = format;
        }
    }
}

