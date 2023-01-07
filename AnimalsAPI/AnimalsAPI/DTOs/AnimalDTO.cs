using System.ComponentModel.DataAnnotations;

namespace AnimalsAPI.DTOs;

public class AnimalDto: BaseAnimalDto
{
    [Required]
    public int IdAnimal { get; set; }

    public AnimalDto(int idAnimal, string name, string description, string category, string area) : base(name, description, category, area)
    {
        IdAnimal = idAnimal;
    }
}