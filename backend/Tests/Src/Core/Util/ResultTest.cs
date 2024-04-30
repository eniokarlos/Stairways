using Stairways.Core.Utils;

namespace Stairways.Tests.Core.Util;

public class ResultTest {
  [Fact]
  public void GivenAValidResultWhenCallUnwrapThenReturnValue()
  {
    //Given
    var result = Result<string, Exception>.Ok("test");
    //When
    var data = result.Unwrap();
    //Then
    Assert.Equal("test", data);
  }

  [Fact]
  public void GivenAErrorResultWhenCallUnwrapThenThrowError()
  {
    //Given
    var result = Result<string, Exception>.Fail(new Exception());
    //When/Then
    Assert.Throws<Exception>(() => {
      result.Unwrap();
    });
  }

  [Fact]
  public void GivenAOkVoidResultWhencallUnwrapThenThrowError()
  {
    //Given
    var result = Result<Exception>.Ok();
    //When/Then
    Assert.Throws<Exception>(() => {
      result.Unwrap();
    });
  }

  [Fact]
  public void GivenAVoidErrorResultWhenCallUnwrapThenThrowError()
  {
    //Given
    Result<Exception> result;
    //When
    result = new Exception("test");
    //then
    Assert.Throws<Exception>(() => {
      result.Unwrap();
    });
  }
}