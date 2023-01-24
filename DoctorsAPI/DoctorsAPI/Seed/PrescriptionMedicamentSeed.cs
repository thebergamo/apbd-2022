using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAPI.Seed;

public class PrescriptionMedicamentSeed
{
    public static void Seed(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasData(
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 1,
                Details = "2x a day"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Details = "3x day for 7 days"
            }
        );
    }
}