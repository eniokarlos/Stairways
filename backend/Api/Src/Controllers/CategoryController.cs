using Microsoft.AspNetCore.Mvc;
using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;

namespace Stairways.Api.Controllers;

[Route("[Controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
  private readonly ICategoryService _service;

  public CategoryController(ICategoryService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult> GetCategories()
  {
    var res = await _service.GetCategoriesAsync();

    return Ok(res);
  }
}