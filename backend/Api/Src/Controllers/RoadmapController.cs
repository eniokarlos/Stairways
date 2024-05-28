using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;

namespace Stairways.Api.Controllers;

[Route("[Controller]")]
[ApiController]
public class RoadmapController : ControllerBase 
{
  private readonly IRoadmapService _service;

  public RoadmapController(IRoadmapService service)
  {
    _service = service;
  }

  [HttpPost("add")]
  [Authorize]
  public async Task<ActionResult> AddAsync(RoadmapInDTO roadmap) 
  {
    var result = await _service.AddAsync(roadmap);

    if (result.IsFail)
      return BadRequest(result.Error!.Message);

    return Ok();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> GetById(string id)
  {
    var result = await _service.GetByIdAsync(id);

    if (result.IsFail)
      return NotFound(result.Error!.Message);

    return Ok(result.Unwrap());
  }

  [HttpGet]
  public async Task<ActionResult> getRoadmaps()
  {
    var result = await _service.GetRoadmaps();
    return Ok(result);
  }

}