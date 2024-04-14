using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Client.Auth.Abstract;

namespace Client.Auth
{
    /// <summary>
    /// Сервис для работы с JWT токенами
    /// </summary>
    public class TokenProviderService : ITokenProviderService
    {
        public string? GetValue(string token, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == key)?.Value;
            return claimValue;
        }

        public List<string>? GetValues(string token, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var claimValue = securityToken.Claims.Where(c => c.Type == key).Select(x => x.Value).ToList();
            return claimValue;
        }
    }
}
