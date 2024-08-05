using Microsoft.EntityFrameworkCore;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;
using Stairways.Infra.Context;
using Stairways.Infra.Helpers;

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
    _context.Roadmaps.Add(roadmap);
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

  public async Task<Result<RoadmapEntity, Exception>> GetByIdAsync(string roadmapId)
  {
    var givenId = UUID4.Of(roadmapId);

    if (givenId.IsFail)
      return Result<RoadmapEntity, Exception>.Fail(givenId.Error!);

    var res  = await _context.Roadmaps
    .Include(rm => rm.Author)
    .Include(rm => rm.Category).FirstOrDefaultAsync(
      rm => rm.Id == givenId.Unwrap()
    );

    if (res != null)
      return Result<RoadmapEntity,Exception>.Ok(res);

    return Result<RoadmapEntity,Exception>
      .Fail(EntityNotFoundException.Of("Roadmap not found"));
  }

  public async Task<PagedList<RoadmapEntity>> GetRoadmaps(int pageNumber, int pageSize)
  {
    var query = _context.Roadmaps.Include(rm => rm.Author).Include(rm => rm.Category)
      .Where(rm => rm.Meta.Privacy == Core.Enums.RoadmapPrivacy.PUBLIC);
    return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
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