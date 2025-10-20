using System.ComponentModel.DataAnnotations;
using WebApplication1.Attributes;

namespace WebApplication1.DTOs;

public class AuthorDTO
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int? Age { get; set; }
}
public class CreateAuthorDTO
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    [Email]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Age is required")]
    [Age]
    public int Age { get; set; }
}
