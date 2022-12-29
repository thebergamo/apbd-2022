namespace UniversityAPI.Models;

public class Studies
{
        public string Name { get; set; }
        public string Mode { get; set; }

        public Studies(string name, string mode)
        {
                Name = name;
                Mode = mode;
        }
}