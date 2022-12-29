using UniversityAPI.Models;

namespace UniversityAPI.Parsers;

// Copy of task 2 but simplified version
public class CSVParser
{
    public static List<Student> Parse(string filePath)
    {
        StreamReader stream = new StreamReader(filePath);
        List<Student> output = new();

        while (stream.ReadLine() is { } line)
        {
            // We assume database is consistent so duplications are handled in the Service layer
            output.Add(Student.Parse(line));
        }

        return output;
    }
}