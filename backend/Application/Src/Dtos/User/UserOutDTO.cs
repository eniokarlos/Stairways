namespace Stairways.Application.DTOs;

public record UserOutDTO(
  string Id,
  string Name,
  string ProfileImage,
  string[] DoneItemsHashs,
  ICollection<RoadmapInDTO> Roadmaps
);