using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stairways.Core.Models;
using Stairways.Core.ValueObjects;

namespace Stairways.Infra.Configuration;

public class RoadmapItemConfiguration : IEntityTypeConfiguration<RoadmapItemEntity>
{
  public void Configure(EntityTypeBuilder<RoadmapItemEntity> builder)
  {
    builder.ToTable("Items");
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id)
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );

    builder.ComplexProperty(i => i.Content);
    builder.ComplexProperty(i => i.Box);
    builder.ComplexProperty(i => i.Info);
  }
}