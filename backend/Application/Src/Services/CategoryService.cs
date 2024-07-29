using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;
using Stairways.Application.Mappings;
using Stairways.Core.Interfaces;

namespace Stairways.Application.Services;

public class CategoryService: ICategoryService
{
  private readonly ICategoryRepository _repository;

  public CategoryService(ICategoryRepository repository)
  {
    _repository = repository;
  }

  public async Task<ICollection<CategoryDTO>> GetCategoriesAsync()
  {
    var result = await _repository.GetCategories();
    return result.Select(c => c.ToDto()).ToArray();
  }
}