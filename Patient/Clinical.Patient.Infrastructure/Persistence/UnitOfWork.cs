using Clinical.Common.Application.Contract;
using Clinical.Patient.Infrastructure.Persistence.Patient;

namespace Clinical.Patient.Infrastructure.Persistence;

public class UnitOfWork(PatientDbContext patientDbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync()
    {
        return patientDbContext.SaveChangesAsync();
    }
}