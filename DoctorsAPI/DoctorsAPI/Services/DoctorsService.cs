using DoctorsAPI.Exceptions;
using DoctorsAPI.Models;
using DoctorsAPI.Models.DTO;
using DoctorsAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAPI.Services;

public class DoctorsService
{
    private readonly DoctorRepository _repo;

    public DoctorsService(DoctorRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<DoctorResponseDTO>> List()
    {
        var doctorsList = await _repo.List();
            
        return doctorsList
            .Select(DoctorResponseDTO.FromModel)
            .ToList();
    }

    public async Task<DoctorResponseDTO> Get(int id)
    {
        return DoctorResponseDTO.FromModel(await _repo.Get(id));
    }


    public async Task<DoctorResponseDTO> Create(CreateDoctorDTO doctorDto)
    {
        if (await _repo.CheckEmailUniqueness(doctorDto.Email))
        {
            throw new ArgumentException(
                $"Doctor with provided email already exist. Please try different one or check database first");
        }

        var newDoctor = await _repo.Create(new Doctor()
        {
            Email = doctorDto.Email,
            FirstName = doctorDto.FirstName,
            LastName = doctorDto.LastName
        });

        return DoctorResponseDTO.FromModel(newDoctor);
    }

    public async Task<DoctorResponseDTO> Update(int id, UpdateDoctorDTO doctorDto)
    {
        if (id != doctorDto.IdDoctor)
        {
            throw new ArgumentException(
                $"Provided id for the resource doctor is different than one provided in the body of this request. Please check the request and try again.");
        }
        
        if (await _repo.CheckEmailUniqueness(doctorDto.Email, id))
        {
            throw new ArgumentException(
                $"Doctor with provided email already exist. Please try different one or check database first");
        }

        try
        {
            var updatedDoctor = await _repo.Update(new Doctor()
            {
                IdDoctor = doctorDto.IdDoctor,
                Email = doctorDto.Email,
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName
            });
            return DoctorResponseDTO.FromModel(updatedDoctor);
        }
        catch (DbUpdateConcurrencyException err)
        {
            if (err.Message.Contains("affected 0 row(s)"))
            {
                throw new RecordNotFoundException(id);
            }
            else
            {
                throw err;
            }
        }
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    } 
}