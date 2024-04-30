using System.Text.RegularExpressions;
using Stairways.Core.Errors;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class UserEntity : Entity
{
  public string Name {get; set;}
  public string Email {get; set;}
  public string Password {get; set;}
  public string ProfileImage {get; set;}
  
  private UserEntity(Id id, string name, string email, string password, string profileImage = "") 
  : base(id)
  {
    Name = name;
    Email = email;
    Password = password;
    ProfileImage = profileImage;
  }

  private UserEntity(string name, string email, string password, string profileImage = "") 
  : base(UUID4.Generate())
  {
    Name = name;
    Email = email;
    Password = password;
    ProfileImage = profileImage;
  }

  public static Result<UserEntity,ValidationError> Of(string name, string email, 
  string password, string profileImage = "")
  {
    return Create(new UserEntity(name,email,password,profileImage));
  }

  public static Result<UserEntity,ValidationError> Of(Id id, string name, 
  string email, string password, string profileImage = "")
  {
    return Create(new UserEntity(id, name, email, password, profileImage));
  }

  public override Result<ValidationError> Validate()
  {
      var emailPattern = new Regex(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)*$");

      if (string.IsNullOrEmpty(Name))
      {
        return Result<ValidationError>.Fail(new ValidationError("Name is required"));
      }
      if (string.IsNullOrEmpty(Email)) 
      {
        return Result<ValidationError>.Fail(new ValidationError("Email is required"));
      }
      if (!emailPattern.IsMatch(Email))
      {
        return Result<ValidationError>.Fail(new ValidationError("Invalid Email"));
      }
      if(string.IsNullOrEmpty(Password))
      {
        return Result<ValidationError>.Fail(new ValidationError("Password is required"));
      }
      return Result<ValidationError>.Ok();
  }
}