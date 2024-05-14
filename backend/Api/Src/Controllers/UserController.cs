using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stairways.Api.Models;
using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;
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
  [Authorize]
  public async Task<ActionResult> SignUp(UserInDTO userIn)
  {
    if (await _auth.UserExists(userIn.Email))
      return BadRequest("Email has already been registered");

    var res = await _service.AddAsync(userIn);

    if (res.IsFail)
      return BadRequest(res.Error!.Message);

    var token = _auth.GenerateToken(res.Unwrap().Id, userIn.Email);

    return Ok(token); 
  }

  [HttpPost("signin")]
  public async Task<ActionResult> SignIn(LoginModel login)
  {
    var userResult = await _auth.GetUserByEmail(login.Email);

    if (userResult.IsFail)
      return Unauthorized(userResult.Error!.Message);
    
    var res = await _auth.AuthenticateAsync(login.Email, login.Password);
    if (!res)
      return Unauthorized("Invalid login or password");
    var user = userResult.Unwrap();

    var token = _auth.GenerateToken(user.Id.Value, user.Email);

    return Ok(token);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<UserOutDTO>> GetUserById(string id)
  {
    var idResult = UUID4.Of(id);
    if (idResult.IsFail)
      return BadRequest(idResult.Error!.Message);
      
    var res = await _service.GetByIdAsync(id);

    if (res.IsFail)
      return BadRequest(res.Error!.Message);

    return Ok(res.Unwrap());
  }
}