using Stairways.Application.DTOs;
using Stairways.Core.Models;

namespace Stairways.Application.Mappings;

public static class LinkMapping
{
  public static RoadmapLinkInDTO ToInDTO(this RoadmapItemLinkEntity link)
  {
    var newIn = new RoadmapLinkInDTO(
      link.Id.Value,
      link.Text,
      link.URL
    );

    return newIn;
  }
}