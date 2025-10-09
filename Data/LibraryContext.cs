using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Authors> Authors {get; set;}
    public DbSet<Books> Books {get; set;}
}