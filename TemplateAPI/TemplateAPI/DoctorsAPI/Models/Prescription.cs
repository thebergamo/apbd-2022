using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsAPI.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public int IdDoctor { get; set; }

    [ForeignKey("IdDoctor")]
    public virtual Doctor Doctor { get; set; }

    public int IdPatient { get; set; }

    [ForeignKey("IdPatient")]
    public virtual Patient Patient { get; set; }

    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; } =
        new List<PrescriptionMedicament>();
}