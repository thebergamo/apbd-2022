using System;
using System.Text.Json.Serialization;
using CSVConverter.Parsers;
using CSVConverter.Exceptions;

namespace CSVConverter.Models
{
    public class Student: Parser<string, Student>
    {
        [JsonPropertyName("indexNumber")]
        public string IndexNumber { get; set; }

        [JsonPropertyName("fname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lname")]
        public string LastName { get; set; }

        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("mothersName")]
        public string MotherName { get; set; }

        [JsonPropertyName("fathersName")]
        public string FatherName { get; set; }

        [JsonPropertyName("studies")]
        public Studies Studies { get; set; }

        public Student(string indexNumber, string firstName, string lastName, string birthdate, string email, string motherName, string fatherName, Studies studies)
        {
            IndexNumber = indexNumber;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Email = email;
            MotherName = motherName;
            FatherName = fatherName;
            Studies = studies;
        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   IndexNumber == student.IndexNumber &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IndexNumber, FirstName, LastName);
        }
        
        public override string ToString()
        {
            return $"name: {FirstName} , surname: {LastName}, index: {IndexNumber} " ;
        }

        public static Student Parse(string input)
        {
            string[] studentRecordArray = input.Trim().Split(",");

            if (studentRecordArray.Length != 9 || studentRecordArray.Any(string.IsNullOrEmpty))
            {
                throw new CorruptedStudentRecordException(input);
            }

            return new Student(
                studentRecordArray[4],
                studentRecordArray[0],
                studentRecordArray[1],
                studentRecordArray[5],
                studentRecordArray[6],
                studentRecordArray[7],
                studentRecordArray[8],
                new Studies(studentRecordArray[2], studentRecordArray[3])
            );
        }
    }
}

