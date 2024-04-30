using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Models;

namespace Stairways.Tests.Core;
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
    Assert.NotNull(item.Id);
    Assert.False(string.IsNullOrEmpty(item.Content.Title));
    Assert.False(string.IsNullOrEmpty(item.Content.Description));
    Assert.NotEmpty(item.Content.Links);
    Assert.False(string.IsNullOrEmpty(item.Content.Links[0].Text));
    Assert.False(string.IsNullOrEmpty(item.Content.Links[0].URL));
    Assert.False(string.IsNullOrEmpty(item.Info.Label));
    Assert.False(string.IsNullOrEmpty(item.Info.LinkTo));
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