using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Stairways.Application.Interfaces;
using Stairways.Application.Services;
using Stairways.Core.Accounts;
using Stairways.Core.Interfaces;
using Stairways.Infra.Context;
using Stairways.Infra.Identity;
using Stairways.Infra.Repositories;

namespace Stairways.Ioc;

public static class ApiInjection
{
  public static IServiceCollection AddApiInfraestructure(this IServiceCollection service,
    IConfiguration config)
  {
    service.AddDbContext<ApplicationDbContext>(options => 
      options.UseNpgsql(config.GetConnectionString("DefaultConnection"),
      b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
    );

    service.AddAuthentication(options =>{
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(options =>{
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = config["jwt:issuer"],
        ValidAudience = config["jwt:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(config["jwt:secretKey"]!)),
        ClockSkew = TimeSpan.Zero
      };
    });

    service.AddScoped<IUserRespository, UserRepository>();
    service.AddScoped<IRoadmapRepository, RoadmapRepository>();

    service.AddScoped<IUserService, UserService>();
    service.AddScoped<IAuthenticate, AuthenticateService>();

    service.AddScoped<IRoadmapRepository, RoadmapRepository>();
    service.AddScoped<IRoadmapService, RoadmapService>();

    service.AddScoped<ICategoryRepository, CategoryRepository>();
    service.AddScoped<ICategoryService, CategoryService>();

    return service;
  }
}