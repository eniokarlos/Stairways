using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stairways.Core.Models;
using Stairways.Core.ValueObjects;

namespace Stairways.Infra.Configuration;

public class RoadmapItemLinkConfiguration : IEntityTypeConfiguration<RoadmapItemLinkEntity>
{
    public void Configure(EntityTypeBuilder<RoadmapItemLinkEntity> builder)
    {
      builder.ToTable("ItemLinks");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id)
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );
    }
}