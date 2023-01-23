namespace ClientsTripAPI.Exceptions;

public class ClientAlreadyAssociatedException: Exception
{
    public ClientAlreadyAssociatedException(int idTrip, string pesel): base($"Client with Pesel: {pesel} is already associated with trip: {idTrip}. Please check the trip and try again")
    {
    }
}