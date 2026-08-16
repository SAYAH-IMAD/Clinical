using Microsoft.Extensions.DependencyInjection;

namespace Clinical.Patient.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddPatientApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(mediatr => mediatr.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}