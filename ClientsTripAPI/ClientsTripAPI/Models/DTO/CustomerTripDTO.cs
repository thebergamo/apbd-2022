using System.ComponentModel.DataAnnotations;

namespace ClientsTripAPI.Models.DTO;

public class CustomerTripDTO
{
    [Required]
    [MaxLength(120, ErrorMessage = $"FirstName cannot exceed maximum length of 200 characters")]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(120, ErrorMessage = $"LastName cannot exceed maximum length of 200 characters")]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(120, ErrorMessage = $"Email cannot exceed maximum length of 200 characters")]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(120, ErrorMessage = $"Telephone cannot exceed maximum length of 200 characters")]
    public string Telephone { get; set; }
    
    [Required]
    [MaxLength(11, ErrorMessage = $"Pesel cannot exceed maximum length of 11 characters")]
    // INFO: According to PESEL number is won't exceed 11 numbers
    public string Pesel { get; set; }
    
    [Required]
    public int IdTrip { get; set; }
    
    [Required]
    [MaxLength(120, ErrorMessage = $"TripName cannot exceed maximum length of 200 characters")]
    public string TripName { get; set; }
    
    public DateTime? PaymentDate { get; set; }
    
}