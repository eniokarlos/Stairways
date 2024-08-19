using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;
using Stairways.Application.Mappings;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;

namespace Stairways.Application.Services;

public class RoadmapService : IRoadmapService
{
  private readonly IRoadmapRepository _repository;
  private readonly IUserRespository _userRepository;

  public RoadmapService(IRoadmapRepository repository, IUserRespository userRespository)
  {
    _repository = repository;
    _userRepository = userRespository;
  }

  public async Task<Result<Exception>> AddAsync(RoadmapInDTO roadmap)
  {
    var entityResult = roadmap.ToEntity(); 
    var authorExists = await _userRepository.UserExists(roadmap.UserId);

    if (authorExists.IsFail)
      return Result<Exception>.Fail(entityResult.Error!); 

    if (entityResult.IsFail)
      return Result<Exception>.Fail(entityResult.Error!);

    await _repository.AddAsync(entityResult.Unwrap());

    return Result<Exception>.Ok();
  }

  public async Task<Result<EntityNotFoundException>> DeleteAsync(string roadmapId)
  {
    var result = await _repository.DeleteAsync(roadmapId);

    if (result.IsFail)
      return Result<EntityNotFoundException>.Fail(result.Error!);

    return Result<EntityNotFoundException>.Ok();
  }

  public async Task<Result<RoadmapOutDTO, Exception>> GetByIdAsync(string roadmapId)
  {
    var result = await _repository.GetByIdAsync(roadmapId);

    if (result.IsFail)
      return Result<RoadmapOutDTO, Exception>.Fail(result.Error!);

    return Result<RoadmapOutDTO, Exception>.Ok(result.Unwrap().ToOutDTO());
  }

  public async Task<PagedList<RoadmapOutDTO>> GetRoadmaps(int pageNumber, int pageSize)
  {
    var roadmaps = await _repository.GetRoadmaps(pageNumber, pageSize);
    var roadmapsDto = roadmaps.Select(rm => rm.ToOutDTO()).ToList(); 

    return new PagedList<RoadmapOutDTO>
      (roadmapsDto, pageNumber, pageSize, roadmaps.TotalCount);
  }

  public async Task<string[]> GetSuggestions(string title)
  {
    return await _repository.GetSuggestions(title);
  }

  public async Task<Result<Exception>> UpdateAsync(RoadmapInDTO roadmap)
  {
    var entityResult = roadmap.ToEntity();

    if (entityResult.IsFail)
      return Result<Exception>.Fail(new 
        EntityValidationException(entityResult.Error!.Message));

    var result = await _repository.UpdateAsync(entityResult.Unwrap());

    if (result.IsFail)
      return Result<Exception>.Fail(EntityNotFoundException.Of(result.Error!.Message));

    return Result<Exception>.Ok();
  }
}