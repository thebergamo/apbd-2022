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

    public async Task<DoctorResponseDTO> Get(int id)
    {
        return DoctorResponseDTO.FromModel(await _repo.Get(id));
    }


    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    } 
}