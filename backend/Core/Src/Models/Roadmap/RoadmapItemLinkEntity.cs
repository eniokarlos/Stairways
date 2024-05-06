using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class RoadmapItemLinkEntity : Entity
{
  public string Text {get; private set;}
  public string URL {get; private set;}

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

  public static RoadmapItemLinkEntity Of(Id id, string text, string url)
  {
    return new RoadmapItemLinkEntity(id, text, url);
  }
  public static RoadmapItemLinkEntity Of(string text, string url)
  {
    return new RoadmapItemLinkEntity(text, url);
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