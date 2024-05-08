using Microsoft.EntityFrameworkCore;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Infra.Context;

namespace Stairways.Infra.Repositories;

public class RoadmapRepository : IRoadmapRepository
{
  private readonly ApplicationDbContext _context;

  public RoadmapRepository(ApplicationDbContext context)
  {
    _context = context;
  }
  
  public async Task<RoadmapEntity> AddAsync(RoadmapEntity roadmap)
  {
    _context.Add(roadmap);
    await _context.SaveChangesAsync();
    return roadmap;
  }

  public async Task<Result<EntityNotFoundException>> DeleteAsync(string roadmapId)
  {
    var res = await GetByIdAsync(roadmapId);

    if (!res.IsFail)
    {
      _context.Remove(res.Unwrap());
      await _context.SaveChangesAsync();
      return Result<EntityNotFoundException>.Ok();
    }

    return Result<EntityNotFoundException>
      .Fail(EntityNotFoundException.Of("Roadmap not found"));
  }

  public async Task<Result<RoadmapEntity, EntityNotFoundException>> GetByIdAsync(string roadmapId)
  {
    var res = await _context.Roadmaps.FirstOrDefaultAsync(
      roadmap => roadmap.Id.Value == roadmapId
    );

    if(res != null)
      return Result<RoadmapEntity, EntityNotFoundException>.Ok(res);

    return Result<RoadmapEntity, EntityNotFoundException>
      .Fail(EntityNotFoundException.Of("Roadmap not found"));
  }

  public async Task<Result<RoadmapEntity, EntityNotFoundException>> UpdateAsync(RoadmapEntity roadmap)
  {
    var res = await GetByIdAsync(roadmap.Id.Value);

    if (!res.IsFail)
    {
      _context.Update(roadmap);
      await _context.SaveChangesAsync();
      return Result<RoadmapEntity, EntityNotFoundException>.Ok(roadmap);
    }

    return Result<RoadmapEntity, EntityNotFoundException>
      .Fail(EntityNotFoundException.Of("Roadmap not found"));

  }
}