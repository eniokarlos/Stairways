#pragma warning disable CS8618
using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class EdgePoints
{
  public virtual RoadmapItemEntity StartItem {get; init;}
  public virtual RoadmapItemEntity EndItem {get; init;}
  public RoadmapItemAnchor StartItemAnchor {get; init;}
  public RoadmapItemAnchor EndItemAnchor {get; init;}

  public EdgePoints(RoadmapItemAnchor startItemAnchor, RoadmapItemAnchor endItemAnchor)
  {
    StartItemAnchor = startItemAnchor;
    EndItemAnchor = endItemAnchor;
  }
}

public class RoadmapEdgeEntity : Entity
{
  public EdgePoints Points {get; private set;}
  public RoadmapEdgeFormat Format {get; private set;}
  public RoadmapEdgeStyle Style {get; private set;}


    private RoadmapEdgeEntity()
  : base(UUID4.Generate()){}
  private RoadmapEdgeEntity(Id id, EdgePoints points, 
  RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  :base(id)
  {
    Points = points;
    Format = format;
    Style = style;
  }

  private RoadmapEdgeEntity(EdgePoints points, 
  RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  :base(UUID4.Generate())
  {
    Points = points;
    Format = format;
    Style = style;
  }

  public static Result<RoadmapEdgeEntity, ValidationError> Of(Id id, 
  EdgePoints points, RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  {
    return Create(new RoadmapEdgeEntity(id, points, format, style));
  }

  public static Result<RoadmapEdgeEntity, ValidationError> Of(EdgePoints points, 
  RoadmapEdgeFormat format, RoadmapEdgeStyle style)
  {
    return Create(new RoadmapEdgeEntity(points, format, style));
  }

  public override Result<ValidationError> Validate()
  {
    return Result<ValidationError>.Ok();
  }
}