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
    CreatedAt = DateTime.Now;
    UpdatedAt = DateTime.Now;
  }

  protected Entity(Id id, DateTime createdAt,DateTime updatedAt)
  {
    Id = id;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

  public static Result<T, ValidationError> Create<T>(T entity) where T: Entity
  {
    var result = entity.Validate();

    if (result.IsFail)
      return Result<T,ValidationError>.Fail(result.Error!);
    
    return Result<T,ValidationError>.Ok(entity);
  }

  public abstract Result<ValidationError> Validate();
}