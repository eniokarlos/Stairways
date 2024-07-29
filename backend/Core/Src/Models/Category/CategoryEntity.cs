using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class CategoryEntity : Entity
{
  public string Name {get; private set;}
  private CategoryEntity(UUID4 id, string name): base(id)
  {
    Name = name;
  }

  private CategoryEntity(string name): base(UUID4.Generate())
  {
    Name = name;
  }

  public static Result<CategoryEntity,EntityValidationException> Of(UUID4 id, string name) 
  { 
    return Create(new CategoryEntity(id, name));
  }
  public static Result<CategoryEntity,EntityValidationException> Of(string name) 
  { 
    return Create(new CategoryEntity(name));
  }

  public override Result<EntityValidationException> Validate()
  {
    if (string.IsNullOrEmpty(Name)) 
    {
      return Result<EntityValidationException>.Fail(new EntityValidationException("Category Value is required"));
    } 

    return Result<EntityValidationException>.Ok();
  }
}