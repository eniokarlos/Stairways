using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Core.Accounts;

public interface IAuthenticate
{
  Task<bool> AuthenticateAsync(string email, string password);
  Task<bool> UserExists(string email);
  Task<Result<UserEntity, EntityNotFoundException>> GetUserByEmail(string email);
  bool ValidateToken(string jwt);
  string GenerateToken(string id, string email);
}