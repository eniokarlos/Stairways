using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Application.Mappings;

public static class UserMappings
{
  public static UserOutDTO ToOutDTO(this UserEntity user)
  {
    var outDto = new UserOutDTO(
      user.Id.Value,
      user.Name,
      user.ProfileImage,
      user.DoneItemsHashs,
      user.Roadmaps.Select(r => r.ToInDTO()).ToList()
    );

    return outDto;
  }

  public static Result<UserEntity, EntityValidationException> ToEntity(this UserInDTO dto)
  {
    var userResult = UserEntity.Of(
      dto.Name,
      dto.Email,
      dto.ProfileImage
    );

    var roadmapList = dto.Roadmaps.ToResultList(rm => rm.ToEntity());

    if (userResult.IsFail)
      return Result<UserEntity, EntityValidationException>.Fail(userResult.Error!);
    if (roadmapList.IsFail)
      return Result<UserEntity, EntityValidationException>.Fail(roadmapList.Error!);

    var newUser = userResult.Unwrap();
    newUser.Roadmaps = roadmapList.Unwrap();
    newUser.DoneItemsHashs = dto.DoneItemsHashs;
    
    return Result<UserEntity, EntityValidationException>.Ok(newUser);
  }
}