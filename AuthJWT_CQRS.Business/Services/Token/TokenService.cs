using AuthJWT_CQRS.Business.CQRS.Models.Token;
using AuthJWT_CQRS.Data;
using AuthJWT_CQRS.Entities.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthJWT_CQRS.Business.Services.Token
{
    public class TokenService : ITokenService
    {
        private string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        public TokenModel CreateToken(UserEntity user, IList<string> userRoles)
        {
            TokenModel tokenModel = new TokenModel();

            var authClaims = new List<Claim>
                {
                    new Claim("userId", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Default.JwtSecretKey));
            tokenModel.Expiration = DateTime.UtcNow.AddHours(Settings.Default.AccessTokenExpireTime);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                expires: tokenModel.Expiration,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }
    }
}
