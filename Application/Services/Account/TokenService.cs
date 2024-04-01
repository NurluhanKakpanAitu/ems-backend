using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dto.Auth;
using Application.Exception;
using Domain.Entity.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Application.Services.Account;

public class TokenService(IConfiguration configuration)
{
    public TokenDto GetToken(AppUser user, IList<string>? userRoles)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserName!),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new("Id", user.Id),
        };
        if(userRoles != null)
            claims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
        
        var secretKey = configuration.GetValue<string>("Jwt:Key");
        if (secretKey == null)
            throw new ApiException("Jwt key is not found");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.AddMinutes(30);

        var token = new JwtSecurityToken(
            "issuer",
            "audience",
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new TokenDto(new JwtSecurityTokenHandler().WriteToken(token), expires, "Bearer");
    }
}