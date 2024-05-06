using Stairways.Core.Enums;
using Stairways.Core.Models;

namespace Stairways.Application.DTOs;

public record RoadmapInDTO(
  string Id,
  string Title,
  string Description,
  RoadmapPrivacity Privacity,
  string ImageURL,
  string[] Tags,
  UserInDTO Author,
  ICollection<RoadmapEdgeInDTO> Edges,
  ICollection<RoadmapItemInDTO> Items
);