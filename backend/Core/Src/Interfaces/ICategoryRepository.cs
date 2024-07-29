using Stairways.Core.Models;

namespace Stairways.Core.Interfaces;

public interface ICategoryRepository
{
  Task<ICollection<CategoryEntity>> GetCategories();
}