#pragma warning disable CS8618
using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class RoadmapItemLinkEntity : Entity
{
  public string Text {get; private set;}
  public string URL {get; private set;}

  private RoadmapItemLinkEntity()
  :base(UUID4.Generate())
  {}
  private RoadmapItemLinkEntity(Id id, string text, string url)
  :base(id)
  {
    Text = text;
    URL = url;
  }

  private RoadmapItemLinkEntity(string text, string url)
  :base(UUID4.Generate())
  {
    Text = text;
    URL = url;
  }

  public static Result<RoadmapItemLinkEntity, ValidationError> Of(Id id, string text, string url)
  {
    var res = Create(new RoadmapItemLinkEntity(id, text, url));

    if (res.IsFail)
      return Result<RoadmapItemLinkEntity, ValidationError>.Fail(res.Error!);
    return Result<RoadmapItemLinkEntity, ValidationError>.Ok(res.Unwrap());
  }
  
  public static Result<RoadmapItemLinkEntity, ValidationError> Of(string text, string url)
  {
    var res = Create(new RoadmapItemLinkEntity(text, url));

    if (res.IsFail)
      return Result<RoadmapItemLinkEntity, ValidationError>.Fail(res.Error!);
    return Result<RoadmapItemLinkEntity, ValidationError>.Ok(res.Unwrap());
  }

  public override Result<ValidationError> Validate()
  {
    if (string.IsNullOrEmpty(Text))
      return Result<ValidationError>.Fail(new ValidationError("Item Link Text is Required"));

    if (string.IsNullOrEmpty(URL))
      return Result<ValidationError>.Fail(new ValidationError("Item Link URL is Required"));

    return Result<ValidationError>.Ok();
  }
}