using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Data;

namespace WebApplication1.Services;

public class AuthorsService
{
    private readonly LibraryContext _context;
    public AuthorsService(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Authors> GetAll()
    {
        return _context.Authors.ToList();
    }
    
    public Authors Create(Authors author)
    {
        var query = _context.Authors.Where(a => a.FirstName == author.FirstName);
        Console.WriteLine(query.ToQueryString());
            
        _context.Authors.Add(author);
        _context.SaveChangesAsync();
        return author;
    }
}