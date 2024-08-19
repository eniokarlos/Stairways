using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stairways.Api.Extensions;
using Stairways.Api.Models;
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

  [HttpGet("suggestions")]
  public async Task<ActionResult<string[]>> GetSuggestions([FromQuery]string title)
  {
    var res = await _service.GetSuggestions(title);

    return Ok(res);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<RoadmapOutDTO>> GetById(string id)
  {
    var result = await _service.GetByIdAsync(id);

    if (result.IsFail)
      return NotFound(result.Error!.Message);

    return Ok(result.Unwrap());
  }

  [HttpPut]
  public async Task<ActionResult> UpdateRoadmap(RoadmapInDTO dto) 
  {
    var result = await _service.UpdateAsync(dto);

    if (result.IsFail)
      return NotFound(result.Error!.Message);

    return Ok();
  }

  [HttpGet]
  public async Task<ActionResult> getRoadmaps([FromQuery]PaginationParams pagination)
  {
    var result = await _service.GetRoadmaps(pagination.PageNumber, pagination.PageSize);

    Response.AddPaginationHeader(
      new PaginationHeader(
        result.CurrentPage, 
        result.ItemsPerPage, 
        result.ItemsPerPage, 
        result.TotalCount, 
        result.TotalPages
      )
    );

    return Ok(result);
  }

}