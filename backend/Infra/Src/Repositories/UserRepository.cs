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

    public async Task<Result<UserEntity, Exception>> GetByIdAsync(string userId)
    {
      var givenId = UUID4.Of(userId);

      if (givenId.IsFail)
        return Result<UserEntity, Exception>.Fail(givenId.Error!);

      var res  = await _context.Users.Include(u => u.Roadmaps).FirstOrDefaultAsync(
        user => user.Id == givenId.Unwrap()
      );

      if (res != null)
        return Result<UserEntity,Exception>.Ok(res);

      return Result<UserEntity,Exception>
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

    public async Task<Result<bool, InvalidUUID4Exception>> UserExists(string id)
    {
      var givenId = UUID4.Of(id);

      if (givenId.IsFail)
        return Result<bool, InvalidUUID4Exception>.Fail(givenId.Error!);

      var result = await _context.Users.FirstOrDefaultAsync(user =>
      user.Id == givenId.Unwrap());

      if (result != null)
        return Result<bool, InvalidUUID4Exception>.Ok(true);

      return false;
    }
}