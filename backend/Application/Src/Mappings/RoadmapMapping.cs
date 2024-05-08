using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Application.Mappings;

public static class RoadmapMapping
{
  public static RoadmapInDTO ToInDTO(this RoadmapEntity roadmap)
  {
    var newIn = new RoadmapInDTO(
      roadmap.Meta.Title,
      roadmap.Meta.Description,
      roadmap.Meta.Privacity,
      roadmap.Meta.ImageURL,
      roadmap.Meta.Tags,
      roadmap.Items.Select(i => i.ToInDTO()).ToList(),
      roadmap.Edges.Select(e => e.ToInDTO()).ToList()
    );
    
    return newIn;
  }

  public static Result<RoadmapEntity, ValidationError> ToEntity(this RoadmapInDTO dto)
  {
    var roadmapResult = RoadmapEntity.Of(
      new RoadmapMeta(
        dto.Title, 
        dto.Description,
        dto.Privacity, 
        dto.ImageURL,
        dto.Tags)
    );

    var itemListResult = dto.Items.ToResultList(i => i.ToEntity());
    var edgeListResult = dto.Edges.ToResultList(i => i.ToEntity());

    if (roadmapResult.IsFail)
      return Result<RoadmapEntity, ValidationError>.Fail(roadmapResult.Error!);
    if (itemListResult.IsFail)
      return Result<RoadmapEntity, ValidationError>.Fail(itemListResult.Error!);
    if (edgeListResult.IsFail)
      return Result<RoadmapEntity, ValidationError>.Fail(edgeListResult.Error!);

    var newRoadmap = roadmapResult.Unwrap();
    newRoadmap.Items = itemListResult.Unwrap();
    newRoadmap.Edges = edgeListResult.Unwrap();

    return Result<RoadmapEntity, ValidationError>.Ok(roadmapResult.Unwrap());
  }
}