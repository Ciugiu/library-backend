using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes;

public class YearAttribute : ValidationAttribute
{
    public YearAttribute(){}

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("The year cannot be null.");
        }

        if (value.GetType() != typeof(Int16))
        {
            return new ValidationResult("Year is of wrong type.");
        }
        return new ValidationResult("Error validating the year.");
    }
}