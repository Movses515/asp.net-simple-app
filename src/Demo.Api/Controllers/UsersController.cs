using Demo.Bll.Interfaces;
using Demo.Core.Records;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Demo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUser createUser)
    {
        try
        {
            await _service.CreateAsync(createUser);
            return Created();
        }
        catch (Exception ex)
        {

            return BadRequest(JsonSerializer.Serialize(ex));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var records = await _service.GetUsers();
            return Ok(records);
        }
        catch (Exception ex)
        {

            return BadRequest(JsonSerializer.Serialize(ex));
        }
    }
}
