using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

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
      item.Links!.Select(l => l.ToInDTO()).ToList()
    );

    return newIn;
  }

  public static Result<RoadmapItemEntity, ValidationError> ToEntity(this RoadmapItemInDTO dto)
  {
    var entityResult = RoadmapItemEntity.Of(
      new ItemContent(
        dto.Title,
        dto.Description
      ),
      new ItemBox(
        dto.Width,
        dto.Height,
        dto.X,
        dto.Y
      ),
      new ItemInfo(
       dto.Label,
       dto.Type,
       dto.LabelWidth,
       dto.LabelSize,
       dto.LinkTo 
      )
    );

    var links = dto.Links.ToResultList(l => l.ToEntity());

    if (entityResult.IsFail)
      return Result<RoadmapItemEntity, ValidationError>.Fail(entityResult.Error!);

    var newEntity = entityResult.Unwrap();
    newEntity.Links = links.Unwrap();
    return Result<RoadmapItemEntity, ValidationError>.Ok(newEntity);

  }
}