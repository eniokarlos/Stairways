using System.Text.RegularExpressions;
using Stairways.Core.Errors;
using Stairways.Core.Utils;

namespace Stairways.Core.ValueObjects;

public class UUID4 : Id
{
  private UUID4(string id) : base(id)
  {}

  public static Result<UUID4, InvalidUUID4Exception> Of(string id)
  {
    var regex = new Regex(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$");
    if (regex.IsMatch(id))
    {
      return Result<UUID4,InvalidUUID4Exception>.Ok(new UUID4(id));
    }
    return Result<UUID4,InvalidUUID4Exception>.Fail(
      new InvalidUUID4Exception("Invalid UUID4"));
  }

  public static Id Generate()
  {
    return Of(Guid.NewGuid().ToString())
    .Unwrap();
  }
}