using System.Globalization;
using System.Text;
using UniversityAPI.Exceptions;

namespace UniversityAPI.Models;

public class Student
{

    private static readonly string BirthdateFormat = "M/dd/yyyy";

    public string IndexNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public Studies Studies { get; set; }
    public string Email { get; set; }
    public string FathersName { get; set; }
    public string MothersName { get; set; }

    public Student(string indexNumber, string firstName, string lastName, DateOnly birthdate,
        string email, string fathersName, string mothersName, Studies studies)
    {
        IndexNumber = indexNumber;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Studies = studies;
        Email = email;
        FathersName = fathersName;
        MothersName = mothersName;
    }


    public static Student Parse(string input)
    {
        string[] studentRecordArray = input.Trim().Split(",");

        if (studentRecordArray.Length != 9 || studentRecordArray.Any(string.IsNullOrEmpty))
        {
            throw new CorruptedStudentRecordException(input);
        }

        return new Student(
            studentRecordArray[2],
            studentRecordArray[0],
            studentRecordArray[1],
            DateOnly.FromDateTime(DateTime.ParseExact(studentRecordArray[3], BirthdateFormat, null, DateTimeStyles.None)),
            studentRecordArray[6],
            studentRecordArray[7],
            studentRecordArray[8],
            new Studies(studentRecordArray[4], studentRecordArray[5])
        );
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string[] record = new[]
        {
            FirstName,
            LastName,
            IndexNumber,
            Birthdate.ToString(BirthdateFormat),
            Studies.Name,
            Studies.Mode,
            Email,
            FathersName,
            MothersName
        };

        return sb.AppendJoin(",", record).ToString();
    }
}