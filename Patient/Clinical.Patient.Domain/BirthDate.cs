using System.Runtime.InteropServices.JavaScript;

namespace Clinical.Patient.Domain;

public record BirthDate
{
    public DateOnly Value { get; private set; }
    
    private  BirthDate(DateOnly value)
    {
        Value = value;
    }

    public static BirthDate Create(DateOnly value)
    {

        if (value > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentOutOfRangeException(nameof(value)); 
        
        return new BirthDate(value);
    }}