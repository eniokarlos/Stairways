using Stairways.Core.Enums;
using Stairways.Core.Models;

namespace Stairways.Application.DTOs;

public record RoadmapEdgeInDTO(
  string Id,
  RoadmapItemInDTO StartItemId,
  RoadmapItemInDTO EndItemId,
  RoadmapItemAnchor StartItemAnchor,
  RoadmapItemAnchor EndItemAnchor,
  RoadmapEdgeFormat Format,
  RoadmapEdgeStyle Style
);