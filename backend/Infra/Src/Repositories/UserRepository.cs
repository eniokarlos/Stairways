using Microsoft.EntityFrameworkCore;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;
using Stairways.Infra.Context;

namespace Stairways.Infra.Repositories;

public class UserRepository : IUserRespository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<UserEntity> AddAsync(UserEntity user)
    {
      _context.Add(user);
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<Result<EntityNotFoundException>> DeleteAsync(string userId)
    {
      var res = await GetByIdAsync(userId);

      if (!res.IsFail)
      {
        _context.Remove(res.Unwrap());
        await _context.SaveChangesAsync();
        return Result<EntityNotFoundException>.Ok();
      }

      return Result<EntityNotFoundException>
        .Fail(EntityNotFoundException.Of("User not found"));
    }

    public async Task<Result<UserEntity, EntityNotFoundException>> GetByIdAsync(string userId)
    {
      var res  = await _context.Users.FirstOrDefaultAsync(
        user => user.Id == UUID4.Of(userId).Unwrap()
      );

      if (res != null)
        return Result<UserEntity,EntityNotFoundException>.Ok(res);

      return Result<UserEntity,EntityNotFoundException>
        .Fail(EntityNotFoundException.Of("User not found"));
    }

    public async Task<Result<UserEntity, EntityNotFoundException>> UpdateAsync(UserEntity user)
    {
      var res = await GetByIdAsync(user.Id.Value);

      if (!res.IsFail)
      {
        _context.Update(user);
        await _context.SaveChangesAsync();
        return Result<UserEntity, EntityNotFoundException>.Ok(user);
      }
 
      return Result<UserEntity,EntityNotFoundException>
        .Fail(EntityNotFoundException.Of("User not found"));
    }
}