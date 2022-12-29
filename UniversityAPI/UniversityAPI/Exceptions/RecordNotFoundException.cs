namespace UniversityAPI.Exceptions;

public class RecordNotFoundException: Exception
{
    public RecordNotFoundException(string id): base($"Record with {id} does not exist in the database")
    {
    }
}