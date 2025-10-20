using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Services;

public class CategoryService
{
    private readonly LibraryContext _context;
    
    public CategoryService(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<CategoryDTO> GetAll()
    {
        var categories = _context.Categories.ToList();
        var categoryDTOs = new List<CategoryDTO>();
        foreach (var category in categories)
        {
            categoryDTOs.Add(ConvertToDTO(category));
        }
        return categoryDTOs;
    }
    public CategoryDTO? GetById(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
            return null;
        return ConvertToDTO(category);
    }

    public CategoryDTO Create(CreateCategoryDTO createDto)
    {
        var categoryEntity = new Category
        {
            Name = createDto.Name,
            Description = createDto.Description
        };
        _context.Categories.Add(categoryEntity);
        _context.SaveChanges();
        return ConvertToDTO(categoryEntity);
    }
    public bool Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
            return false;
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return true;
    }

    private CategoryDTO ConvertToDTO(Category category)
    {
        return new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
