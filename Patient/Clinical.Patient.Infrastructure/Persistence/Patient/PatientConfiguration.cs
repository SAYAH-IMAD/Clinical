using Clinical.Patient.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinical.Patient.Infrastructure.Persistence.Patient;

public class PatientConfiguration : IEntityTypeConfiguration<Domain.PatientAggregateRoot>
{
    public void Configure(EntityTypeBuilder<Domain.PatientAggregateRoot> builder)
    {
        builder.ToTable("Patient");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName).HasMaxLength(128).IsRequired();

        builder.Property(p => p.LastName).HasMaxLength(128).IsRequired();

        builder.Property(p => p.BirthDate).HasConversion(birthDate => birthDate.Value, value => BirthDate.Create(value))
            .HasColumnType("date")
            .IsRequired();

        builder.Property(p => p.SecurityNumber).HasConversion(securityNumber => securityNumber.Value,
                value => SecurityNumber.Create(value))
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(p => p.Email).HasConversion(email => email.Value, value => Email.Create(value))
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(p => p.PhoneNumber)
            .HasConversion(phoneNumber => phoneNumber.Value, value => PhoneNumber.Create(value)).HasMaxLength(128)
            .IsRequired();
        
        builder.OwnsOne(p => p.Address, address =>
        {
            address.Property(p => p.Line1).HasMaxLength(128).IsRequired();
            address.Property(p => p.Line2).HasMaxLength(128);
            address.Property(p => p.City).HasMaxLength(128).IsRequired();
            address.Property(p => p.PostalCode).HasMaxLength(128).IsRequired();
            address.Property(p => p.State).HasMaxLength(128).IsRequired();
            address.Property(p => p.Country).HasMaxLength(128).IsRequired();
        });
    }
}