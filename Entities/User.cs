using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Attributes;

namespace WebApplication1.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(100)]
    public string? Name { get; set; }
    [Year]
    public string? Email { get; set; }
    [StringLength(20)]
    public string? PhoneNumber { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}
