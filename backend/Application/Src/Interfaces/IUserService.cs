using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Utils;

namespace Stairways.Application.Interfaces;

public interface IUserService 
{
  Task<Result<ValidationError>> AddAsync(UserInDTO user);
  Task<Result<UserOutDTO, Exception>> GetByIdAsync(string id);
  Task<Result<UserOutDTO, Exception>> UpdateAsync(UserInDTO user);
  Task<Result<EntityNotFoundException>> DeleteAsync(string id);
}