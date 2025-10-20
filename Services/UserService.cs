using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Exceptions;

namespace WebApplication1.Services;

public class UserService
{
    private readonly LibraryContext _context;
    
    public UserService(LibraryContext context)
    {
        _context = context;
    }
    public IEnumerable<UserDTO> GetAll()
    {
        var users = _context.Users.ToList();
        var userDTOs = new List<UserDTO>();
        foreach (var user in users)
        {
            userDTOs.Add(ConvertToDTO(user));
        }
        return userDTOs;
    }
    public UserDTO GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
            throw new NotFoundException("User", id);
        return ConvertToDTO(user);
    }

    public UserDTO Create(CreateUserDTO createDto)
    {
        var existingUser = _context.Users
            .FirstOrDefault(u => u.Email == createDto.Email);
        if (existingUser != null)
        {
            throw new BadRequestException($"Email '{createDto.Email}' is already in use");
        }
        var userEntity = new User
        {
            Name = createDto.Name,
            Email = createDto.Email,
            PhoneNumber = createDto.PhoneNumber,
            RegistrationDate = DateTime.Now
        };
        _context.Users.Add(userEntity);
        _context.SaveChanges();
        return ConvertToDTO(userEntity);
    }

    public void Delete(int id)
    {
        var user = _context.Users.Find(id);
        
        if (user == null)
            throw new NotFoundException("User", id);
        
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
    private UserDTO ConvertToDTO(User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            RegistrationDate = user.RegistrationDate
        };
    }
}
