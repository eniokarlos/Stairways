#pragma warning disable CS8618
using Stairways.Core.Enums;
using Stairways.Core.Errors;
using Stairways.Core.Interfaces;
using Stairways.Core.Utils;
using Stairways.Core.ValueObjects;

namespace Stairways.Core.Models;

public class RoadmapMeta : IValidatable
{
  public string Title {get; private set;}
  public string Description { get; private set; }
  public RoadmapPrivacy Privacy { get; private set; }
  public RoadmapLevel Level {get; private set;}
  public string ImageURL { get; private set; }

  public RoadmapMeta(string title, string description, RoadmapLevel level,
  RoadmapPrivacy privacy, string imageURL)
  {
    Title = title;
    Description = description;
    Privacy = privacy;
    ImageURL = imageURL;
    Level = level;
  }

  public Result<EntityValidationException> Validate()
  {
    if (string.IsNullOrEmpty(Title))
      return Result<EntityValidationException>.Fail(new EntityValidationException("Title is required"));

    if (string.IsNullOrEmpty(Description))
      return Result<EntityValidationException>.Fail(new EntityValidationException("Description is required"));

    if (string.IsNullOrEmpty(ImageURL))
      return Result<EntityValidationException>.Fail(new EntityValidationException("Image URL is required"));

    return Result<EntityValidationException>.Ok();
  }
}
public class RoadmapEntity : Entity
{
  public virtual Id AuthorId {get;set;}
  public virtual Id CategoryId {get;set;}
  public virtual CategoryEntity Category {get;set;}
  public virtual UserEntity Author {get; set;}
  public RoadmapMeta Meta {get; private set;}
  public string JsonContent {get; set;}

  private RoadmapEntity()
  :base(UUID4.Generate()){}

  private RoadmapEntity(Id id, RoadmapMeta meta, string jsonContent)
  :base(id)
  {
    Meta = meta;
    JsonContent = jsonContent;
  }

  private RoadmapEntity(RoadmapMeta meta, string jsonContent)
  :base(UUID4.Generate())
  {
    Meta = meta;
    JsonContent = jsonContent;
  }

  public static Result<RoadmapEntity, EntityValidationException> Of(Id id, RoadmapMeta meta, string jsonContent)
  {
    return Create(new RoadmapEntity(id, meta, jsonContent));
  }

  public static Result<RoadmapEntity, EntityValidationException> Of(RoadmapMeta meta, string jsonContent)
  {
    return Create(new RoadmapEntity(meta, jsonContent));
  }
  public override Result<EntityValidationException> Validate()
  {
    var metaValidation = Meta.Validate();
    var jsonContentValidation = RoadmapJsonValidator.Parse(JsonContent);
    if (metaValidation.IsFail)
      return Result<EntityValidationException>.Fail(metaValidation.Error!);
    
    if (jsonContentValidation.IsFail)
      return Result<EntityValidationException>.Fail(jsonContentValidation.Error!);


    return Result<EntityValidationException>.Ok();
  }
}