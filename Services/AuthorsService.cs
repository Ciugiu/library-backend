using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public class AuthorsService
{
    private readonly LibraryContext _context;
    public AuthorsService(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<AuthorDTO> GetAll()
    {
        var authors = _context.Authors.ToList();
        var authorDTOs = new List<AuthorDTO>();
        foreach (var author in authors)
        {
            authorDTOs.Add(ConvertToDTO(author));
        }
        
        return authorDTOs;
    }
    
    public AuthorDTO Create(CreateAuthorDTO createDto)
    {
        var authorEntity = new Authors
        {
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Email = createDto.Email,
            Age = createDto.Age
        };
        _context.Authors.Add(authorEntity);
        _context.SaveChanges();
        return ConvertToDTO(authorEntity);
    }
    private AuthorDTO ConvertToDTO(Authors author)
    {
        return new AuthorDTO
        {
            Id = author.Id ?? 0,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Email = author.Email,
            Age = author.Age
        };
    }
}