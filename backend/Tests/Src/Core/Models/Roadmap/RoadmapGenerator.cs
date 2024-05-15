using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;

namespace Stairways.Tests.Core.Models;

public class RoadmapGenerator
{
  private static string validJson = @"{
      'edges': [
      {
        'start': [0, 0],
        'end': [100, 100],
        'format': 'line',
        'style': 'solid'
      },
      {
        'start': [50, 50],
        'end': [200, 200],
        'format': 'curve',
        'style': 'dotted'
      }
      ],
        'items': [
        {
          'label': 'Main Topic',
          'labelWidth': 100,
          'labelSize': 14,
          'position': [50, 50],
          'dimension': [200, 100],
          'content': {
            'title': 'Main Title',
            'description': 'Description of the main topic',
            'links': [
              {
                'text': 'Link 1',
                'url': 'https://example.com/link1'
              },
              {
                'text': 'Link 2',
                'url': 'https://example.com/link2'
              }
          ]
        },
        'type': 'topic'
        }
      ]
    }";
  
  private static RoadmapMeta validMeta = new RoadmapMeta(
      "title", 
      "description",
      RoadmapLevel.BEGINNER,
      RoadmapPrivacity.PRIVATE,
      "imageUrl",
      ["tag1", "tag2", "tag3"]
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