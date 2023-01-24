using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAPI.Seed;

public class PatientSeed
{
    public static void Seed( EntityTypeBuilder<Patient> builder)
    {
        builder.HasData(
            new Patient
            {
                IdPatient = 1,
                FirstName = "Jakub",
                LastName = "Nowak",
                BirthDate = new DateTime(1993, 05, 04)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Krzysztof",
                LastName = "Stropski",
                BirthDate = new DateTime(1991, 05, 05)
            }
        );
    } 
}