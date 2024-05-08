using Microsoft.EntityFrameworkCore;
using Stairways.Core.Models;
namespace Stairways.Infra.Context;

public class ApplicationDbContext : DbContext
{
  public DbSet<UserEntity> Users {get; set;}
  public DbSet<RoadmapEntity> Roadmaps {get; set;}
  public DbSet<RoadmapItemEntity> Items {get; set;}
  public DbSet<RoadmapItemLinkEntity> ItemLinks {get; set;}
  public DbSet<RoadmapEdgeEntity> Edges {get; set;}

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
  :base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}