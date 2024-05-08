using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stairways.Application.Interfaces;
using Stairways.Application.Services;
using Stairways.Core.Interfaces;
using Stairways.Infra.Context;
using Stairways.Infra.Repositories;

namespace Stairways.Application.DI;

public static class ApiInjection
{
  public static IServiceCollection AddApiInfraestructure(this IServiceCollection service,
    IConfiguration config)
  {
    service.AddDbContext<ApplicationDbContext>(options => 
      options.UseNpgsql(config.GetConnectionString("DefaultConnection"),
      b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
    );

    service.AddScoped<IUserRespository, UserRepository>();
    service.AddScoped<IRoadmapRepository, RoadmapRepository>();

    service.AddScoped<IUserService, UserService>();

    return service;
  }
}