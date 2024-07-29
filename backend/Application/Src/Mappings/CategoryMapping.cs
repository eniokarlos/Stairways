using Stairways.Application.DTOs;
using Stairways.Core.Models;

namespace Stairways.Application.Mappings;

public static class CategoryMapping
{
  public static CategoryDTO ToDto(this CategoryEntity entity) 
  {
    return new CategoryDTO(entity.Id.Value, entity.Name);
  }
}