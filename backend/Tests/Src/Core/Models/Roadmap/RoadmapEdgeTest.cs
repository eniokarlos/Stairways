using Stairways.Core.Models;
using Stairways.Core.Enums;

namespace Stairways.Tests.Core.Models;

public class RoadmapEdgeTest
{
  [Fact]
  public void GivenValidParamsWhenCreateEdgeThenReturnEdgeCreated()
  {
    //Given
    var points = new EdgePoints(
      RoadmapItemAnchor.TOP,
      RoadmapItemAnchor.RIGHT
    );

    var format = RoadmapEdgeFormat.STRAIGHT;
    var style = RoadmapEdgeStyle.DOTTED;
    //When
    var edge = RoadmapEdgeEntity.Of(
      points, 
      format,
      style
    ).Unwrap();

    //Then
    Assert.Equivalent(points, edge.Points);
    Assert.Equivalent(format, edge.Format);
    Assert.Equivalent(style, edge.Style);
  }
}