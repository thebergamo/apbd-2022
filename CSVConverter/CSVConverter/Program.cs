using CSVConverter.Utils;
using CSVConverter.Parsers;
using CSVConverter.Models;
using CSVConverter.Converters;

namespace CSVConverter {

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            FileLogger fileLogger = new FileLogger(@"log.txt", LogLevel.ERROR);
            DefaultLogger.InitializeLoggers(new List<Logger>() { consoleLogger, fileLogger });
            Logger logger = DefaultLogger.Instance;

            try
            {
                Arguments arguments = Arguments.Parser(args);

                HashSet<Student> students = CSVParser<Student, HashSet<Student>>.Parse(arguments.CsvPath);
                HashSet<ActiveStudies> activeStudies = students
                    .Select((student) => student.Studies)
                    .GroupBy(studies => studies.Name)
                    .Select(studies => new ActiveStudies(studies.Key, studies.Count()))
                    .ToHashSet();

                University university = new University(
                    DateTime.Now.ToString("MM.dd.yyyy"),
                    Environment.UserName,
                    students,
                    activeStudies
                );

                ConverterManager converter = ConverterManager.Instance;
                // INFO: Adding to a dictionary to keep format: { "university": {...} }
                Dictionary<string, University> dictUniversity = new(); 
                dictUniversity.Add("university", university);

                converter.Convert(dictUniversity, arguments.DestPath, arguments.Format);

                logger.Info("Processing finished");

            } catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }

}