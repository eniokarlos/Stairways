using Stairways.Application.DTOs;
using Stairways.Application.Interfaces;
using Stairways.Application.Mappings;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;

namespace Stairways.Application.Services;

public class UserService : IUserService
{
  private readonly IUserRespository _repository;

  public UserService(IUserRespository respository)
  {
    _repository = respository;
  }

  public async Task<Result<EntityValidationException>> AddAsync(UserInDTO user)
  {
    var newEntityResult = user.ToEntity();

    if (newEntityResult.IsFail)
      return Result<EntityValidationException>.Fail(newEntityResult.Error!);
    
    await _repository.AddAsync(newEntityResult.Unwrap());
    return Result<EntityValidationException>.Ok();
  }

  public async Task<Result<EntityNotFoundException>> DeleteAsync(string id)
  {
    var result = await _repository.DeleteAsync(id);

    if (result.IsFail)
      return Result<EntityNotFoundException>.Fail(result.Error!);

    return Result<EntityNotFoundException>.Ok();
  }

  public async Task<Result<UserOutDTO, Exception>> GetByIdAsync(string id)
  {
    var result = await _repository.GetByIdAsync(id);

    if (result.IsFail)
      Result<UserOutDTO, Exception>.Fail(result.Error!);
    
    return Result<UserOutDTO, Exception>.Ok(result.Unwrap().ToOutDTO());
  }

  public async Task<Result<UserOutDTO, Exception>> UpdateAsync(UserInDTO user)
  {
    var userEntityResult = user.ToEntity();

    if (userEntityResult.IsFail)
      Result<UserOutDTO, Exception>.Fail(userEntityResult.Error!);

    var result = await _repository.UpdateAsync(userEntityResult.Unwrap());

    if (result.IsFail)
      return Result<UserOutDTO, Exception>.Fail(result.Error!);

    return Result<UserOutDTO, Exception>.Ok(result.Unwrap().ToOutDTO());
  }
}