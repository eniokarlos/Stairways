using Stairways.Core.Enums;

namespace Stairways.Application.DTOs;

public record RoadmapInDTO(
  string UserId,
  string Title,
  string Description,
  RoadmapLevel Level,
  RoadmapPrivacy Privacy,
  string ImageURL,
  string categoryId,
  object JsonContent
);