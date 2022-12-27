using System;
using CSVConverter.Exceptions;
using CSVConverter.Utils;

namespace CSVConverter.Parsers
{
    public class CSVParser<TOutputItem, TOutput>: Parser<string, TOutput>
        where TOutputItem: Parser<string, TOutputItem>
        where TOutput: ICollection<TOutputItem>, new()
    {
        private static Logger logger = DefaultLogger.Instance;

        public static TOutput Parse(string filePath)
        {
            StreamReader stream = new StreamReader(filePath);
            TOutput output = new();

            while(stream.ReadLine() is { } line)
            {
                try
                {
                    TOutputItem item = TOutputItem.Parse(line);
                    if (!output.Contains(item))
                    {
                        output.Add(item);
                    } else
                    {
                        throw new DuplicatedRecordException<TOutputItem>(item);
                    }
                } catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
            }

            return output;
        }
    }
}

