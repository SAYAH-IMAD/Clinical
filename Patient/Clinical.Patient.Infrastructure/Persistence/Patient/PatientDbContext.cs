using Clinical.Patient.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clinical.Patient.Infrastructure.Persistence.Patient;

public class PatientDbContext(DbContextOptions<PatientDbContext> options) : DbContext(options)
{
    public DbSet<Domain.PatientAggregateRoot> Patients => Set<Domain.PatientAggregateRoot>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientDbContext).Assembly);
    }
}