using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes;

public class YearAttribute : ValidationAttribute
{
    public YearAttribute(){}

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Year is optional
        }

        if (value.GetType() != typeof(Int32))
        {
            return new ValidationResult("Year must be a number.");
        }

        var year = Convert.ToInt32(value);
        var currentYear = DateTime.Now.Year;

        if (year < 1000 || year > currentYear)
        {
            return new ValidationResult($"Year must be between 1000 and {currentYear}.");
        }

        return ValidationResult.Success;
    }
}