using System;
namespace CSVConverter.Converters
{
	public enum AvailableConverters
	{
		JSON
	}

	public interface Converter
	{
		public void Convert<TData>(TData data, string destPath);
	}
}

