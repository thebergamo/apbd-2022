using System.ComponentModel.DataAnnotations;
using System.Globalization;
using UniversityAPI.Models;
using UniversityAPI.Validations;

namespace UniversityAPI.DTOs;

public class StudentDTO
{
    [Required]
    [RegularExpression(@"^s([0-9]{3,5})$", ErrorMessage = "IndexNumber is invalid, please use a valid format: sXXXXX")]
    public string IndexNumber { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MinLength(1)]
    public string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MinLength(1)]
    public string LastName { get; set; }

    [Required]
    [CustomDate("yyyy-mm-dd", ErrorMessage = "{0} value does not match the format {1}")]
    [DataType(DataType.Date)]
    public string Birthdate { get; set; }

    [Required] public StudiesDTO Studies { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MinLength(1)]
    public string FathersName { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MinLength(1)]
    public string MothersName { get; set; }

    public StudentDTO(string indexNumber, string firstName, string lastName, string birthdate,
        string email, string fathersName, string mothersName, StudiesDTO studies)
    {
        IndexNumber = indexNumber;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Studies = studies;
        Email = email;
        FathersName = fathersName;
        MothersName = mothersName;
    }

    public static Student ToEntity(StudentDTO dto)
    {
        return new Student(
            dto.IndexNumber,
            dto.FirstName,
            dto.LastName,
            DateOnly.FromDateTime(DateTime.ParseExact(dto.Birthdate, "yyyy-mm-dd", null, DateTimeStyles.None)),
            dto.Email,
            dto.FathersName,
            dto.MothersName,
            StudiesDTO.ToEntity(dto.Studies)
        );
    }

    public static StudentDTO FromEntity(Student entity)
    {
        return new StudentDTO(
            entity.IndexNumber,
            entity.FirstName,
            entity.LastName,
            entity.Birthdate.ToShortDateString(),
            entity.Email,
            entity.FathersName,
            entity.MothersName,
            StudiesDTO.FromEntity(entity.Studies)
        );
    }
}