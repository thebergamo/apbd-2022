namespace ClientsTripAPI.Models.DTO;

public class NameDTO
{
    public string Name { get; set; }
}

public class ClientsNameDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class TripDTO
{
    public int IdTrip { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public List<NameDTO> Countries { get; set; }
    public List<ClientsNameDTO> Clients { get; set; }
}