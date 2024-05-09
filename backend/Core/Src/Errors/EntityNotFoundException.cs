namespace Stairways.Core.Errors;

public class EntityNotFoundException : Exception
{
  private EntityNotFoundException(string message)
  :base(message)
  {}

  public static EntityNotFoundException Of(string message)
  {
    return new EntityNotFoundException(message);
  }
}