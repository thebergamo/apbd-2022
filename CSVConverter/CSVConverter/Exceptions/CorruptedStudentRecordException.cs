using System;
namespace CSVConverter.Exceptions
{
	public class CorruptedStudentRecordException: Exception
	{
		public CorruptedStudentRecordException(string record): base($"Student Record is corrupted {record} - Record is skiped from final export")
		{
		}
	}
}

