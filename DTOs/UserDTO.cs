using System.ComponentModel.DataAnnotations;
using WebApplication1.Attributes;

namespace WebApplication1.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? RegistrationDate { get; set; }
}

public class CreateUserDTO
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    [Email]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    [Phone(ErrorMessage = "Invalid phone number format")]
    [StringLength(20)]
    public string? PhoneNumber { get; set; }
}
