using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class BorrowDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public int BookId { get; set; }
    public string? BookTitle { get; set; }
    public DateTime? BorrowDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}


public class CreateBorrowDTO
{
    [Required(ErrorMessage = "User ID is required")]
    public int UserId { get; set; }
    [Required(ErrorMessage = "Book ID is required")]
    public int BookId { get; set; }
    public DateTime? DueDate { get; set; }
}
public class ReturnBookDTO
{
    public DateTime? ReturnDate { get; set; }
}
