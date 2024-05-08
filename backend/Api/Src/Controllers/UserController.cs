using Microsoft.AspNetCore.Mvc;
using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Api.Controllers;

[Route("[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserService _service;

  public UserController(IUserService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<ActionResult> AddUser(UserInDTO userIn)
  {
    var res = await _service.AddAsync(userIn);

    if (res.IsFail)
      return BadRequest(res.Error!.Message);

    return Ok();
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