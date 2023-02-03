namespace DoctorsAPI.Models.DTO;

public class PatientResponseDTO : IResponseDTO<Patient, PatientResponseDTO>
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    public static PatientResponseDTO FromModel(Patient model)
    {
        return new PatientResponseDTO()
        {
            IdPatient = model.IdPatient,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Birthdate = model.BirthDate
        };
    }
}

public class MedicamentResponseDTO: IResponseDTO<PrescriptionMedicament, MedicamentResponseDTO>
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }

    public static MedicamentResponseDTO FromModel(PrescriptionMedicament model)
    {
        return new MedicamentResponseDTO()
        {
            IdMedicament = model.IdMedicament,
            Name = model.Medicament.Name,
            Type = model.Medicament.Type,
            Dose = model.Dose,
            Details = model.Details
        };
    }
}

public class PrescriptionResponseDTO: IResponseDTO<Prescription, PrescriptionResponseDTO>
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PatientResponseDTO Patient { get; set; }
    public IEnumerable<MedicamentResponseDTO> Medicaments { get; set; }

    public static PrescriptionResponseDTO FromModel(Prescription model)
    {
        return new PrescriptionResponseDTO()
        {
            IdPrescription = model.IdPrescription,
            Date = model.Date,
            DueDate = model.DueDate,
            Patient = PatientResponseDTO.FromModel(model.Patient),
            Medicaments = model.PrescriptionMedicaments.Select(MedicamentResponseDTO.FromModel).ToList()
        };
    }
}