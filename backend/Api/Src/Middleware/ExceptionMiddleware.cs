using System.Net;
using System.Text.Json;
using Stairways.Api.Errors;

namespace Stairways.Api.Middleware;

public class ExcpetionMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExcpetionMiddleware> _logger;
  private readonly IHostEnvironment _env;

  public ExcpetionMiddleware(RequestDelegate next, ILogger<ExcpetionMiddleware> logger, IHostEnvironment env)
  {
    _next = next;
    _logger = logger;
    _env = env;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try 
    {
      await _next(context);
    }
    catch(Exception e)
    {
        _logger.LogError(e, e.Message);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = _env.IsDevelopment() ?
          new ApiException(
            context.Response.StatusCode.ToString(),
            e.Message,
            e.StackTrace!.ToString()
          ) :
          new ApiException(
            context.Response.StatusCode.ToString(),
            e.Message,
            "internal server error"
          );
        
        var options = new JsonSerializerOptions 
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        var json = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(json);
    }
  }
}