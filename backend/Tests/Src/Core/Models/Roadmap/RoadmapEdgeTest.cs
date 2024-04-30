using Stairways.Core.Models;
using Stairways.Core.Enums;
using Stairways.Core.ValueObjects;

namespace Stairways.Tests.Core.Models;

public class RoadmapEdgeTest
{
  [Fact]
  public void GivenValidParamsWhenCreateEdgeThenReturnEdgeCreated()
  {
    //Given
    var points = new EdgePoints(
      UUID4.Generate(), 
      UUID4.Generate(),
      RoadmapItemAnchor.TOP,
      RoadmapItemAnchor.RIGHT
    );

    //When
    var edge = RoadmapEdgeEntity.Of(
      points, 
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    //Then
    Assert.NotNull(edge.Id);
    Assert.Equal(points.StartItemId, edge.Points.StartItemId);
    Assert.Equal(points.EndItemId, edge.Points.EndItemId);
    Assert.Equal(points.StartItemAnchor, edge.Points.StartItemAnchor);
    Assert.Equal(points.EndItemAnchor, edge.Points.EndItemAnchor);
  }
}