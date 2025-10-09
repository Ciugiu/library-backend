using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Attributes;

namespace WebApplication1.Entities;

public class Authors
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id {get; set;}
    [StringLength(50)]
    public string? FirstName {get; set;}
    [StringLength(50)]
    public string? LastName {get; set;}
    [Email]
    public string? Email {get; set;}
    [Age]
    public int? Age {get; set;}
    public ICollection<Books> Books { get; set; } = new List<Books>();
}