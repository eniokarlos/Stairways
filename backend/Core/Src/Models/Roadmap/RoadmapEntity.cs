using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class RoadmapMeta : IValidatable
{
  public Id UserId {get; set;}
  public string Title {get; set;}
  public string Description { get; set; }
  public RoadmapPrivacity Privacity { get; set; }
  public string ImageURL { get; set; }
  public string[] Tags {get; set;}

  public RoadmapMeta(Id userId, string title, string description, 
  RoadmapPrivacity privacity, string imageURL, string[] tags)
  {
    UserId = userId;
    Title = title;
    Description = description;
    Privacity = privacity;
    ImageURL = imageURL;
    Tags = tags;
  }

  public Result<ValidationError> Validate()
  {
    if (string.IsNullOrEmpty(Title))
      return Result<ValidationError>.Fail(new ValidationError("Title is required"));

    if (string.IsNullOrEmpty(Description))
      return Result<ValidationError>.Fail(new ValidationError("Description is required"));

    if (string.IsNullOrEmpty(ImageURL))
      return Result<ValidationError>.Fail(new ValidationError("Image URL is required"));

    if (Tags.Count() < 3)
      return Result<ValidationError>.Fail(new ValidationError("Tags must be greater than three"));

    return Result<ValidationError>.Ok();
  }
}
public class RoadmapEntity : Entity
{
  public RoadmapMeta Meta {get; set;}
  public RoadmapEdgeEntity[] Edges {get; set;}
  public RoadmapItemEntity[] Items {get; set;}

  private RoadmapEntity(Id id, RoadmapMeta meta, 
  RoadmapEdgeEntity[] edges, RoadmapItemEntity[] items)
  :base(id)
  {
    Meta = meta;
    Edges = edges;
    Items = items;
  }

  private RoadmapEntity(RoadmapMeta meta, 
  RoadmapEdgeEntity[] edges, RoadmapItemEntity[] items)
  :base(UUID4.Generate())
  {
    Meta = meta;
    Edges = edges;
    Items = items;
  }

  public static Result<RoadmapEntity, ValidationError> Of(Id id, RoadmapMeta meta, 
  RoadmapEdgeEntity[] edges, RoadmapItemEntity[] items)
  {
    return Create(new RoadmapEntity(id, meta, edges, items));
  }

  public static Result<RoadmapEntity, ValidationError> Of(RoadmapMeta meta, 
  RoadmapEdgeEntity[] edges, RoadmapItemEntity[] items)
  {
    return Create(new RoadmapEntity(meta, edges, items));
  }
  public override Result<ValidationError> Validate()
  {
    var metaValidation = Meta.Validate();
    if (metaValidation.IsFail)
      return Result<ValidationError>.Fail(metaValidation.Error!);

    if (Edges.Count() == 0)
      return Result<ValidationError>.Fail(new ValidationError("Edges must be greater than zero"));

    if (Items.Count() == 0)
      return Result<ValidationError>.Fail(new ValidationError("Items must be greater than zero"));
    
    return Result<ValidationError>.Ok();
  }
}