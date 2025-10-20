using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Services;

public class BooksService
{
    private readonly LibraryContext _context;
    
    public BooksService(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<BookDTO> GetAll()
    {
        var books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .ToList();
        var bookDTOs = new List<BookDTO>();
        foreach (var book in books)
        {
            bookDTOs.Add(ConvertToDTO(book));
        }
        return bookDTOs;
    }
    public BookDTO? GetById(int id)
    {
        var book = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .FirstOrDefault(b => b.Id == id);
        if (book == null)
            return null;
        return ConvertToDTO(book);
    }
    

    public BookDTO Create(CreateBookDTO createDto)
    {
        var bookEntity = new Books
        {
            Title = createDto.Title,
            AuthorId = createDto.AuthorId,
            CategoryId = createDto.CategoryId,
            Language = createDto.Language,
            PublishedYear = (short?)(createDto.PublishedYear ?? 0)
        };
        _context.Books.Add(bookEntity);
        _context.SaveChanges();
        var book = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .First(b => b.Id == bookEntity.Id);
        return ConvertToDTO(book);
    }

    public bool Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
            return false;
        _context.Books.Remove(book);
        _context.SaveChanges();
        return true;
    }

    private BookDTO ConvertToDTO(Books book)
    {
        return new BookDTO
        {
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            AuthorName = book.Author != null 
                ? $"{book.Author.FirstName} {book.Author.LastName}".Trim() 
                : null,
            CategoryId = book.CategoryId,
            CategoryName = book.Category?.Name,
            Language = book.Language,
            PublishedYear = book.PublishedYear
        };
    }
}