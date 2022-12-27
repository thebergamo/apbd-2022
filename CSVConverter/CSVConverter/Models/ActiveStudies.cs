using System;
using System.Text.Json.Serialization;

namespace CSVConverter.Models
{
    [Serializable]
    public class ActiveStudies
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("numberOfStudents")]
        public int NumberOfStudents { get; set; }

        public ActiveStudies(string name, int numberOfStudents)
        {
            Name = name;
            NumberOfStudents = numberOfStudents;
        }

        public override bool Equals(object? obj)
        {
            return obj is ActiveStudies studies &&
                   Name == studies.Name &&
                   NumberOfStudents == studies.NumberOfStudents;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, NumberOfStudents);
        }
    }
}

