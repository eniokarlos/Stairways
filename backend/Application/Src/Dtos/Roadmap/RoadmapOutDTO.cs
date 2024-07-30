using Stairways.Core.Enums;

namespace Stairways.Application.DTOs;

public record RoadmapOutDTO(
  string id,
  string AuthorName,
  string AuthorProfileImage,
  string Title,
  string Description,
  RoadmapLevel Level,
  RoadmapPrivacy Privacy,
  string ImageURL,
  CategoryDTO category,
  object JsonContent
);