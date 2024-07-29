using Stairways.Application.DTOs;

namespace Stairways.Application.Interfaces;

public interface ICategoryService
{
  Task<ICollection<CategoryDTO>> GetCategoriesAsync();
}