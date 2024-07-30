using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stairways.Core.Models;
using Stairways.Core.ValueObjects;

namespace Stairways.Infra.Configuration;

public class RoadmapConfiguration : IEntityTypeConfiguration<RoadmapEntity>
{
  public void Configure(EntityTypeBuilder<RoadmapEntity> builder)
  {
    builder.ToTable("Roadmaps");
    builder.HasKey(rm => rm.Id);
    builder.Property(rm => rm.Id)
      .HasConversion(
        id => id.Value,
        value => UUID4.Of(value).Unwrap()
      );          
      
    builder.HasOne(rm => rm.Category).WithMany()
      .HasForeignKey(rm => rm.CategoryId);
    
    builder.ComplexProperty(rm => rm.Meta);

  }
}