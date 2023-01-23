using ClientsTripAPI.Exceptions;
using ClientsTripAPI.Models;
using ClientsTripAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClientsTripAPI.Services;

public class TripsService
{
    private readonly MasterContext _context;
    private readonly ClientsService _clientsService;

    public TripsService(MasterContext context, ClientsService clientsService)
    {
        _context = context;
        _clientsService = clientsService;
    }

    public async Task<List<TripDTO>> List()
    {
        var trips = await _context.Trips
            .OrderByDescending(t => t.DateFrom)
            .Include(t => t.IdCountries)
            .Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
            .Select(t => new TripDTO
            {
                IdTrip = t.IdTrip,
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(c => new NameDTO() { Name = c.Name }).ToList(),
                Clients = t.ClientTrips.ToList().Select(ct => new ClientsNameDTO() { FirstName = ct.IdClientNavigation.FirstName, LastName = ct.IdClientNavigation.LastName }).ToList()
            })
            .ToListAsync();

        return trips;
    }

    public async Task<TripDTO> Get(int id)
    {
        var trip = await _context.Trips
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .Select(t => new TripDTO
                {
                    IdTrip = t.IdTrip,
                    Name = t.Name,
                    Description = t.Description,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    MaxPeople = t.MaxPeople,
                    Countries = t.IdCountries.Select(c => new NameDTO
                    {
                        Name = c.Name
                    }).ToList(),
                    Clients = t.ClientTrips.Select(ct => new ClientsNameDTO
                    {
                        FirstName = ct.IdClientNavigation.FirstName,
                        LastName = ct.IdClientNavigation.LastName
                    }).ToList()
                }
            )
            .SingleOrDefaultAsync(t => t.IdTrip == id);

        if (trip == null)
        {
            throw new RecordNotFoundException(id);
        }

        return trip;
    }

    private async Task<bool> TripHasClient(int idTrip, int idClient)
    {
        var clientTrip =
            await _context.ClientTrips
                .SingleOrDefaultAsync(ct => ct.IdClient == idClient && ct.IdTrip == idTrip);
        
        return clientTrip != null;
    }

    public async Task<TripDTO> AssignCustomer(CustomerTripDTO customer)
    {
        var client = await _clientsService.FindByPesel(customer.Pesel);

        if (client == null)
        {
            client = await _clientsService.Create(customer);
        }

        var trip = await Get(customer.IdTrip);

        if (await TripHasClient(trip.IdTrip, client.IdClient))
        {
            throw new ClientAlreadyAssociatedException(trip.IdTrip, client.Pesel);
        }
        
        var newClientTrip = new ClientTrip
        {
            IdClient = client.IdClient,
            IdTrip = trip.IdTrip,
            PaymentDate = customer.PaymentDate,
            RegisteredAt = DateTime.Now
        };

        _context.ClientTrips.Add(newClientTrip);
        
        await _context.SaveChangesAsync();

        return await Get(trip.IdTrip);
    }
}