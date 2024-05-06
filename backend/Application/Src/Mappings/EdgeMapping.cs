using Stairways.Application.DTOs;
using Stairways.Core.Models;

namespace Stairways.Application.Mappings;

public static class EdgeMapping
{
  public static RoadmapEdgeInDTO ToInDTO(this RoadmapEdgeEntity edge)
  {
    var newIn = new RoadmapEdgeInDTO(
      edge.Id.Value,
      edge.Points.StartItem.ToInDTO(),
      edge.Points.EndItem.ToInDTO(),
      edge.Points.StartItemAnchor,
      edge.Points.EndItemAnchor,
      edge.Format,
      edge.Style
    );
    
    return newIn;
  }
}