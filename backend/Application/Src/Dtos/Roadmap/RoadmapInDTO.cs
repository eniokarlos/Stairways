using Stairways.Core.Enums;

namespace Stairways.Application.DTOs;

public record RoadmapInDTO(
  string JsonContent,
  string Title,
  string Description,
  RoadmapLevel Level,
  RoadmapPrivacity Privacity,
  string ImageURL,
  string[] Tags
);