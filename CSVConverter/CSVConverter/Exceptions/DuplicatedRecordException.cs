using System;
namespace CSVConverter.Exceptions
{
	public class DuplicatedRecordException<TRecord>: Exception
	{
		public DuplicatedRecordException(TRecord record): base($"Duplicated record found during parsing file: {record}")
		{
		}
	}
}

