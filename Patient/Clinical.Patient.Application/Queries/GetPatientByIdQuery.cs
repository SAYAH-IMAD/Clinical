using Clinical.Common.Application.Contract;
using Clinical.Patient.Application.Contract.Persistence;

namespace Clinical.Patient.Application.Queries;

public record GetPatientByIdQuery(int Id) : IQuery<PatientModel>;

public class GetPatientByIdQueryHandler(IPatientRepository repository)
    : IQueryHandler<GetPatientByIdQuery, PatientModel>
{
    public async Task<PatientModel> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await repository.FindPatientByIdAsync(request.Id);

        return patient == null
            ? throw new ArgumentNullException(nameof(patient))
            {
                HelpLink = null,
                HResult = 0,
                Source = null
            }
            : new PatientModel(patient.Id, patient.FirstName, patient.LastName, patient.BirthDate.Value,
                patient.Email.Value, patient.SecurityNumber.Value, patient.Address.Line1, patient.Address.Line2,
                patient.Address.City, patient.Address.Country, patient.Address.State, patient.PhoneNumber.Value);
    }
}