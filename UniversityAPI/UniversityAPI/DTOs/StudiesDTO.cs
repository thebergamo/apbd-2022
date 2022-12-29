using System.ComponentModel.DataAnnotations;
using UniversityAPI.Models;

namespace UniversityAPI.DTOs;

public class StudiesDTO
{
    [Required(AllowEmptyStrings = false)]
    [MinLength(1)]
    public string Name { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    [MinLength(1)]
    public string Mode { get; set; }

    public StudiesDTO(string name, string mode)
    {
        Name = name;
        Mode = mode;
    }

    public static Studies ToEntity(StudiesDTO dtoStudies)
    {
        return new Studies(dtoStudies.Name, dtoStudies.Mode);
    }

    public static StudiesDTO FromEntity(Studies entityStudies)
    {
        return new StudiesDTO(entityStudies.Name, entityStudies.Mode);
    }
}