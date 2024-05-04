using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Interfaces;

public interface IRoadmapRepository
{
  Task<Result<RoadmapEntity, EntityNotFoundException>> GetByIdAsync(string roadmapId);
  Task<RoadmapEntity> AddAsync(RoadmapEntity roadmap);
  Task<Result<RoadmapEntity, EntityNotFoundException>> UpdateAsync(RoadmapEntity roadmap);
  Task<Result<EntityNotFoundException>> DeleteAsync(string roadmapId);
}