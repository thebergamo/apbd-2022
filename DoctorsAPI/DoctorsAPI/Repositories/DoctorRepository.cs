using DoctorsAPI.Exceptions;
using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAPI.Repositories;

public class DoctorRepository: ICrudRepository<Doctor>
{
    private readonly MasterContext _context;

    public DoctorRepository(MasterContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Doctor>> List()
    {
        return await _context.Doctors.ToListAsync();
    }

    public async Task<Doctor> Get(int id)
    {
        var doctor = await _context.Doctors
            .SingleOrDefaultAsync(doc => doc.IdDoctor == id);

        if (doctor == null)
        {
            throw new RecordNotFoundException(id);
        }

        return doctor;
    }
    
    public async Task<bool> CheckEmailUniqueness(string email)
    {
        var doctorWithEmail = await _context.Doctors
            .SingleOrDefaultAsync(doc => doc.Email == email);

        return doctorWithEmail != null;
    }
    
    public async Task<bool> CheckEmailUniqueness(string email, int idDoctor)
    {
        var doctorWithEmail = await _context.Doctors
            .SingleOrDefaultAsync(doc => doc.Email == email && doc.IdDoctor != idDoctor);

        return doctorWithEmail != null;
    }

    public async Task<Doctor> Create(Doctor entity)
    {
        var newDoctor = _context.Doctors.Add(entity);

        await _context.SaveChangesAsync();

        return newDoctor.Entity;
    }

    public async Task<Doctor> Update(Doctor entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(int id)
    {
        var doctor = await Get(id);
        
        _context.Doctors.Remove(doctor);

        await _context.SaveChangesAsync();
    }
}