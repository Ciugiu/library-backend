using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowsController : ControllerBase
{
    private readonly BorrowService _service;
    public BorrowsController(BorrowService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetBorrows()
    {
        var borrows = _service.GetAll();
        return Ok(borrows);
    }

    [HttpGet("{id}")]
    public IActionResult GetBorrow(int id)
    {
        var borrow = _service.GetById(id);
        if (borrow == null)
            return NotFound();
        return Ok(borrow);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetBorrowsByUser(int userId)
    {
        var borrows = _service.GetByUserId(userId);
        return Ok(borrows);
    }

    [HttpPost]
    public ActionResult<BorrowDTO> PostBorrow(CreateBorrowDTO createDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var borrowDto = _service.Create(createDto);
        return CreatedAtAction(nameof(GetBorrow), new { id = borrowDto.Id }, borrowDto);
    }

    [HttpPut("{id}/return")]
    public IActionResult ReturnBook(int id, ReturnBookDTO returnDto)
    {
        var borrow = _service.ReturnBook(id, returnDto);
        if (borrow == null)
            return NotFound();
        return Ok(borrow);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBorrow(int id)
    {
        var result = _service.Delete(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}
