using Stairways.Core.Models;
using Stairways.Core.ValueObjects;
using Stairways.Core.Enums;
using Stairways.Core.Errors;

namespace Stairways.Tests.Core.Models;

public class RoadmapTest
{
  [Fact]
  public void GivenValidParamsWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      "title", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var roadmap = RoadmapEntity.Of(
      meta
    ).Unwrap();
    //Then
    Assert.Equivalent(meta, roadmap.Meta);
  }

  [Fact]
  public void GivenAnInvalidMetaTitleWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      "", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description"),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta
    );
    //Then
    Assert.Throws<ValidationError>(() => {
      roadmap.Unwrap();
    });
  }
  [Fact]
  public void GivenAnInvalidMetaDescriptionWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      "title", 
      "",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description"),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta
    );
    //Then
    Assert.Throws<ValidationError>(() => {
      roadmap.Unwrap();
    });
  }

  [Fact]
  public void GivenAnInvalidMetaTagsWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      "title", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description"),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta
    );
    //Then
    Assert.Throws<ValidationError>(() => {
      roadmap.Unwrap();
    });
  }

}