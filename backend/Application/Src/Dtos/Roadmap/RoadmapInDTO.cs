using Stairways.Core.Enums;

namespace Stairways.Application.DTOs;

public record RoadmapInDTO(
  string Title,
  string Description,
  RoadmapPrivacity Privacity,
  string ImageURL,
  string[] Tags,
  ICollection<RoadmapItemInDTO> Items,
  ICollection<RoadmapEdgeInDTO> Edges
);