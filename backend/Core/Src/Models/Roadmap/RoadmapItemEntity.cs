#pragma warning disable CS8618
using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class ItemContent
{
  public string Title {get; private set;}
  public string Description {get; private set;}
  public virtual ICollection<RoadmapItemLinkEntity>? Links {get; private set;}

  public ItemContent(string title, string description)
  {
    Title = title;
    Description = description;
  }
}

public class ItemBox: IValidatable
{
  public float Width {get; private set;}
  public float Height {get; private set;}
  public int X {get; private set;}
  public int Y {get; private set;}

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
  public string Label {get; private set;}
  public RoadmapItemType Type {get; private set;}
  public int LabelWidth {get; private set;}
  public int LabelSize {get; private set;} 
  public string LinkTo {get; private set;}

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
  public ItemContent Content {get; private set;}
  public ItemBox Box {get; private set;}
  public ItemInfo Info {get; private set;}

  private RoadmapItemEntity()
  :base(UUID4.Generate()){}

  private RoadmapItemEntity(UUID4 id, 
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

  public static Result<RoadmapItemEntity, ValidationError> Of(UUID4 id, 
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
    if (Content.Links != null)
    {      
      var count = 0;
      foreach (var link in Content.Links)
      {
        var linkValidation = link.Validate();

        if (linkValidation.IsFail)
          return Result<ValidationError>.Fail(linkValidation.Error!);

        if (count > 6)
          return Result<ValidationError>.Fail(
            new ValidationError("Links lenght must be less than six"));
        count++;
      }
    }

    var boxValidation = Box.Validate();
    if (boxValidation.IsFail)
      return Result<ValidationError>.Fail(boxValidation.Error!);

    
    return Result<ValidationError>.Ok();
  }
}