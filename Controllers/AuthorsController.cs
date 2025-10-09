using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AuthorsService _service;
    
    public AuthorsController(LibraryContext context)
    {
        _service = new AuthorsService(context);
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public ActionResult<Authors> PostAuthor(Authors author)
    {
        return _service.Create(author);
    }
}