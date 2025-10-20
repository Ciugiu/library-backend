using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserService _service;
    public UsersController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _service.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _service.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<UserDTO> PostUser(CreateUserDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var userDto = _service.Create(createDto);
        return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
