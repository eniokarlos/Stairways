using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class EdgePoints
{
  public Id StartItemId {get; set;}
  public Id EndItemId {get; set;}
  public RoadmapItemAnchor StartItemAnchor {get; set;}
  public RoadmapItemAnchor EndItemAnchor {get; set;}

  public EdgePoints(Id startItemId, Id endItemId, 
  RoadmapItemAnchor startItemAnchor, RoadmapItemAnchor endItemAnchor)
  {
    StartItemId = startItemId;
    EndItemId = endItemId;
    StartItemAnchor = startItemAnchor;
    EndItemAnchor = endItemAnchor;
  }
}

public class RoadmapEdgeEntity : Entity
{
  public EdgePoints Points {get; set;}
  public RoadmapEdgeFormat Format {get; set;}
  public RoadmapEdgeStyle Style {get; set;}

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