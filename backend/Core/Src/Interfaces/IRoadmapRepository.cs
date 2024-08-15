using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Core.Interfaces;

public interface IRoadmapRepository
{
  Task<Result<RoadmapEntity, Exception>> GetByIdAsync(string roadmapId);
  Task<PagedList<RoadmapEntity>> GetRoadmaps(int pageNumber, int pageSize);
  Task<string[]> GetSuggestions(string title);
  Task<RoadmapEntity> AddAsync(RoadmapEntity roadmap);
  Task<Result<RoadmapEntity, EntityNotFoundException>> UpdateAsync(RoadmapEntity roadmap);
  Task<Result<EntityNotFoundException>> DeleteAsync(string roadmapId);
}