using Stairways.Ioc;
using Microsoft.OpenApi.Models;
using Stairways.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiInfraestructure(configuration);
builder.Services.AddSwaggerGen(opt => {
  opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
    In = ParameterLocation.Header,
    Description = "Enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    BearerFormat = "JWT",
    Scheme = "Bearer"
  });
  opt.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {
      new OpenApiSecurityScheme
      {
        Reference = new OpenApiReference
        {
          Type = ReferenceType.SecurityScheme,
          Id = "Bearer"
        }
      },
      new string[] {}
    }
  });
});
builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExcpetionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

