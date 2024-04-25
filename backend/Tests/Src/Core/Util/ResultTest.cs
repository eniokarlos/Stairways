using Stairways.Core.Util;

public class ResultTest {
  [Fact]
  public void GivenValidResultWhenCallUnwrapThenReturnValue()
  {
    //Given
    var result = Result<string, Exception>.Ok("test");
    //When
    var data = result.Unwrap();
    //Then
    Assert.Equal("test", data);
  }

  [Fact]
  public void GivenErrorResultWhenCallUnwrapThenThrowError()
  {
    //Given
    var result = Result<string, Exception>.Fail(new Exception());
    //Then
    Assert.Throws<Exception>(() => {
      result.Unwrap();
    });
  }

  [Fact]
  public void GivenAResultWhenItRecieveAValidValueThenReturnValue()
  {
    //Given
    Result<string, Exception> result;
    //When
    result = "test";
    //Then
    Assert.Equal("test", result.Unwrap());
  }

  [Fact]
  public void GivenAResultWhenItRecieveAnErrorThenThrowError()
  {
    //Given
    Result<string, Exception> result;
    //When
    result = new Exception();
    //Then
    Assert.Throws<Exception>(() => {
      result.Unwrap();
    });
  }
}