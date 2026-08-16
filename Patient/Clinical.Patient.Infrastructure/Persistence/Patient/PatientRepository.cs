using Clinical.Patient.Application.Contract.Persistence;
using Clinical.Patient.Application.Queries;
using Clinical.Patient.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clinical.Patient.Infrastructure.Persistence.Patient;

public class PatientRepository(PatientDbContext context) : IPatientRepository
{
    public PatientAggregateRoot FindPatientById(int id)
    {
        return context.Patients.Find(id);
    }

    public async Task<PatientAggregateRoot> FindPatientByIdAsync(int id)
    {
        return await context.Patients.FindAsync(id);
    }

    public Task<List<PatientAggregateRoot>> FindPatientsAsync()
    {
        return context.Patients.ToListAsync();
    }

    public Task<List<PatientAggregateRoot>> FindPatientsAsync(IEnumerable<PatientAggregateRoot> patients)
    {
        throw new NotImplementedException();
    }

    public Task AddPatientAsync(PatientAggregateRoot patient)
    {
        return Task.FromResult(context.Patients.Add(patient));
    }
    
    public void AddPatient(PatientAggregateRoot patient)
    {
        context.Patients.Add(patient);
    }
}