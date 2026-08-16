namespace Clinical.Patient.Domain;

public sealed record SecurityNumber
{
    public string Value { get; private set; }

    private SecurityNumber(string securityNumber) => Value = securityNumber;

    public static SecurityNumber Create(string securityNumber)
    {
        if (string.IsNullOrWhiteSpace(securityNumber))
            throw new ArgumentException("Security number cannot be null or whitespace.", nameof(securityNumber));

        return new SecurityNumber(securityNumber);
    }

    public override string ToString() => Value;
}