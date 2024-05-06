using Stairways.Application.DTOs;
using Stairways.Core.Models;

namespace Stairways.Application.Mappings;

public static class ItemMapping 
{
  public static RoadmapItemInDTO ToInDTO(this RoadmapItemEntity item)
  {
    var newIn = new RoadmapItemInDTO(
      item.Id.Value,
      item.Content.Title,
      item.Content.Description,
      item.Box.Width,
      item.Box.Height,
      item.Box.X,
      item.Box.Y,
      item.Info.Label,
      item.Info.LabelWidth,
      item.Info.LabelSize,
      item.Info.LinkTo,
      item.Info.Type,
      item.Content.Links!.Select(l => l.ToInDTO()).ToList()
    );

    return newIn;
  }
}