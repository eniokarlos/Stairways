using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stairways.Core.Models;
using Stairways.Core.ValueObjects;

namespace Stairways.Infra.Configuration;

public class RoadmapEdgeConfiguration : IEntityTypeConfiguration<RoadmapEdgeEntity>
{
  public void Configure(EntityTypeBuilder<RoadmapEdgeEntity> builder)
  {
    builder.ToTable("Edges");
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id)
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );

    builder.Property(e => e.StartItemId) 
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );     
    builder.Property(e => e.EndItemId) 
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );

    builder.HasOne(e => e.StartItem)
      .WithMany(i => i.StartEdges)
      .HasForeignKey(e => e.StartItemId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(e => e.EndItem)
      .WithMany(i => i.EndEdges)
      .HasForeignKey(e => e.EndItemId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}