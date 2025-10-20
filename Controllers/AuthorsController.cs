using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AuthorsService _service;
    public AuthorsController(AuthorsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public ActionResult<AuthorDTO> PostAuthor(CreateAuthorDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var authorDto = _service.Create(createDto);
        return Ok(authorDto);
    }
}