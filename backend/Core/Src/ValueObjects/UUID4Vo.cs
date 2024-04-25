using System.Text.RegularExpressions;
using Stairways.Core.Errors;
using Stairways.Core.Util;

namespace Stairways.Core.ValueObjects;

public class UUID4 : Id
{
  private UUID4(string id) : base(id)
  {}

  public static Result<UUID4, InvalidUUID4Error> Of(string id)
  {
    var regex = new Regex(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$");
    if (regex.IsMatch(id))
    {
      return Result<UUID4,InvalidUUID4Error>.Ok(new UUID4(id));
    }
    return Result<UUID4,InvalidUUID4Error>.Fail(
      new InvalidUUID4Error("Invalid UUID4"));
  }

  public static string Generate()
  {
    return Of(Guid.NewGuid().ToString())
      .Unwrap().Value;
  }
}