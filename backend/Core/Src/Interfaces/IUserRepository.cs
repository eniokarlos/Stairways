using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Interfaces;

public interface IUserRespository
{
  Task<Result<UserEntity, EntityNotFoundException>> GetByIdAsync(string userId);
  Task<UserEntity> AddAsync(UserEntity user);
  Task<Result<UserEntity, EntityNotFoundException>> UpdateAsync(UserEntity user);
  Task<Result<EntityNotFoundException>> DeleteAsync(string userId);
}