namespace Clinical.Patient.Domain;

public record Email
{
    public string Value { get; private set; }
    
    private  Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Email cannot be empty.", nameof(value));
        
        if(!value.Contains('@'))
            throw new ArgumentException("Invalid email format.", nameof(value));
        
        return new Email(value);
    }
    
}