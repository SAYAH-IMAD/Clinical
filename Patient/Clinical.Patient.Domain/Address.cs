namespace Clinical.Patient.Domain;

public record Address
{
    public string Line1 { get; private set; }
    public string Line2 { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    private Address(string line1, string line2, string city, string postalCode, string state, string country)
    {
        Line1 = line1;
        Line2 = line2;
        City = city;
        PostalCode = postalCode;
        State = state;
        Country = country;
    }

    public static Address Create(string line1, string line2, string city, string postalCode, string state,
        string country)
    {
        return new Address(line1, line2, city, postalCode, state, country);
    }
}