using Clinical.Patient.Application.Queries;
using Clinical.Patient.Domain;

namespace Clinical.Patient.Application.Contract.Persistence;

public interface IPatientRepository
{
    PatientAggregateRoot FindPatientById(int id);
    Task<PatientAggregateRoot> FindPatientByIdAsync(int id);
    Task<List<PatientAggregateRoot>> FindPatientsAsync();
    Task<List<PatientAggregateRoot>> FindPatientsAsync(IEnumerable<PatientAggregateRoot> patients);
    Task AddPatientAsync(PatientAggregateRoot patient);
}