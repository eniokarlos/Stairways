using System.Text.Json;
using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Application.Mappings;

public static class RoadmapMapping
{
  public static RoadmapInDTO ToInDTO(this RoadmapEntity roadmap)
  {
    var newIn = new RoadmapInDTO(
      roadmap.Author.Id.Value,
      roadmap.Meta.Title,
      roadmap.Meta.Description,
      roadmap.Meta.Level,
      roadmap.Meta.Privacity,
      roadmap.Meta.ImageURL,
      roadmap.Category.Id.Value,
      JsonSerializer.Deserialize<object>(roadmap.JsonContent)!
    );
    
    return newIn;
  }

  public static RoadmapOutDTO ToOutDTO(this RoadmapEntity roadmap)
  {
    var newOut = new RoadmapOutDTO(
      roadmap.Id.Value,
      roadmap.Author.Name,
      roadmap.Author.ProfileImage,
      roadmap.Meta.Title,
      roadmap.Meta.Description,
      roadmap.Meta.Level,
      roadmap.Meta.Privacity,
      roadmap.Meta.ImageURL,
      roadmap.Category.ToDto(),
      JsonSerializer.Deserialize<object>(roadmap.JsonContent)!
    );

    return newOut;
  }

  public static Result<RoadmapEntity, EntityValidationException> ToEntity(this RoadmapInDTO dto)
  {
    var roadmapResult = RoadmapEntity.Of(
      new RoadmapMeta(
        dto.Title, 
        dto.Description,
        dto.Level,
        dto.Privacity, 
        dto.ImageURL),
        JsonSerializer.Serialize(dto.JsonContent)
    );

    if (roadmapResult.IsFail)
      return Result<RoadmapEntity, EntityValidationException>.Fail(roadmapResult.Error!);

    var authorId = UUID4.Of(dto.UserId);
    var categoryId = UUID4.Of(dto.categoryId);

    if (authorId.IsFail)
      return Result<RoadmapEntity, EntityValidationException>
        .Fail(new EntityValidationException(authorId.Error!.Message));

    if (categoryId.IsFail)
      return Result<RoadmapEntity, EntityValidationException>
        .Fail(new EntityValidationException(categoryId.Error!.Message));

    var newRoadmap = roadmapResult.Unwrap();
    newRoadmap.AuthorId = authorId.Unwrap();
    newRoadmap.CategoryId = categoryId.Unwrap();

    return Result<RoadmapEntity, EntityValidationException>.Ok(newRoadmap);
  }
}