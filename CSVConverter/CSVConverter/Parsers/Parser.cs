using System;
namespace CSVConverter.Parsers
{
	public interface Parser<TInput, TOutput>
	{
		public static abstract TOutput Parse(TInput input);
	}
}

