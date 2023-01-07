using System.ComponentModel.DataAnnotations;

namespace AnimalsAPI.DTOs;

public class BaseAnimalDto
{
    public BaseAnimalDto(string name, string description, string category, string area)
    {
        Name = name;
        Description = description;
        Category = category;
        Area = area;
    }

    [Required]
    [MaxLength(200, ErrorMessage = $"Name cannot exceed maximum length of 200 characters")]
    public string Name { get; set; }
    [Required]
    [MaxLength(500, ErrorMessage = $"Description cannot exceed maximum length of 500 characters")]
    // INFO: in Script.SQL provided we have max length set at 200 and area 500.
    // I think it should be the opposite so I switch them in the code here.
    public string Description { get; set; }
    [Required]
    [MaxLength(200, ErrorMessage = $"Category cannot exceed maximum length of 200 characters")]
    public string Category { get; set; }
    [Required]
    [MaxLength(200, ErrorMessage = $"Area cannot exceed maximum length of 200 characters")]
    public string Area { get; set; }
    
}