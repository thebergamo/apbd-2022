using DoctorsAPI.Seed;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAPI.Models;

public partial class MasterDbContext: DbContext
{
    public MasterDbContext()
    {
    }

    public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Seed(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(DoctorSeed.Seed);
        modelBuilder.Entity<Patient>(PatientSeed.Seed);
        modelBuilder.Entity<Medicament>(MedicamentSeed.Seed);
        modelBuilder.Entity<Prescription>(PrescriptionSeed.Seed);
        modelBuilder.Entity<PrescriptionMedicament>(PrescriptionMedicamentSeed.Seed);
    }
}