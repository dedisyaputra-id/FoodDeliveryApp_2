using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapifirst.Models;

namespace webapifirst.Helper
{
    public static class GeneratJwtToken
    {
        private static readonly string _secretKey = "aVeryLongSecretKeyWithAtLeast32Chars!"; // taruh di appsettings.json
        private static readonly string _issuer = "your-app";
        private static readonly string _audience = "your-app-users";
        public static string GenerateAccessToken(string userId, string email, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GenerateRefreshToken(string userId, FoodDeliveryContext db)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) {
                    return "invalid";
                }
                var oObject = new RefreshToken()
                {
                    RefreshTokenId = Guid.NewGuid().ToString(),
                    RefreshTokenSecret = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                    ExpiresAt = DateTime.UtcNow.AddDays(7),
                    userId = userId
                };
                db.RefreshTokens.Add(oObject);
                db.SaveChanges();
                return oObject.RefreshTokenSecret;
            }
            catch(Exception e)
            {
                return e.Message; 
            }
        }
    }
}
