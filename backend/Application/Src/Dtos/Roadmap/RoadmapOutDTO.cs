using Stairways.Core.Enums;

namespace Stairways.Application.DTOs;

public record RoadmapOutDTO(
  string id,
  string AuthorName,
  string AuthorProfileImage,
  string Title,
  string Description,
  RoadmapLevel Level,
  RoadmapPrivacity Privacity,
  string ImageURL,
  string[] Tags,
  object JsonContent
);