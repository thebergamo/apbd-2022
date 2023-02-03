using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAPI.Seed;

public class MedicamentSeed: ISeed<Medicament>
{
    public static void Seed(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasData(
            new Medicament
            {
                IdMedicament = 1,
                Name = "Ibuprofen",
                Description = "Painkiller",
                Type = "Tablet"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Paracetamol",
                Description = "Painkiller",
                Type = "Tablet"
            },
            new Medicament
            {
                IdMedicament = 3,
                Name = "Neozine",
                Description = "Nasal",
                Type = "Spray"
            }
        );
    } 
}