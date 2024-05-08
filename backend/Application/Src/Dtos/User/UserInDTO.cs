using Stairways.Core.Models;

namespace Stairways.Application.DTOs;

public record UserInDTO(
  string Name,
  string Email,
  string Password,
  string profileImage,
  ICollection<RoadmapInDTO> Roadmaps
);