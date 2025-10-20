using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;
public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class CreateCategoryDTO
{
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [StringLength(200)]
    public string? Description { get; set; }
}
