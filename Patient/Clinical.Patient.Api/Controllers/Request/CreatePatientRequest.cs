namespace Clinical.Patient.Api.Controllers.Request;

public record CreatePatientRequest(
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
    string PhoneNumber);