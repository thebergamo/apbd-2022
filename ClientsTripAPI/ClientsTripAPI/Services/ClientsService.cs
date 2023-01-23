using System.Data;
using ClientsTripAPI.Exceptions;
using ClientsTripAPI.Models;
using ClientsTripAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClientsTripAPI.Services;

public class ClientsService
{
    private readonly MasterContext _context;

    public ClientsService(MasterContext context)
    {
        _context = context;
    }

    private async Task<Client> Get(int id)
    {
        var client = await _context.Clients
            .Include(c => c.ClientTrips)
            .SingleOrDefaultAsync(c => c.IdClient == id);

        if (client == null)
        {
            throw new RecordNotFoundException(id);
        }

        return client;
    }

    public async Task<Client?> FindByPesel(string pesel)
    {
        var client = await _context.Clients.SingleOrDefaultAsync(c => c.Pesel == pesel);

        return client;
    }

    public async Task<Client> Create(CustomerTripDTO client)
    {
        var newClient = new Client
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Pesel = client.Pesel,
            Telephone = client.Telephone
        };

        _context.Clients.Add(newClient);
        
        await _context.SaveChangesAsync();
        
        return newClient;
    }
    

    public async Task Delete(int id)
    {
        var client = await Get(id);

        if (client.ClientTrips.Count != 0)
        {
            throw new ConstraintException("Cannot delete a client with Trips associated");
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}