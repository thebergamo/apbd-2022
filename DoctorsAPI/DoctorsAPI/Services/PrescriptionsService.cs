using DoctorsAPI.Models.DTO;
using DoctorsAPI.Repositories;

namespace DoctorsAPI.Services;

public class PrescriptionsService
{
    private readonly PrescriptionRepository _repo;

    public PrescriptionsService(PrescriptionRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<PrescriptionResponseDTO> Get(int id)
    {
        return PrescriptionResponseDTO.FromModel(await _repo.Get(id));
    }
}