namespace Clinical.Patient.Domain;

public record PhoneNumber
{
    public string Value { get; private set; }
    
    private  PhoneNumber(string value)
    {
        Value = value;
    }

    public static PhoneNumber Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Phone number cannot be empty.", nameof(value));
        
        return new PhoneNumber(value);
    }
}