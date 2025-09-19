using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class JWTService
{
    private static string SECRETKEY = "";
    private static string ISSUER = "todo-app";
    private static string AUDIENCE = "todo-app";

    public static void SetKey(string key)
    {
        SECRETKEY = key;
    }
    public static string GenerateToken(string username)
    {
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim("role", "user"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRETKEY));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: ISSUER,
            audience: AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}