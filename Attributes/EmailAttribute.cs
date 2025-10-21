using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplication1.Attributes;

public class EmailAttribute : ValidationAttribute
{
    public EmailAttribute(){} 
    
    static string pattern = @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$";
        
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Value cannot be null");
        }

        if (value.GetType() != typeof(string))
        {
            return new ValidationResult("Value must be of type string");
        }
        
        Regex rg = new Regex(pattern);
        if ( rg.IsMatch(value.ToString()))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("Invalid email format");
    }
}