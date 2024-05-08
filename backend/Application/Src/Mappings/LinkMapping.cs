using Stairways.Application.DTOs;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Application.Mappings;

public static class LinkMapping
{
  public static RoadmapLinkInDTO ToInDTO(this RoadmapItemLinkEntity link)
  {
    var newIn = new RoadmapLinkInDTO(
      link.Text,
      link.URL
    );

    return newIn;
  }

  public static Result<RoadmapItemLinkEntity, ValidationError> ToEntity(this RoadmapLinkInDTO dto)
  {
    var newLink = RoadmapItemLinkEntity.Of(dto.Text, dto.URL);

    if (newLink.IsFail)
      return Result<RoadmapItemLinkEntity, ValidationError>.Fail(newLink.Error!);

    return Result<RoadmapItemLinkEntity, ValidationError>.Ok(newLink.Unwrap());
  }
}