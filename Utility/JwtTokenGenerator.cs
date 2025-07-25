using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using agora_shop.Models;
using Microsoft.IdentityModel.Tokens;

namespace agora_shop.Utility;

public static class JwtTokenGenerator
{
    public static string GenerateJwtToken(User user, IConfiguration configuration)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            expires: DateTime.UtcNow.AddHours(2),
            claims: claims,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}