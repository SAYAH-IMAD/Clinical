using Clinical.Common.Application.Contract;
using Clinical.Patient.Application.Contract.Persistence;

namespace Clinical.Patient.Application.Queries;

public record GetPatientsQuery : IQuery<IEnumerable<PatientModel>>;

public record PatientModel(
    int Id,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    string Email = null,
    string SecurityNumber = null,
    string Line1 = null,
    string Line2 = null,
    string City = null,
    string PostalCode = null,
    string State = null,
    string Country = null,
    string PhoneNumber = null
);

public class GetPatientsQueryHandler(IPatientRepository repository)
    : IQueryHandler<GetPatientsQuery, IEnumerable<PatientModel>>
{
    public async Task<IEnumerable<PatientModel>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await repository.FindPatientsAsync();

        return patients.Select(element =>
            new PatientModel(element.Id, element.FirstName, element.LastName, element.BirthDate.Value)
        );
    }
}