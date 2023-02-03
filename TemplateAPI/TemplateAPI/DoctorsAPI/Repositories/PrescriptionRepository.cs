using DoctorsAPI.Exceptions;
using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAPI.Repositories;

public class PrescriptionRepository: ICrudRepository<Prescription>
{
    private readonly MasterDbContext _context;

    public PrescriptionRepository(MasterDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Prescription>> List()
    {
        throw new NotImplementedException();
    }

    public async Task<Prescription> Get(int id)
    {
        var prescription = await _context.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .SingleOrDefaultAsync(p => p.IdPrescription == id);

        if (prescription == null)
        {
            throw new RecordNotFoundException(id);
        }

        return prescription;
    }

    public Task<Prescription> Create(Prescription entity)
    {
        throw new NotImplementedException();
    }

    public Task<Prescription> Update(Prescription entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}