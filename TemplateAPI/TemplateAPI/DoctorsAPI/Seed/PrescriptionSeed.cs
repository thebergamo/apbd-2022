using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAPI.Seed;

public class PrescriptionSeed: ISeed<Prescription>
{
    public static void Seed(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2022, 04, 01),
                DueDate = new DateTime(2022, 09, 29),
                IdDoctor = 1,
                IdPatient = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2022, 05, 01),
                DueDate = new DateTime(2022, 12, 31),
                IdDoctor = 1,
                IdPatient = 2
            }
        );
    }
}