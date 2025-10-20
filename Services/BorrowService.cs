using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Services;

public class BorrowService
{
    private readonly LibraryContext _context;
    
    public BorrowService(LibraryContext context)
    {
        _context = context;
    }
    public IEnumerable<BorrowDTO> GetAll()
    {
        var borrows = _context.Borrows
            .Include(b => b.User)
            .Include(b => b.Book)
            .ToList();
        var borrowDTOs = new List<BorrowDTO>();
        foreach (var borrow in borrows)
        {
            borrowDTOs.Add(ConvertToDTO(borrow));
        }
        return borrowDTOs;
    }

    public BorrowDTO? GetById(int id)
    {
        var borrow = _context.Borrows
            .Include(b => b.User)
            .Include(b => b.Book)
            .FirstOrDefault(b => b.Id == id);
        if (borrow == null)
            return null;
        return ConvertToDTO(borrow);
    }

    public IEnumerable<BorrowDTO> GetByUserId(int userId)
    {
        var borrows = _context.Borrows
            .Include(b => b.User)
            .Include(b => b.Book)
            .Where(b => b.UserId == userId)
            .ToList();
        var borrowDTOs = new List<BorrowDTO>();
        foreach (var borrow in borrows)
        {
            borrowDTOs.Add(ConvertToDTO(borrow));
        }
        return borrowDTOs;
    }

    public BorrowDTO Create(CreateBorrowDTO createDto)
    {
        var borrowEntity = new Borrow
        {
            UserId = createDto.UserId,
            BookId = createDto.BookId,
            BorrowDate = DateTime.Now,
            DueDate = createDto.DueDate ?? DateTime.Now.AddDays(14),
            ReturnDate = null
        };
        _context.Borrows.Add(borrowEntity);
        _context.SaveChanges();
        var borrow = _context.Borrows
            .Include(b => b.User)
            .Include(b => b.Book)
            .First(b => b.Id == borrowEntity.Id);
        return ConvertToDTO(borrow);
    }

    public BorrowDTO? ReturnBook(int borrowId, ReturnBookDTO returnDto)
    {
        var borrow = _context.Borrows.Find(borrowId);
        
        if (borrow == null)
            return null;
        borrow.ReturnDate = returnDto.ReturnDate ?? DateTime.Now;
        _context.SaveChanges();
        var updatedBorrow = _context.Borrows
            .Include(b => b.User)
            .Include(b => b.Book)
            .First(b => b.Id == borrowId);
        return ConvertToDTO(updatedBorrow);
    }
    public bool Delete(int id)
    {
        var borrow = _context.Borrows.Find(id);
        if (borrow == null)
            return false;
        _context.Borrows.Remove(borrow);
        _context.SaveChanges();
        return true;
    }
    private BorrowDTO ConvertToDTO(Borrow borrow)
    {
        return new BorrowDTO
        {
            Id = borrow.Id,
            UserId = borrow.UserId,
            UserName = borrow.User?.Name,
            BookId = borrow.BookId,
            BookTitle = borrow.Book?.Title,
            BorrowDate = borrow.BorrowDate,
            DueDate = borrow.DueDate,
            ReturnDate = borrow.ReturnDate,
            IsReturned = borrow.IsReturned
        };
    }
}
