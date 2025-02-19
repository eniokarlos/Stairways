using Stairways.Core.Models;
using Stairways.Core.Enums;
using Stairways.Core.Errors;

namespace Stairways.Tests.Core.Models;

public class RoadmapTest
{
  [Fact]
  public void GivenValidParamsWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var currentRoadmap = RoadmapGenerator.OfValid();
    //Then
    Assert.False(currentRoadmap.IsFail);
  }

  [Fact]
  public void GivenAnInvalidMetaTitleWhenCreateRoadmapThenThrowError()
  {
    //Given
    var meta = new RoadmapMeta(
      "", 
      "description",
      RoadmapLevel.BEGINNER,
      RoadmapPrivacy.PRIVATE,
      "imageUrl"
    );

    //When
    var actualRoadmap = RoadmapGenerator.OfMeta(meta);
    //Then
    Assert.Throws<EntityValidationException>(() => {
      actualRoadmap.Unwrap();
    });
  }
  [Fact]
  public void GivenAnInvalidMetaDescriptionWhenCreateRoadmapThenThrowError()
  {
    //Given
    var meta = new RoadmapMeta(
      "title", 
      "",
      RoadmapLevel.BEGINNER,
      RoadmapPrivacy.PRIVATE,
      "imageUrl"
    );
    //When
    var actualRoadmap = RoadmapGenerator.OfMeta(meta);
    //Then
    Assert.Throws<EntityValidationException>(() => {
      actualRoadmap.Unwrap();
    });
  }

  [Fact]
  public void GivenAnInvalidJsonContentWhenCreateRoadmapThenThrowError()
  {
    //Given
    var json = @"{
      'edges': [
        {

        },
      'items': {}
      ]
    }";

    //When
    var actualRoadmap = RoadmapGenerator.OfJson(json);
    //Then
    Assert.Throws<EntityValidationException>(() => {
      actualRoadmap.Unwrap();
    });
  }

}