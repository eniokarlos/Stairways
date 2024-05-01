using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Models;

namespace Stairways.Tests.Core.Models;
public class RoadmapItemTest
{
  [Fact]
  public void GivenValidParamsWhenCreateItemThenReturnItemCreated()
  {
    //Given
    var content = new ItemContent("title", "description", [
      new ItemLink("link1", "url"),
      new ItemLink("link2", "url")
    ]);
    var box = new ItemBox(100, 200,0,0);
    var info = new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl");
    
    //When
    var item = RoadmapItemEntity.Of(content, box, info).Unwrap();

    //Then
    Assert.Equivalent(content, item.Content);
    Assert.Equivalent(box, item.Box);
    Assert.Equivalent(info, item.Info);
  }

  [Fact]
  public void GivenInvalidItemLinkWhenCreateItemThenThrowError()
  {
    //Given
    var content = new ItemContent("title", "description", [
      new ItemLink("", "url"),
      new ItemLink("link2", "url")
    ]);
    var box = new ItemBox(100, 200,0,0);
    var info = new ItemInfo("Link", RoadmapItemType.LINK, 400, 38, "linkurl");

    //When/Then
    Assert.Throws<ValidationError>(() => {
      RoadmapItemEntity.Of(content, box, info).Unwrap();
    });
    
  }
}