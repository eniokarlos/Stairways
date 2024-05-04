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

    // builder.OwnsOne(rm => rm.Meta, metaBuilder => {
    //   metaBuilder.Property(m => m.Title).HasColumnName("Title");
    //   metaBuilder.Property(m => m.Description).HasColumnName("Description");
    //   metaBuilder.Property(m => m.ImageURL).HasColumnName("ImageURL");
    //   metaBuilder.Property(m => m.Privacity).HasColumnName("Privacity");
    //   metaBuilder.Property(m => m.Tags).HasColumnName("Tags");
    // });

    builder.ComplexProperty(rm => rm.Meta);

  }
}