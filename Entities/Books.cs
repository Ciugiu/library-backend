using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Attributes;

namespace WebApplication1.Entities;

public class Books
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(255)] 
    public string? Title { get; set; }
    
    // Foreign key to Authors
    public int? AuthorId { get; set; }
    
    // Navigation property to Authors
    [ForeignKey("AuthorId"), AuthorBook]
    public Authors? Author { get; set; }
    
    [StringLength(50)]
    public string? Language { get; set; }
    [StringLength(50)]
    public string? Category { get; set; }
    [StringLength(50), Year]
    public Int16? PublishedYear { get; set; }
}