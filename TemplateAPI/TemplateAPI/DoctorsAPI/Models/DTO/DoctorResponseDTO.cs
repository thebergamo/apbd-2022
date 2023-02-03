namespace DoctorsAPI.Models.DTO;

public class DoctorResponseDTO: IResponseDTO<Doctor, DoctorResponseDTO>
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public IEnumerable<PrescriptionResponseDTO> Prescriptions { get; set;  }

    public static DoctorResponseDTO FromModel(Doctor doc)
    {
        return new DoctorResponseDTO()
        {
            IdDoctor = doc.IdDoctor,
            FirstName = doc.FirstName,
            LastName = doc.LastName,
            Email = doc.Email,
            Prescriptions = doc.Prescriptions
                .Select(PrescriptionResponseDTO.FromModel)
                .ToList()
        };
    }
}