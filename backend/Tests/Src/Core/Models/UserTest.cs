using Stairways.Core.Errors;
using Stairways.Core.Models;

public class UserTest
{
  [Fact]
  public void GivenValidParamsWhenCreateUserThenReturnUserCreated()
  {
    //Given
    var name = "john";
    var email = "test@email.com";
    var password = "password";
    //When
    var user = UserEntity.Of(name, email, password);
    //Then
    Assert.IsType<UserEntity>(user);
  }
  
  [Fact]
  public void GivenInvalidNameWhenCreateUserThenThrowError()
  {
    //Given
    var name = "";
    var email = "test@email.com";
    var password = "password";
    //When/Then
    Assert.Throws<ValidationError>(() => {
      UserEntity.Of(name, email, password);
    });
  }

  [Fact]
  public void GivenInvalidEmailWhenCreateUserThenThrowError()
  {
    //Given
    var name = "john";
    var email = "testemail.com";
    var password = "password";
    //When/Then
    Assert.Throws<ValidationError>(() => {
      UserEntity.Of(name, email, password);
    });
  }

  [Fact]
  public void GivenInvalidPasswordWhenCreateUserThenThrowError()
  {
    //Given
    var name = "john";
    var email = "testemail.com";
    var password = "";
    //When/Then
    Assert.Throws<ValidationError>(() => {
      UserEntity.Of(name, email, password);
    });
  }
}