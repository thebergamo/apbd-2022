using System;
namespace CSVConverter.Converters
{
	public class ConverterManager
	{
		private Dictionary<AvailableConverters, Converter> converters = new();

		private static ConverterManager? _Instance = null;


        public static ConverterManager Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new ConverterManager();
				}

				return _Instance;
			}
		}

        private ConverterManager()
		{
			converters.Add(AvailableConverters.JSON, new JSONConverter());
		}

		public void Convert<TData>(TData data, string destPath, AvailableConverters format)
		{
			if (!converters.ContainsKey(format))
			{
				throw new ArgumentException($"{format} is not supported, please choose a supported format: {converters.Keys}");
			}

			converters[format].Convert<TData>(data, destPath);
		}
	}
}

