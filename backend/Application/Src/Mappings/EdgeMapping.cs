using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Application.Mappings;

public static class EdgeMapping
{
  public static RoadmapEdgeInDTO ToInDTO(this RoadmapEdgeEntity edge)
  {
    var newIn = new RoadmapEdgeInDTO(
      edge.StartItemId.Value,
      edge.EndItemId.Value,
      edge.StartItemAnchor,
      edge.EndItemAnchor,
      edge.Format,
      edge.Style
    );
    
    return newIn;
  }

  public static Result<RoadmapEdgeEntity, ValidationError> ToEntity(this RoadmapEdgeInDTO dto)
  {
    var edgeResult = RoadmapEdgeEntity.Of(
      dto.Format,
      dto.Style
    );
    var startItemIdResult = UUID4.Of(dto.StartItemId);
    var endItemIdResult = UUID4.Of(dto.EndItemId);

    if (edgeResult.IsFail)
      return Result<RoadmapEdgeEntity, ValidationError>.Fail(edgeResult.Error!);

    if (startItemIdResult.IsFail)
      return Result<RoadmapEdgeEntity, ValidationError>
        .Fail(new ValidationError(startItemIdResult.Error!.Message));

    if (endItemIdResult.IsFail)
      return Result<RoadmapEdgeEntity, ValidationError>
        .Fail(new ValidationError(endItemIdResult.Error!.Message));

    var newEdge = edgeResult.Unwrap();
    newEdge.StartItemId = startItemIdResult.Unwrap();
    newEdge.EndItemId = endItemIdResult.Unwrap();

    return Result<RoadmapEdgeEntity, ValidationError>.Ok(newEdge);
  }
}