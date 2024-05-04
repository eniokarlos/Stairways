#pragma warning disable CS8618
using System.Text.Json.Serialization;
using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class RoadmapMeta : IValidatable
{
  [JsonIgnore]
  public virtual UserEntity Author {get; private set;}
  public string Title {get; private set;}
  public string Description { get; private set; }
  public RoadmapPrivacity Privacity { get; private set; }
  public string ImageURL { get; private set; }
  public string[] Tags {get; private set;}

  public RoadmapMeta(string title, string description, 
  RoadmapPrivacity privacity, string imageURL, string[] tags)
  {
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
  public RoadmapMeta Meta {get; private set;}
  public ICollection<RoadmapEdgeEntity> Edges {get; private set;}
  public ICollection<RoadmapItemEntity> Items {get; private set;}

  private RoadmapEntity()
  :base(UUID4.Generate()){}

  private RoadmapEntity(Id id, RoadmapMeta meta)
  :base(id)
  {
    Meta = meta;
  }

  private RoadmapEntity(RoadmapMeta meta)
  :base(UUID4.Generate())
  {
    Meta = meta;
  }

  public static Result<RoadmapEntity, ValidationError> Of(Id id, RoadmapMeta meta)
  {
    return Create(new RoadmapEntity(id, meta));
  }

  public static Result<RoadmapEntity, ValidationError> Of(RoadmapMeta meta)
  {
    return Create(new RoadmapEntity(meta));
  }
  public override Result<ValidationError> Validate()
  {
    var metaValidation = Meta.Validate();
    if (metaValidation.IsFail)
      return Result<ValidationError>.Fail(metaValidation.Error!);
    
    return Result<ValidationError>.Ok();
  }
}