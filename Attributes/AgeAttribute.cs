using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes;

public class AgeAttribute : ValidationAttribute
{
    public AgeAttribute()
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Age cannot be null.");
        }
        
        var age = Convert.ToInt32(value);

        if (age >= 18)
        {
            return ValidationResult.Success;
        } else {
        return new ValidationResult(ErrorMessage);
        }
    }
}