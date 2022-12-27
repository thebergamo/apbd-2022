using System;
using System.Text.Json.Serialization;

namespace CSVConverter.Models
{
	[Serializable]
	public class University
	{
		[JsonPropertyName("createdAt")]
		public string CreatedAt { get; set; }

		[JsonPropertyName("author")]
		public string Author { get; set; }

		[JsonPropertyName("students")]
		public ISet<Student> Students { get; set; }

		[JsonPropertyName("activeStudies")]
		public ISet<ActiveStudies> ActiveStudies { get; set; }

        public University(string createdAt, string author, ISet<Student> students, ISet<ActiveStudies> activeStudies)
        {
            CreatedAt = createdAt;
            Author = author;
            Students = students;
            ActiveStudies = activeStudies;
        }

        public override bool Equals(object? obj)
        {
            return obj is University university &&
                   CreatedAt == university.CreatedAt &&
                   Author == university.Author &&
                   EqualityComparer<ISet<Student>>.Default.Equals(Students, university.Students) &&
                   EqualityComparer<ISet<ActiveStudies>>.Default.Equals(ActiveStudies, university.ActiveStudies);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CreatedAt, Author, Students, ActiveStudies);
        }
    }
}

