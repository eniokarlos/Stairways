using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stairways.Api.Models;
using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;
using Stairways.Application.Mappings;
using Stairways.Core.Accounts;
using Stairways.Core.ValueObjects;

namespace Stairways.Api.Controllers;

[Route("[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserService _service;
  private readonly IAuthenticate _auth;

  public UserController(IUserService service, IAuthenticate auth)
  {
    _service = service;
    _auth = auth;
  }

  [HttpPost("signup")]
  public async Task<ActionResult> SignUp(UserInDTO userIn)
  {
    if (await _auth.UserExists(userIn.Email))
      return BadRequest("Email has already been registered");

    var res = await _service.AddAsync(userIn);

    if (res.IsFail)
      return BadRequest(res.Error!.Message);

    var token = _auth.GenerateToken(res.Unwrap().Id, userIn.Email);

    return Ok(new {user = res.Unwrap(), token}); 
  }

  [HttpPost("signin")]
  public async Task<ActionResult> SignIn(LoginModel login)
  {
    var userResult = await _auth.GetUserByEmail(login.Email);

    if (userResult.IsFail)
      return BadRequest(userResult.Error!.Message);
    
    var res = await _auth.AuthenticateAsync(login.Email, login.Password);
    if (!res)
      return BadRequest("Invalid login or password");
    var user = userResult.Unwrap();

    var token = _auth.GenerateToken(user.Id.Value, user.Email);

    return Ok(new {user = userResult.Unwrap().ToOutDTO(), token});
  }

  [HttpGet("validate")]
  public ActionResult ValidateToken([FromQuery]string token)
  {
    var res = _auth.ValidateToken(token);

    if (res)
      return Ok("valid token");
    return Unauthorized("invalid token");
  }


  [HttpPatch]
  public async Task<ActionResult> SetUserDoneItems(string userId, string[] doneItems)
  {
    var res = await _service.SetUserDoneItems(userId, doneItems);

    if (res.IsFail)
      return BadRequest(res.Error!.Message);

    return Ok(res.Unwrap());
  }

  [HttpGet("{id}")]
  [Authorize]
  public async Task<ActionResult<UserOutDTO>> GetUserById(string id)
  {
    var userId = User.FindFirst("id")?.Value;

    if (userId != id) 
    {
      return Unauthorized();
    }

    var idResult = UUID4.Of(id);
    if (idResult.IsFail)
      return BadRequest(idResult.Error!.Message);
      
    var res = await _service.GetByIdAsync(id);

    if (res.IsFail)
      return BadRequest(res.Error!.Message);

    return Ok(res.Unwrap());
  }
}