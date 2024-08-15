using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Utils;

namespace Stairways.Application.Interfaces;

public interface IRoadmapService
{
  Task<Result<Exception>> AddAsync(RoadmapInDTO roadmap);
  Task<Result<EntityNotFoundException>> DeleteAsync(string roadmapId);
  Task<Result<RoadmapOutDTO, Exception>> GetByIdAsync(string roadmapId);
  Task<string[]> GetSuggestions(string title);
  Task<PagedList<RoadmapOutDTO>> GetRoadmaps(int pageNumber, int pageSize);
  Task<Result<Exception>> UpdateAsync(RoadmapInDTO roadmap);
}