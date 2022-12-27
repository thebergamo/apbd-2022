using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using CSVConverter.Models;

namespace CSVConverter.Converters
{
	public class JSONConverter: Converter
	{
		public JSONConverter()
		{
		}

        public void Convert<TData>(TData data, string destPath)
        {
	        var options = new JsonSerializerOptions
	        {
		        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
		        WriteIndented = true
	        };
            string output = JsonSerializer.Serialize(data, options);
            File.WriteAllText(destPath, output);
        }
    }
}

