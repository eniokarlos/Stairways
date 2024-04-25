
using Stairways.Core.Errors;
using Stairways.Core.ValueObjects;

public class UUID4Test
{
  [Fact]
  public void GivenValidUUIDWhenCreateThenReturnUUIDCreated()
  {
    //Given
    var expectedId = "19812f8a-8f3b-4ed5-af3c-310f8fc30138";
    var id = UUID4.Of(expectedId); 
    //When
    var actualId = id.Unwrap();
    //Then
    Assert.Equal(expectedId, actualId.Value);
  }

  [Fact]
  public void GivenInvalidUUIDWhenCreateThenThrowError()
  {
    //Given
    var id = UUID4.Of("invalid_UUID");
    //When/Then
    Assert.Throws<InvalidUUID4Error>(() => {
      id.Unwrap();
    });
  }

  [Fact]
  public void GivenRandomUUIDWhenCreateThenReturnUUIDCreated()
  {
    //Given/When
    var id = UUID4.Generate();
    //Then
    Assert.IsType<string>(id);
  }
}