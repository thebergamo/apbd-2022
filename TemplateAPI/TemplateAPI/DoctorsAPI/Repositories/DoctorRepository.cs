using DoctorsAPI.Exceptions;
using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAPI.Repositories;

public class DoctorRepository: ICrudRepository<Doctor>
{
    private readonly MasterDbContext _context;

    public DoctorRepository(MasterDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Doctor>> List()
    {
        throw new NotImplementedException();
    }

    public async Task<Doctor> Get(int id)
    {
        var doctor = await _context.Doctors
            .Include(d => d.Prescriptions.OrderByDescending(p => p.Date))
            .ThenInclude(p => p.Patient)
            .Include(d => d.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .SingleOrDefaultAsync(doc => doc.IdDoctor == id);

        if (doctor == null)
        {
            throw new RecordNotFoundException(id);
        }

        return doctor;
    }

    public Task<Doctor> Create(Doctor entity)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> Update(Doctor entity)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        var doctor = await Get(id);
        
        _context.Doctors.Remove(doctor);

        await _context.SaveChangesAsync();
    }
}