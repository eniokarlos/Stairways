using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stairways.Core.Enums;
using Stairways.Core.Models;
using Stairways.Core.ValueObjects;

namespace Stairways.Infra.Configuration;

public class RoadmapConfiguration : IEntityTypeConfiguration<RoadmapEntity>
{
  public void Configure(EntityTypeBuilder<RoadmapEntity> builder)
  {
    builder.HasKey(rm => rm.Id);
    builder.Property(rm => rm.Id)
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );
      
    builder.ComplexProperty(rm => rm.Meta);

  }
}