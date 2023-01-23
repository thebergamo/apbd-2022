namespace ClientsTripAPI.Exceptions;

public class RecordNotFoundException: Exception
{
    public RecordNotFoundException(int id): base($"Record with id {id} does not exist in the database")
    {
    }
}