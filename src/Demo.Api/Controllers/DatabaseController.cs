using Demo.Core.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Demo.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class DatabaseController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DatabaseController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpPost("ensureCreated")]
    public IActionResult Ensure()
    {
        try
        {

            _context.Database.EnsureCreated();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(JsonSerializer.Serialize(ex));
        }
    }

    [HttpPost("update-database")]
    public IActionResult UpdateDatabase()
    {
        try
        {

            _context.Database.Migrate();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(JsonSerializer.Serialize(ex));
        }
    }
}
