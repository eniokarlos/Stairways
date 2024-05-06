using Stairways.Application.DTOs;
using Stairways.Core.Models;

namespace Stairways.Application.Mappings;

public static class RoadmapMapping
{
  public static RoadmapInDTO ToInDTO(this RoadmapEntity roadmap)
  {
    var newIn = new RoadmapInDTO(
      roadmap.Id.Value,
      roadmap.Meta.Title,
      roadmap.Meta.Description,
      roadmap.Meta.Privacity,
      roadmap.Meta.ImageURL,
      roadmap.Meta.Tags,
      roadmap.Meta.Author.ToInDTO(),
      roadmap.Edges.Select(e => e.ToInDTO()).ToList(),
      roadmap.Items.Select(i => i.ToInDTO()).ToList()
    );

    return newIn;
  }
}