#pragma warning disable CS8618
using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class RoadmapEdgeEntity : Entity
{
  public RoadmapItemAnchor StartItemAnchor {get; set;}
  public RoadmapItemAnchor EndItemAnchor {get; set;}
  public RoadmapEdgeFormat Format {get; private set;}
  public RoadmapEdgeStyle Style {get; private set;}

  private RoadmapEdgeEntity()
  : base(UUID4.Generate()){}
  
  private RoadmapEdgeEntity(Id id, RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  :base(id)
  {
    Format = format;
    Style = style;
  }

  private RoadmapEdgeEntity(RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  :base(UUID4.Generate())
  {
    Format = format;
    Style = style;
  }

  public static Result<RoadmapEdgeEntity, ValidationError> Of(Id id, 
  RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  {
    return Create(new RoadmapEdgeEntity(id, format, style));
  }

  public static Result<RoadmapEdgeEntity, ValidationError> Of(RoadmapEdgeFormat format, 
  RoadmapEdgeStyle style)
  {
    return Create(new RoadmapEdgeEntity(format, style));
  }

  public override Result<ValidationError> Validate()
  {
    return Result<ValidationError>.Ok();
  }

  public virtual Id StartItemId {get; set;}
  public virtual Id EndItemId {get; set;}
  public virtual RoadmapItemEntity StartItem {get; set;}
  public virtual RoadmapItemEntity EndItem {get;set;}
}