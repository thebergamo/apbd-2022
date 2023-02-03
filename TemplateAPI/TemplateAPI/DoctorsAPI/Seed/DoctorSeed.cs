using DoctorsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAPI.Seed;

public class DoctorSeed: ISeed<Doctor>
{
    public static void Seed(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData(
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Janusz",
                LastName = "Kozak",
                Email = "jk@wp.pl"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Grazyna",
                LastName = "Nowak",
                Email = "gn@wp.pl"
            }
        );
    } 
}