using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes;

public class AuthorBookAttribute :  ValidationAttribute
{
    public AuthorBookAttribute()
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Author has to be provided");
        }
        return ValidationResult.Success;
    }
}