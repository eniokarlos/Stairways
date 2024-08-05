using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Stairways.Core.Accounts;
using Stairways.Core.Errors;
using Stairways.Core.Models;
using Stairways.Core.Utils;
using Stairways.Infra.Context;

namespace Stairways.Infra.Identity;

public class AuthenticateService : IAuthenticate
{
  private readonly ApplicationDbContext _context;
  private readonly IConfiguration _configuration;

  public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
  {
    _context = context;
    _configuration = configuration;
  }

  public async Task<bool> AuthenticateAsync(string email, string password)
  {
    var user = await _context.Users.Where(u => u.Email.ToLower() == email.ToLower())
      .FirstOrDefaultAsync();

    if (user == null)
      return false;

    using var hmac = new HMACSHA256(user.PasswordSalt!);
    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

    for (int i = 0; i < computedHash.Length; i++)
    {
      if (computedHash[i] != user.PasswordHash![i])
        return false;
    }

    return true;
  }

  public string GenerateToken(string id, string email)
  {
    var claims = new[]
    {
      new Claim("id", id),
      new Claim("email", email),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var privateKey = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]!));

    var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
    var expiration = DateTime.UtcNow.AddDays(3);

    var token = new JwtSecurityToken(
      issuer: _configuration["jwt:issuer"],
      audience: _configuration["jwt:audience"],
      claims: claims,
      expires: expiration,
      signingCredentials: credentials
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  public bool ValidateToken(string jwt)
  {
    var handler = new JwtSecurityTokenHandler();
    var privateKey = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]!));

    var parameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = _configuration["jwt:issuer"],
        ValidAudience = _configuration["jwt:audience"],
        IssuerSigningKey = privateKey,
        ClockSkew = TimeSpan.Zero
      };

    try
    {
      handler.ValidateToken(jwt, parameters, out SecurityToken token);
      return true;
    }
    catch
    {
      return false;
    }
  }

  public async Task<Result<UserEntity, EntityNotFoundException>> GetUserByEmail(string email)
  {
    var user = await _context.Users.Where(u => u.Email == email)
      .FirstOrDefaultAsync();

    if (user == null)
      return Result<UserEntity, EntityNotFoundException>.Fail(
        EntityNotFoundException.Of("User not found"));

    return Result<UserEntity, EntityNotFoundException>.Ok(user);
  }

  public async Task<bool> UserExists(string email)
  {
    var user = await _context.Users.Where(u => u.Email.ToLower() == email.ToLower())
    .FirstOrDefaultAsync();

    if (user == null)
      return false;

    return true;
  }

}