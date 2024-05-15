using Stairways.Core.Errors;
using Stairways.Core.Models;

namespace Stairways.Tests.Core.Models;
public class UserTest
{
  [Fact]
  public void GivenValidParamsWhenCreateUserThenReturnUserCreated()
  {
    //Given
    var name = "john";
    var email = "test@email.com";
    //When
    var user = UserEntity.Of(name, email).Unwrap();
    //Then
    Assert.NotNull(user.Id.Value);
    Assert.Equal(email, user.Email);
  }
  
  [Fact]
  public void GivenInvalidNameWhenCreateUserThenThrowError()
  {
    //Given
    var name = "";
    var email = "test@email.com";
    //When/Then
    Assert.Throws<EntityValidationException>(() => {
      UserEntity.Of(name, email).Unwrap();
    });
  }

  [Fact]
  public void GivenInvalidEmailWhenCreateUserThenThrowError()
  {
    //Given
    var name = "john";
    var email = "testemail.com";
    //When/Then
    Assert.Throws<EntityValidationException>(() => {
      UserEntity.Of(name, email).Unwrap();
    });
  }
}