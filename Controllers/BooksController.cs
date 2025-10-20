using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BooksService _service;
    
    public BooksController(BooksService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        var books = _service.GetAll();
        return Ok(books);
    }
    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _service.GetById(id);
        
        if (book == null)
            return NotFound();
        
        return Ok(book);
    }


    [HttpPost]
    public ActionResult<BookDTO> PostBook(CreateBookDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var bookDto = _service.Create(createDto);
        
        return CreatedAtAction(nameof(GetBook), new { id = bookDto.Id }, bookDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var result = _service.Delete(id);
        
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}
