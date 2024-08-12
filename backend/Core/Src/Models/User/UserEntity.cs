using System.Text.RegularExpressions;
using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class UserEntity : Entity
{
  public string Name {get; private set;}
  public string Email {get; private set;}
  public byte[]? PasswordHash {get; private set;}
  public byte[]? PasswordSalt {get; private set;}
  public string ProfileImage {get; private set;}
  public string[] DoneItemsHashs {get; set;}
  public virtual ICollection<RoadmapEntity> Roadmaps {get; set;}
  
  private UserEntity(Id id, string name, string email, string profileImage = "") 
  : base(id)
  {
    Name = name;
    Email = email;
    ProfileImage = profileImage;
    Roadmaps = [];
    DoneItemsHashs = [];
  }

  private UserEntity(string name, string email, string profileImage = "") 
  : base(UUID4.Generate())
  {
    Name = name;
    Email = email;
    ProfileImage = profileImage;
    Roadmaps = [];
    DoneItemsHashs = [];
  }

  public static Result<UserEntity,EntityValidationException> Of(string name, string email, 
  string profileImage = "")
  {
    return Create(new UserEntity(name,email,profileImage));
  }

  public static Result<UserEntity,EntityValidationException> Of(Id id, string name, 
  string email, string profileImage = "")
  {
    return Create(new UserEntity(id, name, email, profileImage));
  }

  public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
  {
    PasswordHash = passwordHash;
    PasswordSalt = passwordSalt;
  }
  public override Result<EntityValidationException> Validate()
  {
      var emailPattern = new Regex(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)*$");

      if (string.IsNullOrEmpty(Name))
      {
        return Result<EntityValidationException>.Fail(new EntityValidationException("Name is required"));
      }
      if (string.IsNullOrEmpty(Email)) 
      {
        return Result<EntityValidationException>.Fail(new EntityValidationException("Email is required"));
      }
      if (!emailPattern.IsMatch(Email))
      {
        return Result<EntityValidationException>.Fail(new EntityValidationException("Invalid Email"));
      }
      return Result<EntityValidationException>.Ok();
  }
}