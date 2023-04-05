using Microsoft.AspNetCore.Mvc;
using Tiketoo.Services.Users;
using Tiketoo.Contracts.User;
namespace Tiketoo.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost()]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = _userService.CreateUser(request);
        return CreatedAtAction(
            actionName: nameof(user),
            routeValues: new { id = user.Id },
            value: user);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        Models.User user;
        try {
            user = _userService.GetUser(id);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
        
        return Ok(user);
    }
}