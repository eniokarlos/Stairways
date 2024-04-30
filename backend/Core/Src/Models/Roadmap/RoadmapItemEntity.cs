using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class ItemLink: IValidatable
{
  public string Text;
  public string URL;

  public ItemLink(string text, string url)
  {
    Text = text;
    URL = url;
  }

  public Result<ValidationError> Validate()
  {
    if (string.IsNullOrEmpty(Text))
      return Result<ValidationError>.Fail(new ValidationError("Link Text is Required"));

    if (string.IsNullOrEmpty(URL))
      return Result<ValidationError>.Fail(new ValidationError("Link URL is Required"));

    return Result<ValidationError>.Ok();
  }
}

public class ItemContent
{
  public string Title;
  public string Description;
  public ItemLink[] Links;

  public ItemContent(string title, string description, ItemLink[] links)
  {
    Title = title;
    Description = description;
    Links = links;
  }
}

public class ItemBox: IValidatable
{
  public float Width;
  public float Height;
  public int X;
  public int Y;

  public ItemBox(float width, float height, int x, int y)
  {
    Width = width;
    Height = height;
    X = x;
    Y = y;
  }

  public Result<ValidationError> Validate()
  {
    if (Width <= 0 )
      return Result<ValidationError>.Fail(new ValidationError("Width must be greater than zero"));

    if (Height <= 0)
      return Result<ValidationError>.Fail(new ValidationError("Height must be greater than zero"));

    return Result<ValidationError>.Ok();
  }
}

public class ItemInfo: IValidatable
{
  public string Label;
  public RoadmapItemType Type;
  public int LabelWidth;
  public int LabelSize; 
  public string LinkTo;

  public ItemInfo(string label, RoadmapItemType type, 
  int labelWidth, int labelSize, string linkTo)
  {
    Label = label;
    Type = type;
    LabelWidth = labelWidth;
    LabelSize = labelSize;
    LinkTo = linkTo;
  }

  public Result<ValidationError> Validate()
  {
    if (LabelWidth <= 0)
      return Result<ValidationError>.Fail(new ValidationError("Label width must be greater than zero"));
      
    if (LabelSize <= 0)
      return Result<ValidationError>.Fail(new ValidationError("Label size must be greater than zero"));

    return Result<ValidationError>.Ok();
  }
}

public class RoadmapItemEntity : Entity
{ 
  public ItemContent Content {get; set;}
  public ItemBox Box {get; set;}
  public ItemInfo Info {get; set;}

  private RoadmapItemEntity(Id id, 
  ItemContent content, ItemBox box, ItemInfo info)
  :base(id)
  {
    Content = content;
    Box = box;
    Info = info;
  }

  private RoadmapItemEntity(ItemContent content, ItemBox box, ItemInfo info)
  :base(UUID4.Generate())
  {
    Content = content;
    Box = box;
    Info = info;
  }

  public static Result<RoadmapItemEntity, ValidationError> Of(Id id, 
  ItemContent content, ItemBox box, ItemInfo info)
  {
    return Create(new RoadmapItemEntity(id, content, box, info));
  }

  public static Result<RoadmapItemEntity, ValidationError> Of
    (ItemContent content, ItemBox box, ItemInfo info)
  {
    return Create(new RoadmapItemEntity(content, box, info));
  }

  public override Result<ValidationError> Validate()
  {
    foreach (var link in Content.Links)
    {
      var linkValidation = link.Validate();
      if (linkValidation.IsFail)
        return Result<ValidationError>.Fail(linkValidation.Error!);
    }

    var boxValidation = Box.Validate();
    if (boxValidation.IsFail)
      return Result<ValidationError>.Fail(boxValidation.Error!);

    
    return Result<ValidationError>.Ok();
  }
}