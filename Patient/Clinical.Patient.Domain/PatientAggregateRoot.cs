using Clinical.Common.Domain;

namespace Clinical.Patient.Domain;

public class PatientAggregateRoot : Entity<int>, IAggregateRoot
{
    private readonly List<MedicalHistory> _medicalHistories = [];
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public SecurityNumber SecurityNumber { get; private set; }
    public Address Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public BirthDate BirthDate { get; private set; }

    public IReadOnlyCollection<MedicalHistory> MedicalHistories
    {
        get { return _medicalHistories; }
    }

    protected PatientAggregateRoot()
    {
    }

    private PatientAggregateRoot(string firstName, string lastName, BirthDate birthDate, Email email,
        SecurityNumber securityNumber,
        Address address,
        PhoneNumber phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
        SecurityNumber = securityNumber;
        Address = address;
        PhoneNumber = phoneNumber;
    }


    public static PatientAggregateRoot Create(string firstName, string lastName, DateOnly birthDate, string email,
        string securityNumber,
        string line1, string line2,
        string city, string postalCode, string state, string country, string phoneNumber) =>
        new PatientAggregateRoot(firstName, lastName, Domain.BirthDate.Create(birthDate), Email.Create(email),
            SecurityNumber.Create(securityNumber),
            Address.Create(line1, line2, city, postalCode, state, country), PhoneNumber.Create(phoneNumber));

    public void UpdateContactInformation(Email email, SecurityNumber securityNumber, Address address,
        PhoneNumber phoneNumber)
    {
        Email = email;
        SecurityNumber = securityNumber;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public void AddMedicalHistory(string label, string category, DateOnly date)
    {
        _medicalHistories.Add(MedicalHistory.Create(label, category, date));
    }
}