using System.Runtime.InteropServices;
using Clinical.Common.Domain;

namespace Clinical.Patient.Domain;

public class MedicalHistory : Entity<int>
{
    public string Label { get; private set; }
    public string Category { get; private set; }
    public DateOnly Date { get; private set; }

    private MedicalHistory(string label, string category, DateOnly date)
    {
        Label = label;
        Category = category;
        Date = date;
    }
    
    public static MedicalHistory Create(string label, string category, DateOnly date)
    {
        return new MedicalHistory(label, category, date);
    }
}