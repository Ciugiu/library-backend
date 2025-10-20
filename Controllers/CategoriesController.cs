using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _service;
    public CategoriesController(CategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _service.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _service.GetById(id);
        if (category == null)
            return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public ActionResult<CategoryDTO> PostCategory(CreateCategoryDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var categoryDto = _service.Create(createDto);
        return CreatedAtAction(nameof(GetCategory), new { id = categoryDto.Id }, categoryDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var result = _service.Delete(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}
