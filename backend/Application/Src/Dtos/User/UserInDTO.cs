namespace Stairways.Application.DTOs;

public record UserInDTO(
  string Name,
  string Email,
  string Password,
  string ProfileImage,
  string[] DoneItemsHashs,
  ICollection<RoadmapInDTO> Roadmaps
);