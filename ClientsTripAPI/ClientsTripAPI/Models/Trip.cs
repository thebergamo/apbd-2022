using System;
using System.Collections.Generic;

namespace ClientsTripAPI.Models;

public partial class Trip
{
    public int IdTrip { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public virtual ICollection<ClientTrip> ClientTrips { get; } = new List<ClientTrip>();

    public virtual ICollection<Country> IdCountries { get; } = new List<Country>();
}
