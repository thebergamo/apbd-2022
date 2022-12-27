using System;
using System.Text.Json.Serialization;

namespace CSVConverter.Models
{
	[Serializable]
	public class Studies
	{
        [JsonPropertyName("name")]
	    public string Name { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        public Studies(string name, string mode)
        {
            Name = name;
            Mode = mode;
        }

        public override bool Equals(object? obj)
        {
            return obj is Studies studies &&
                   Name == studies.Name &&
                   Mode == studies.Mode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Mode);
        }
    }
}

