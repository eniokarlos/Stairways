using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Application.Interfaces;

public interface IRoadmapService
{
  Task<Result<Exception>> AddAsync(RoadmapInDTO roadmap);
  Task<Result<EntityNotFoundException>> DeleteAsync(string roadmapId);
  Task<Result<RoadmapOutDTO, Exception>> GetByIdAsync(string roadmapId);
  Task<ICollection<RoadmapOutDTO>> GetRoadmaps();
  Task<Result<Exception>> UpdateAsync(RoadmapInDTO roadmap);
}