using Stairways.Core.Enums;

namespace Stairways.Application.DTOs;

public record RoadmapEdgeInDTO(
  string StartItemId,
  string EndItemId,
  RoadmapItemAnchor StartItemAnchor,
  RoadmapItemAnchor EndItemAnchor,
  RoadmapEdgeFormat Format,
  RoadmapEdgeStyle Style
);