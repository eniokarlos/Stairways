using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Tests.Core.Models;

public class RoadmapGenerator
{
  private static string validJson = @"
  {
    'edges': [
      {
        'path': 'M400,138 C400,216 464,216 464,294',
        'style': 'solid'
      },
      {
        'path': 'M464,330 C464,400 504,400 504,470',
        'style': 'solid'
      },
      {
        'path': 'M654,216 C604,216 604,312 554,312',
        'style': 'solid'
      },
      {
        'path': 'M226,312 C300,312 300,312 374,312',
        'style': 'solid'
      }
    ],
    'items': [
      {
        'x': 272,
        'y': 80,
        'content': {
          'title': '',
          'description': '',
          'links': []
        },
        'height': 64,
        'width': 256,
        'label': 'Tópico',
        'labelSize': 24,
        'labelWidth': 400,
        'type': 'topic',
        'linkTo': ''
      },
      ]
  }";
  
  private static RoadmapMeta validMeta = new RoadmapMeta(
      "title", 
      "description",
      RoadmapLevel.BEGINNER,
      RoadmapPrivacity.PRIVATE,
      "imageUrl"
    );
  
  public static Result<RoadmapEntity, EntityValidationException> OfMeta(RoadmapMeta meta)
  {
    return RoadmapEntity.Of(meta, validJson);
  }

  public static Result<RoadmapEntity, EntityValidationException> OfJson(string json)
  {
    return RoadmapEntity.Of(validMeta, json);
  }
  public static Result<RoadmapEntity, EntityValidationException> OfValid()
  {
    return RoadmapEntity.Of(validMeta,validJson);
  }
}