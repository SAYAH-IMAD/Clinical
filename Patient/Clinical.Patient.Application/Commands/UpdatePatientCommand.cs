using Clinical.Common.Application.Contract;
using Clinical.Patient.Application.Contract.Persistence;
using Clinical.Patient.Domain;

namespace Clinical.Patient.Application.Commands;

public record UpdatePatientCommand(
    int Id,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    string Email,
    string SecurityNumber,
    string Line1,
    string Line2,
    string City,
    string PostalCode,
    string State,
    string Country,
    string PhoneNumber) : ICommand;

internal class UpdatePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdatePatientCommand>
{
    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await repository.FindPatientByIdAsync(request.Id);

        if (patient == null)
            throw new ArgumentException($"Patient with id {request.Id} not found");

        patient.UpdateContactInformation(Email.Create(request.Email), SecurityNumber.Create(request.SecurityNumber),
            Address.Create(request.Line1, request.Line2, request.City, request.PostalCode, request.State,
                request.Country), PhoneNumber.Create(request.PhoneNumber));

        await unitOfWork.SaveChangesAsync();
    }
}