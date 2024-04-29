namespace Stairways.Core.Errors;

public class ValidationError : Exception
{
  public ValidationError(string message) : base(message)
  {}
}