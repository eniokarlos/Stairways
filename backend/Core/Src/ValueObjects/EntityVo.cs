using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;

namespace Stairways.Core.ValueObjects;

public abstract class Entity : IValidatable
{
  public Id Id {get; set;}
  public DateTime CreatedAt {get; set;}
  public DateTime UpdatedAt {get; set;}

  protected Entity(Id id)
  {
    Id = id;
    CreatedAt = DateTime.UtcNow;
    UpdatedAt = DateTime.UtcNow;
  }

  protected Entity(Id id, DateTime createdAt,DateTime updatedAt)
  {
    Id = id;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public static Result<T, EntityValidationException> Create<T>(T entity) where T: Entity
  {
    var result = entity.Validate();

    if (result.IsFail)
      return Result<T,EntityValidationException>.Fail(result.Error!);
    
    return Result<T,EntityValidationException>.Ok(entity);
  }

  public abstract Result<EntityValidationException> Validate();
}