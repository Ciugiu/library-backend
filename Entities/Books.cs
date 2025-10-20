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
    public int? AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public Authors? Author { get; set; }
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
    [StringLength(50)]
    public string? Language { get; set; }
    [Year]
    public Int16? PublishedYear { get; set; }
    public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}