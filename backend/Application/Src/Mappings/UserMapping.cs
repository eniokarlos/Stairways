using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Application.Mappings;

public static class UserMappings
{
  public static UserInDTO ToInDTO(this UserEntity user)
  {
    var inDto = new UserInDTO(
      user.Id.Value,
      user.Name,
      user.Email,
      user.Password,
      user.ProfileImage,
      user.Roadmaps.Select(r => r.ToInDTO()).ToList()
    );

    return inDto;
  }

  public static UserOutDTO ToOutDTO(this UserEntity user)
  {
    var outDto = new UserOutDTO(
      user.Id.Value,
      user.Name,
      user.ProfileImage,
      user.Roadmaps.Select(r => r.ToInDTO()).ToList()
    );

    return outDto;
  }

  public static Result<UserEntity, ValidationError> ToEntity(this UserInDTO dto)
  {
    var id = UUID4.Of(dto.Id);
    if (id.IsFail)
      return Result<UserEntity, ValidationError>.Fail(new ValidationError(id.Error!.Message));

    var newEntity = UserEntity.Of(
      id.Unwrap(),
      dto.Name,
      dto.Email,
      dto.profileImage
    );

    if (newEntity.IsFail)
      return Result<UserEntity, ValidationError>.Fail(new ValidationError(newEntity.Error!.Message));

    return Result<UserEntity, ValidationError>.Ok(newEntity.Unwrap());
  }
}