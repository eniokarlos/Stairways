using Stairways.Core.Enums;
using Stairways.Core.Models;

namespace Stairways.Application.DTOs;

public record RoadmapItemInDTO(
  string Id,
  string Title,
  string Description,
  float Width,
  float Height,
  int X,
  int Y,
  string Label,
  int LabelWidth,  
  int LabelSize,
  string LinkTo,
  RoadmapItemType Type,
  ICollection<RoadmapLinkInDTO> Links
);