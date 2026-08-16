using Clinical.Common.Application.Contract;
using Clinical.Patient.Application.Contract.Persistence;
using Clinical.Patient.Infrastructure.Persistence;
using Clinical.Patient.Infrastructure.Persistence.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clinical.Patient.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPatientInfrastructure(
        this IServiceCollection services)
    {
        services.AddDbContext<PatientDbContext>(options =>
            options.UseSqlServer(
                "Server=localhost,1433;Database=Clinical.Patient.Database;User Id=sa;Password=YourStrong@Password2025;TrustServerCertificate=True;Encrypt=True;MultipleActiveResultSets=true"));

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}