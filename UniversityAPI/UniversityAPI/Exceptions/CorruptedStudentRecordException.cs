namespace UniversityAPI.Exceptions;

public class CorruptedStudentRecordException : Exception
{
    public CorruptedStudentRecordException(string record) : base(
        $"Student Record is corrupted {record} - Record is skipped from final export")
    {
    }
}