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
      roadmap.JsonContent,
      roadmap.Meta.Title,
      roadmap.Meta.Description,
      roadmap.Meta.Level,
      roadmap.Meta.Privacity,
      roadmap.Meta.ImageURL,
      roadmap.Meta.Tags
    );
    
    return newIn;
  }

  public static Result<RoadmapEntity, EntityValidationException> ToEntity(this RoadmapInDTO dto)
  {
    var roadmapResult = RoadmapEntity.Of(
      new RoadmapMeta(
        dto.Title, 
        dto.Description,
        dto.Level,
        dto.Privacity, 
        dto.ImageURL,
        dto.Tags),
        dto.JsonContent
    );

    if (roadmapResult.IsFail)
      return Result<RoadmapEntity, EntityValidationException>.Fail(roadmapResult.Error!);

    var newRoadmap = roadmapResult.Unwrap();

    return Result<RoadmapEntity, EntityValidationException>.Ok(newRoadmap);
  }
}