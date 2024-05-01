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
      UUID4.Generate(), 
      "title", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        UUID4.Generate(), 
        UUID4.Generate(),
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description", [
        new ItemLink("link1", "url"),
        new ItemLink("link2", "url")
      ]),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta,
      [edge],
      [item]
    ).Unwrap();
    //Then
    Assert.Equivalent(meta, roadmap.Meta);
    Assert.Equivalent(item, roadmap.Items[0]);
    Assert.Equivalent(edge, roadmap.Edges[0]);
  }

  [Fact]
  public void GivenAnInvalidMetaTitleWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      UUID4.Generate(), 
      "", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        UUID4.Generate(), 
        UUID4.Generate(),
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description", [
        new ItemLink("link1", "url"),
        new ItemLink("link2", "url")
      ]),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta,
      [edge],
      [item]
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
      UUID4.Generate(), 
      "title", 
      "",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        UUID4.Generate(), 
        UUID4.Generate(),
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description", [
        new ItemLink("link1", "url"),
        new ItemLink("link2", "url")
      ]),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta,
      [edge],
      [item]
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
      UUID4.Generate(), 
      "title", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        UUID4.Generate(), 
        UUID4.Generate(),
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description", [
        new ItemLink("link1", "url"),
        new ItemLink("link2", "url")
      ]),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta,
      [edge],
      [item]
    );
    //Then
    Assert.Throws<ValidationError>(() => {
      roadmap.Unwrap();
    });
  }

  [Fact]
  public void GivenAnInvalidRoadmapEdgesWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      UUID4.Generate(), 
      "title", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        UUID4.Generate(), 
        UUID4.Generate(),
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description", [
        new ItemLink("link1", "url"),
        new ItemLink("link2", "url")
      ]),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta,
      [],
      [item]
    );
    //Then
    Assert.Throws<ValidationError>(() => {
      roadmap.Unwrap();
    });
  }

  [Fact]
  public void GivenAnInvalidRoadmapItemsWhenCreateRoadmapThenReturnRoadmapCreated()
  {
    //Given
    var meta = new RoadmapMeta(
      UUID4.Generate(), 
      "title", 
      "description",
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
    );

    var edge = RoadmapEdgeEntity.Of(
      new EdgePoints(
        UUID4.Generate(), 
        UUID4.Generate(),
        RoadmapItemAnchor.TOP,
        RoadmapItemAnchor.RIGHT
      ),
      RoadmapEdgeFormat.STRAIGHT,
      RoadmapEdgeStyle.DOTTED
    ).Unwrap();

    var item = RoadmapItemEntity.Of(
      new ItemContent("title", "description", [
        new ItemLink("link1", "url"),
        new ItemLink("link2", "url")
      ]),
      new ItemBox(100, 200,0,0),
      new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl")
    ).Unwrap();
    //When
    var roadmap = RoadmapEntity.Of(
      meta,
      [edge],
      []
    );
    //Then
    Assert.Throws<ValidationError>(() => {
      roadmap.Unwrap();
    });
  }
}