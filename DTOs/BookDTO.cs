using System.ComponentModel.DataAnnotations;
using WebApplication1.Attributes;

namespace WebApplication1.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Language { get; set; }
    public int? PublishedYear { get; set; }
}
public class CreateBookDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(255)]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "AuthorID is required")]
    public int AuthorId { get; set; }
    public int? CategoryId { get; set; }
    [StringLength(50)]
    public string? Language { get; set; }
    [Year]
    public int? PublishedYear { get; set; }
}
